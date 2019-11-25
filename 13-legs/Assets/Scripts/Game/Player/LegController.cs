using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegController : MonoBehaviour {
	[SerializeField] Player player;
	[SerializeField] float playerRad = 1.2f;

	[SerializeField] List<Leg> legs;

	void Update() {
		transform.position = player.transform.position;
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "Food") {
			Leg leg = null;
			bool findEmpty = false;

			foreach (var i in legs) {
				if(i.target == null) {
					leg = i;
					findEmpty = true;
					break;
				}
			}

			if (!findEmpty) {
				byte maxTimer = 0;
				for(byte i = 1; i < legs.Count; ++i) 
					if(legs[i].timer > legs[maxTimer].timer) 
						maxTimer = i;
				leg = legs[maxTimer];
			}

			leg.SetNewTarget(collision.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D collision) {
		if (collision.tag == "Food") {
			foreach (var leg in legs) {
				if (leg.target == collision.gameObject) {
					leg.SetNewTarget(null);
					break;
				}
			}
		}
	}
}
