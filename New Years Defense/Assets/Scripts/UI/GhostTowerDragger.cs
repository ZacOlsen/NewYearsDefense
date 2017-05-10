using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTowerDragger : MonoBehaviour {

	[SerializeField] private GameObject tower = null;
	[SerializeField] private GameObject rangeIndicator = null;

	private int cost;

	void Start () {

		GameObject range = Instantiate (rangeIndicator, transform.position, Quaternion.identity) as GameObject;
		range.transform.parent = transform;

		try {
			float scale = tower.GetComponent<Tower> ().GetRange ();
			range.transform.localScale = new Vector3 (scale, scale, 1);
		} catch {
			Destroy (range);
		}
	}

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
