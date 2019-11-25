using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	[Header("HP")]
	[SerializeField] float hpMax;
	[SerializeField] float hpCurr;
	[SerializeField] float hpLoss;
	[SerializeField] float hpLossTime;
	[SerializeField] Transform hpCircle;

	[Header("Moving")]
	[SerializeField] float moveForce;

	[Header("Refs")]
	[SerializeField] Rigidbody2D rb;

	Vector3 moveVect;
	float currHpLoseTimer = 0;
	bool isPlaying;

	void Start() {
		StartGame();
	}

	void Update() {
		if (!isPlaying)
			return;

		moveVect = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

		currHpLoseTimer += Time.deltaTime;
		while (currHpLoseTimer >= hpLossTime) {
			currHpLoseTimer -= hpLossTime;
			if ((hpCurr -= hpLoss) <= 0.0f)
				hpCurr = 0;

			if (hpCurr == 0)
				Lose();

			hpCircle.localScale = Vector3.one * (hpCurr / hpMax);
		}

	}

	void FixedUpdate() {
		if (!isPlaying)
			return;

		rb.AddForce(moveVect * moveForce * Time.fixedDeltaTime);
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if(collision.tag == "Food") {
			Food food = collision.GetComponent<Food>();
			if((hpCurr += food.hpRegen) > hpMax) 
				hpCurr = hpMax;
			food.OnEat();
			Destroy(collision.gameObject);
		}
	}

	public void StartGame() {
		isPlaying = true;
	}

	public void Lose() {
		isPlaying = false;
	}
}
