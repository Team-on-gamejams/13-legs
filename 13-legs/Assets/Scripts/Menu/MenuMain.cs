using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMain : MenuBase {
	[SerializeField] Cinemachine.CinemachineVirtualCamera menuCamera;

	public void OnPlayClick() {
		MenuManager.TransitTo(MenuManager.GetNeededMenu<MenuInGame>());
	}

	public void OnExitClick() {
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
	}

	protected override void OnEnter() {
		menuCamera.gameObject.SetActive(true);
	}

	protected override void OnExit() {
		menuCamera.gameObject.SetActive(false);
	}
}
