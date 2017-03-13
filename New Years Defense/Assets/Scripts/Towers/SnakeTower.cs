using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTower : Tower {

	[SerializeField] private float rotationAngleSec = 360f;

	void FixedUpdate () {
		transform.RotateAround (transform.position, Vector3.forward, rotationAngleSec * Time.fixedDeltaTime);
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.CompareTag ("Enemy")) {
			other.GetComponent<EnemyController> ().TakeDamage (GetDamage ());
		}
	}
}
