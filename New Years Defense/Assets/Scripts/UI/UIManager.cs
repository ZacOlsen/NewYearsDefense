using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour {

	[SerializeField] private GameObject[] towerImages = null;

	private float offsetX;
	private bool shown = true;

	void Start () {

		offsetX = ((RectTransform)transform).anchoredPosition.x;
		ToggleShown ();
	}

	public void ToggleShown () {

		shown = !shown;
		((RectTransform) transform).anchoredPosition = new Vector2 (-offsetX, ((RectTransform) transform).anchoredPosition.y);
		offsetX = -offsetX;
	}

	public GameObject SpawnTower(int tower){

		Vector2 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		GameObject ghostTower = ((GameObject) Instantiate (towerImages [tower], pos, Quaternion.identity));
		ToggleShown ();

		return ghostTower;
	}
}
