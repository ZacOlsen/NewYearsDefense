using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTower : Tower, AttackSpeedIncreasable {

	[SerializeField] protected float timeBetweenShots = .3f;
	protected float timeOfLastShot;
	private float firingRateIncrease;

	[SerializeField] protected GameObject projectile = null;
	
	void FixedUpdate () {

		EnemyCheck ();

		if (enemiesInRange.Count > 0 && Time.time - timeOfLastShot > GetFiringRate ()) {

			FireProjectile ();
			timeOfLastShot = Time.time;
		}
	}

	public void IncreaseFiringRate (float rate) {
		firingRateIncrease = Mathf.Clamp01 (firingRateIncrease + rate);
	}

	public void DecreaseFiringRate (float rate) {
		firingRateIncrease = Mathf.Clamp01 (firingRateIncrease - rate);
	}

	public float GetFiringRate () {
		return timeBetweenShots - (timeBetweenShots * firingRateIncrease);
	}

	protected virtual void FireProjectile () {

		transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * 
			Mathf.Atan2 (enemiesInRange[0].transform.position.y	- transform.position.y, 
			enemiesInRange[0].transform.position.x - transform.position.x) - 90);

		Projectile proj = ((GameObject) Instantiate (projectile, transform.position, 
			Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan2 (enemiesInRange[0].transform.position.y - transform.position.y, 
			enemiesInRange[0].transform.position.x - transform.position.x) - 90))).GetComponent<Projectile> ();

		proj.SetDamageAndTarget (GetDamage (), enemiesInRange [0]);
	}

	protected void EnemyCheck () {

		while (enemiesInRange.Count > 0 && enemiesInRange [0] == null) {
			enemiesInRange.RemoveAt (0);
		}
	}
}
