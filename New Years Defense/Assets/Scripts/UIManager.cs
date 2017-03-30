﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	[SerializeField] private GameObject[] towerImages = null;

	private float offsetX;
	private bool shown = true;

	void Start () {

		offsetX = ((RectTransform)transform).anchoredPosition.x;
		ToggleShown ();
	}
	
	void Update () {
		
	}

	public void ToggleShown () {

		shown = !shown;
		((RectTransform) transform).anchoredPosition = new Vector2 (-offsetX, ((RectTransform) transform).anchoredPosition.y);
		offsetX = -offsetX;
	}

	public void SpawnTower(int tower){

		Vector2 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Instantiate (towerImages [tower], pos, Quaternion.identity);
		ToggleShown ();
	}
}
