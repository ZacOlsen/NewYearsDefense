using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTowerDragger : MonoBehaviour {

	bool locked;
	
	void Update () {

		if (!locked) {
			Vector2 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			transform.position = pos;
		}

		if (Input.GetMouseButtonUp (0)) {
			locked = true;
		}
	}
}
