using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLose : MenuBase {
	[SerializeField] Cinemachine.CinemachineVirtualCamera menuCamera;

	public void OnBackClick() {
		MenuManager.TransitTo(MenuManager.GetNeededMenu<MenuMain>());
	}

	protected override void OnEnter() {
		menuCamera.gameObject.SetActive(true);
	}

	protected override void OnExit() {
		menuCamera.gameObject.SetActive(false);
	}
}