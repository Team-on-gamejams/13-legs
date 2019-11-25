using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leg : MonoBehaviour {
	[NonSerialized] public GameObject target;
	[NonSerialized] public float timer;

	[SerializeField] float magnitudeForOrigin = 3.5f;

	[SerializeField] SpriteRenderer sr;

	void Update() {
		if (target) {
			timer += Time.deltaTime;

			Vector3 vectorToTarget = target.transform.position - transform.position;
			float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = q;

			sr.transform.localScale = new Vector3(1.0f, vectorToTarget.magnitude / magnitudeForOrigin, 1.0f);

		}
		else {
			gameObject.SetActive(false);
		}
	}

	public void SetNewTarget(GameObject _target) {
		target = _target;
		timer = 0;
		gameObject.SetActive(true);
	}
}
