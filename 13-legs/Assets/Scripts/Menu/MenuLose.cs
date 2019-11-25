using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuLose : MenuBase {
	[SerializeField] Cinemachine.CinemachineVirtualCamera menuCamera;

	[SerializeField] string scoreCurrStr;
	[SerializeField] string scoreMaxStr;

	[SerializeField] TextMeshProUGUI scoreCurrText;
	[SerializeField] TextMeshProUGUI scoreMaxText;
	[SerializeField] TextMeshProUGUI newMaxScoreLabel;

	public void OnBackClick() {
		MenuManager.TransitTo(MenuManager.GetNeededMenu<MenuMain>());	
	}

	protected override void OnEnter() {
		menuCamera.gameObject.SetActive(true);

		float currPlayerScore = PlayerPrefs.GetFloat("CurrScore", 0.0f);
		float maxPlayerScore = PlayerPrefs.GetFloat("MaxScore", 0.0f);

		scoreCurrText.text = string.Format(scoreCurrStr, currPlayerScore);
		scoreMaxText.text = string.Format(scoreMaxStr, maxPlayerScore);

		newMaxScoreLabel.gameObject.SetActive(currPlayerScore > maxPlayerScore);
	}

	protected override void OnExit() {
		menuCamera.gameObject.SetActive(false);
	}
}