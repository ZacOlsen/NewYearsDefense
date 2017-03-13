﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingProjectile : Projectile {

	private float range = 2f;
	private List<EnemyController> enemies;

	private Vector3 targetLoc;

	void Start () {
		
		GetComponent<CircleCollider2D> ().radius = range;
		enemies = new List<EnemyController> ();
	}

	void FixedUpdate () {

		float distance = Vector3.Distance (transform.position, targetLoc);

		if (distance < errorRange) {
			Explode ();
			return;
		}

		transform.position = Vector3.Lerp (transform.position, targetLoc, Time.fixedDeltaTime * speed / distance);
	}

	public override void SetDamageAndTarget (int damage, GameObject target) {

		this.damage = damage;
		targetLoc = target.transform.position;
	}

	private void Explode () {

		for (int i = 0; i < enemies.Count; i++) {

			if (enemies[i] != null) {
				enemies [i].TakeDamage (damage);
			}
		}

		Destroy (gameObject);
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.CompareTag ("Enemy")) {
			enemies.Add (other.GetComponent<EnemyController> ());
		}
	}

	void OnTriggerExit2D (Collider2D other) {

		if (other.CompareTag ("Enemy")) {
			enemies.Remove (other.GetComponent<EnemyController> ());
		}
	}
}
