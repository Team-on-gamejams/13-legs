using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInGame : MenuBase {
	[SerializeField] Player player;

	protected override void OnEnter() {
		player.StartGame();
	}
}