using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoosterTower : ProjectileTower {

	[SerializeField] private int numOfRapidShots = 3;
	[SerializeField] private float timeBetweenRapidShots = .1f;
	private float timeOfLastRapidShot;

	private int currentRapidShot;

	void FixedUpdate () {

		EnemyCheck ();

		if (enemiesInRange.Count > 0 && Time.time - timeOfLastShot > GetFiringRate () &&
			Time.time - timeOfLastRapidShot > timeBetweenRapidShots) {
		
			if (currentRapidShot < numOfRapidShots) {
				
				FireProjectile ();

				timeOfLastRapidShot = Time.time;
				currentRapidShot++;
			
			} else {

				timeOfLastShot = Time.time;
				currentRapidShot = 0;
			}
		}
	}
}
