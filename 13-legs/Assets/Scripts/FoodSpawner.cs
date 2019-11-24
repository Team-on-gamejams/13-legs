using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour {
	public static FoodSpawner instance;

	[SerializeField] int startFood = 100;
	[SerializeField] float spawnCircleSize = 20;
	[SerializeField] GameObject foodPrefab;

	void Awake() {
		instance = this;

		for (int i = 0; i < startFood; ++i)
			SpawnFood();
	}

	public void SpawnFood() {
		Instantiate(foodPrefab, Random.insideUnitCircle * spawnCircleSize, Quaternion.identity, transform);
	}
}
