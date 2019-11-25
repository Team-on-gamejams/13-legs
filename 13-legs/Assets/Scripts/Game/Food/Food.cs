using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {
	public float hpRegen = 5;

	public void OnEat() {
		FoodSpawner.instance.SpawnFood();
	}
}
