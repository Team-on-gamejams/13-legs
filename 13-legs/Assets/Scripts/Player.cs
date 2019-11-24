using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	[SerializeField] float hpMax;
	[SerializeField] float hpCurr;
	[SerializeField] float hpLossPerSec;

	[SerializeField] float moveForce;

	[SerializeField] Rigidbody2D rb;

	Vector3 moveVect;

	void Update() {
		moveVect = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
	}

	void FixedUpdate() {
		rb.AddForce(moveVect * moveForce * Time.fixedDeltaTime);
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if(collision.tag == "Food") {
			Food food = collision.GetComponent<Food>();
			if((hpCurr += food.hpRegen) > hpMax) 
				hpCurr = hpMax;
			food.OnEat();
			Destroy(collision.gameObject);
		}
	}
}
