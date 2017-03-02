using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	[SerializeField] private float timeBetweenSpawns = 3f;
	private float timeOfLastSpawn;

	[SerializeField] private GameObject enemy = null;

	private Transform spawnPoint;

	void Start () {

		spawnPoint = GameObject.Find ("Waypoint 1").transform;
		Instantiate (enemy, spawnPoint.position, Quaternion.identity);
	}
		
	void FixedUpdate () {

		if (Time.time - timeOfLastSpawn > timeBetweenSpawns) {

			Instantiate (enemy, spawnPoint.position, Quaternion.identity);
			timeOfLastSpawn = Time.time;
		}
	}
}
