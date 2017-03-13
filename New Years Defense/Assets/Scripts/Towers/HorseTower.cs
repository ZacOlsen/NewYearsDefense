using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseTower : Tower {

	new void Start () {

		base.Start ();
		BuffInArea ();
	}
	
	private void BuffInArea () {

		GameObject[] towers = GameObject.FindGameObjectsWithTag ("Offense");

		for (int i = 0; i < towers.Length; i++) {

			if (Vector3.Distance (towers[i].transform.position, transform.position) <= range) {
				towers [i].GetComponent<Tower> ().BuffDamage (damage);
			}
		}
	}

	private void NerfInArea () {

		GameObject[] towers = GameObject.FindGameObjectsWithTag ("Offense");

		for (int i = 0; i < towers.Length; i++) {
			
			if (Vector3.Distance (towers[i].transform.position, transform.position) <= range) {
				towers [i].GetComponent<Tower> ().NerfDamage (damage);
			}
		}
	}
}
