using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTowerDragger : MonoBehaviour {

	[SerializeField] private GameObject tower = null;

	private int cost;

	void Update () {

		Vector2 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.position = pos;

		if (Input.GetMouseButtonUp (0)) {
			Instantiate (tower, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}

	public void SetCost (int cost) {
		this.cost = cost;
	}

	public int GetCost () {
		return cost;
	}
}
