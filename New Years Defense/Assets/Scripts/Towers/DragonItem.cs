using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonItem : MonoBehaviour {

	[SerializeField] private int damage = 30;

	void Start () {

		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		for (int i = 0; i < enemies.Length; i++) {

			enemies [i].GetComponent<EnemyController> ().TakeDamage (damage);
		}

		Destroy (gameObject);
	}
}
