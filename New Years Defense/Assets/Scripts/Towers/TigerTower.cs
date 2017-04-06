using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerTower : ProjectileTower {

	[SerializeField][Range(0, 1)] private float slowDebuff = .2f;
	[SerializeField] private float slowDuration = 1f;

	protected override void FireProjectile () {

		SlowingProjectile proj = ((GameObject) Instantiate (projectile, transform.position, 
			Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan2 (enemiesInRange[0].transform.position.y - transform.position.y, enemiesInRange[0].transform.position.x - transform.position.x) - 90))).GetComponent<SlowingProjectile> ();

		proj.SetDamageAndTarget (GetDamage (), enemiesInRange [0]);
		proj.SetSlowDebuff (slowDebuff, slowDuration);
	}
}
