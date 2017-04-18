using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PierceExplodingProjectile : PierceProjectile {

	private float range = 3f;
	private int explosionDamage = 5;

	void FixedUpdate () {

		float distance = Vector3.Distance (transform.position, targetLoc);

		if (distance < errorRange) {
			Explode ();
			return;
		}

		transform.position = Vector3.Lerp (transform.position, targetLoc, Time.fixedDeltaTime * speed / distance);
	}

	public void SetBlastRange (float range, int explosionDamage) {

		this.range = range;
		this.explosionDamage = explosionDamage;
	}

	void Explode () {

		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");

		for (int i = 0; i < enemies.Length; i++) {

			if (enemies [i] != null && Vector3.Distance (transform.position, enemies [i].transform.position) <= range) {
				enemies [i].GetComponent<EnemyController> ().TakeDamage (explosionDamage);
			}
		}

		Destroy (gameObject);
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.CompareTag ("Enemy")) {

			other.GetComponent<EnemyController> ().TakeDamage (damage);
            AudioSource.PlayClipAtPoint(sound, transform.position);

            if (currentPierces < numOfPierces) {
				currentPierces++;
			} else {
				Explode ();
			}
		}
	}
}
