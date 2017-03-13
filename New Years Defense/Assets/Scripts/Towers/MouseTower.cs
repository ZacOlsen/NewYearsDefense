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
			Quaternion.identity)).GetComponent<PierceExplodingProjectile> ();
		
		proj.SetDistanceAndPierces (maxDistance, numOfPierces);
		proj.SetDamageAndTarget (GetDamage (), enemiesInRange [0]);
		proj.SetBlastRange (explosionRadius, explosionDamage + damageBuff);
	}
}