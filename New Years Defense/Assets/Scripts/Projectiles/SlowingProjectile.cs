using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowingProjectile : Projectile {

	private float slowDebuff = .2f;
	private float duration = 1;

	public void SetSlowDebuff (float slowDebuff, float duration) {
		this.slowDebuff = slowDebuff;
		this.duration = duration;
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.gameObject == target) {

			target.GetComponent<EnemyController> ().TakeDamage (damage);
			target.GetComponent<EnemyController> ().SetSlowAndDuration (1f - slowDebuff, duration);
            AudioSource.PlayClipAtPoint(sound, transform.position);
            Destroy(gameObject);
		}
	}
}
