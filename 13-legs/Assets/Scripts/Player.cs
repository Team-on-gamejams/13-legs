using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	[SerializeField] float moveForce;

	[SerializeField] Rigidbody2D rb;

	Vector3 moveVect;

	void Update() {
		moveVect = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
	}

	void FixedUpdate() {
		rb.AddForce(moveVect * moveForce * Time.fixedDeltaTime);
	}
}
