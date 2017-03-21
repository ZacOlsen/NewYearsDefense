using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogTower : Tower {

	[SerializeField] [Range(0, 1)] private float percentSpeedIncrease = .4f;

	new void Start () {

		base.Start ();
		BuffInArea ();
	}

	private void BuffInArea () {

		GameObject[] towers = GameObject.FindGameObjectsWithTag ("Offense");

		for (int i = 0; i < towers.Length; i++) {

			if (Vector3.Distance (towers[i].transform.position, transform.position) <= range) {
				towers [i].GetComponent<AttackSpeedIncreasable> ().IncreaseFiringRate (percentSpeedIncrease);
			}
		}
	}

	private void NerfInArea () {

		GameObject[] towers = GameObject.FindGameObjectsWithTag ("Offense");

		for (int i = 0; i < towers.Length; i++) {

			if (Vector3.Distance (towers[i].transform.position, transform.position) <= range) {
				towers [i].GetComponent<AttackSpeedIncreasable> ().DecreaseFiringRate (percentSpeedIncrease);
			}
		}
	}
}
