using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PierceProjectile : Projectile {

	protected float slowDebuff = 0f;
	protected float duration = 0f;

	protected float maxDistance = 8f;
	protected int numOfPierces = 5;
	protected int currentPierces;

	protected Vector3 targetLoc;

	public void SetSlowDebuff (float slowDebuff, float duration) {
		this.slowDebuff = slowDebuff;
		this.duration = duration;
	}

	void FixedUpdate () {

		float distance = Vector3.Distance (transform.position, targetLoc);

		if (distance < errorRange) {
			Destroy (gameObject);
			return;
		}

		transform.position = Vector3.Lerp (transform.position, targetLoc, Time.fixedDeltaTime * speed / distance);
	}

	public override void SetDamageAndTarget (int damage, GameObject target) {

		this.damage = damage;
		targetLoc = ((target.transform.position - transform.position).normalized * maxDistance) + transform.position;
	}

	public void SetDistanceAndPierces (float maxDistance, int numOfPierces) {

		this.maxDistance = maxDistance;
		this.numOfPierces = numOfPierces;
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.CompareTag ("Enemy")) {

			other.GetComponent<EnemyController> ().TakeDamage (damage);
			other.GetComponent<EnemyController> ().SetSlowAndDuration (1f - slowDebuff, duration);
            AudioSource.PlayClipAtPoint(sound, transform.position);

            if (currentPierces < numOfPierces) {
				currentPierces++;
			} else {
				Destroy (gameObject);
			}
		}
	}
}
