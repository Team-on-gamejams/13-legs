using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInGame : MenuBase {
	[SerializeField] Player player;

	void Start() {
		player.OnLose += OnPlayerLose;
	}

	void OnDestroy() {
		player.OnLose -= OnPlayerLose;
	}

	protected override void OnEnter() {
		player.StartGame();
	}

	void OnPlayerLose() {
		MenuManager.TransitTo(MenuManager.GetNeededMenu<MenuLose>());
	}
}