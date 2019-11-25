using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leg : MonoBehaviour {
	[NonSerialized] public GameObject target;
	[NonSerialized] public float timer;

	[SerializeField] float magnitudeForOrigin = 3.5f;

	[SerializeField] float rotationSpeed = 5.0f;
	[SerializeField] float scaleSpeed = 1.0f;

	[SerializeField] SpriteRenderer sr;

	Vector3 prevPos = Vector3.zero;

	void Update() {
		if (target) {
			timer += Time.deltaTime;

			Vector3 vectorToTarget = target.transform.position - transform.position;
			float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Lerp(transform.rotation, q, rotationSpeed * Time.deltaTime);

			sr.transform.localScale = Vector3.Lerp(sr.transform.localScale, new Vector3(1.0f, vectorToTarget.magnitude / magnitudeForOrigin, 1.0f), scaleSpeed * Time.deltaTime);

		}
		else {
			sr.transform.localScale = Vector3.Lerp(sr.transform.localScale, new Vector3(1.0f, 0.65f, 1.0f), scaleSpeed * Time.deltaTime);

			//if(prevPos != transform.position && prevPos != Vector3.zero) {
			//	Vector3 vectorToTarget = prevPos - transform.position;
			//	float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
			//	Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			//	transform.rotation = Quaternion.Lerp(transform.rotation, q, rotationSpeed * Time.deltaTime);
			//}
		}

		prevPos = transform.position;
	}

	public float GetAngleTo(Vector3 targetPos) {
		Vector3 vectorToTarget = targetPos - transform.position;
		return Mathf.Abs(Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90 - transform.rotation.eulerAngles.z);
	}

	public void SetNewTarget(GameObject _target) {
		target = _target;
		timer = 0;

		if (_target != null && _target.GetComponent<Food>() != null)
			sr.color = Color.red;
		else
			sr.color = Color.white;
	}
}
