using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitItem : Tower {

	new void Start () {}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.gameObject.CompareTag ("Enemy")) {

			GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");

			for (int i = 0; i < enemies.Length; i++) {

				if (Vector3.Distance(transform.position, enemies[i].transform.position) <= range) {
					enemies [i].GetComponent<EnemyController> ().TakeDamage (damage);
				}
			}

			Destroy (gameObject);
		}
	}
}
