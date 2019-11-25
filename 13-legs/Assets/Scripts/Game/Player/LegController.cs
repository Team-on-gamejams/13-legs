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

			byte minAngle = 0;
			float angle = float.MaxValue;

			for (byte i = 0; i < legs.Count; ++i) {
				if (legs[i].target == null && legs[i].GetAngleTo(collision.transform.position) < angle) {
					minAngle = i;
					angle = legs[minAngle].GetAngleTo(collision.transform.position);
					findEmpty = true;
				}
			}

			if (!findEmpty) {
				minAngle = 0;
				angle = legs[minAngle].GetAngleTo(collision.transform.position);

				for(byte i = 1; i < legs.Count; ++i) {
					if(legs[i].GetAngleTo(collision.transform.position) < angle) {
						minAngle = i;
						angle = legs[minAngle].GetAngleTo(collision.transform.position);
					}
				}
			}

			leg = legs[minAngle];
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
