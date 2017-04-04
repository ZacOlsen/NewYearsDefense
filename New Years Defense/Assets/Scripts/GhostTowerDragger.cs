using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTowerDragger : MonoBehaviour {

	[SerializeField] private GameObject tower = null;

	void Update () {

		Vector2 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.position = pos;

		if (Input.GetMouseButtonUp (0)) {
			Instantiate (tower, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}
}
