using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTower : ProjectileTower {

	[SerializeField] private float maxDistance = 5f;
	[SerializeField] private int numOfPierces = 5;

	[SerializeField] private float explosionRadius = 3f;
	[SerializeField] private int explosionDamage = 5;

	protected override void FireProjectile () {

		PierceExplodingProjectile proj = ((GameObject) Instantiate (projectile, transform.position, 
			Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan2 (enemiesInRange[0].transform.position.y - transform.position.y, enemiesInRange[0].transform.position.x - transform.position.x) - 90))).GetComponent<PierceExplodingProjectile> ();
		
		proj.SetDistanceAndPierces (maxDistance, numOfPierces);
		proj.SetDamageAndTarget (GetDamage (), enemiesInRange [0]);
		proj.SetBlastRange (explosionRadius, explosionDamage + damageBuff);
	}
}