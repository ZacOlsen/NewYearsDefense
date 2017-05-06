using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxTower : ProjectileTower {

	[SerializeField][Range(0, 1)] private float slowDebuff = .2f;
	[SerializeField] private float slowDuration = 1f;

	[SerializeField] private float maxDistance = 10f;
	[SerializeField] private int numOfPierces = 5;

	protected override void FireProjectile () {

		transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * 
			Mathf.Atan2 (enemiesInRange[0].transform.position.y	- transform.position.y, 
			enemiesInRange[0].transform.position.x - transform.position.x) - 90);

		PierceProjectile proj = ((GameObject) Instantiate (projectile, transform.position, 
			Quaternion.identity)).GetComponent<PierceProjectile> ();

		proj.SetDistanceAndPierces (maxDistance, numOfPierces);
		proj.SetDamageAndTarget (GetDamage (), enemiesInRange [0]);
		proj.SetSlowDebuff (slowDebuff, slowDuration);
	}
}
