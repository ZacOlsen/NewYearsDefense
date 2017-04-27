using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	[SerializeField] private float timeBetweenSpawns = 3f;
	private float timeOfLastSpawn;

	[SerializeField] private GameObject[] mogwai = null;
	[SerializeField] private GameObject[] niumowang = null;
	[SerializeField] private GameObject[] yaomo = null;
	[SerializeField] private GameObject[] yaojing = null;

	[SerializeField] private int waveOfMogwaiUpgrade1 = 12;
	[SerializeField] private int waveOfMogwaiUpgrade2 = 24;
	[SerializeField] private int waveOfNiumowangUpgrade1 = 18;
	[SerializeField] private int waveOfNiumowangUpgrade2 = 30;
	[SerializeField] private int waveOfYaomoUpgrade1 = 15;
	[SerializeField] private int waveOfYaomoUpgrade2 = 27;
	[SerializeField] private int waveOfYaojingUpgrade1 = 21;
	[SerializeField] private int waveOfYaojingUpgrade2 = 33;

	//wave, enemy numbers
	[SerializeField] private int[] wavesBeforeFormula = null;
	[SerializeField] private int[] formulaWaves;
	private int wave;
	private bool waveStarted;
	private int enemy;

	private Transform spawnPoint;

	public const int TYPES_OF_ENEMIES = 4;

	void Start () {

		spawnPoint = GameObject.Find ("Waypoint 1").transform;
		formulaWaves = new int [TYPES_OF_ENEMIES];
		//StartNextWave ();
	}
		
	void FixedUpdate () {

		if (waveStarted && Time.time - timeOfLastSpawn > timeBetweenSpawns) {

			timeOfLastSpawn = Time.time;

			if (wave * TYPES_OF_ENEMIES <= wavesBeforeFormula.Length) {

				FindNextEnemy (wavesBeforeFormula, wave);

			} else {
				
				FindNextEnemy (formulaWaves, 1);
			}
		}
	}

	void FindNextEnemy (int[] enemies, int waveShift) {

		if (enemies [enemy] == 0) {

			int counter = 0;
			while (enemies [enemy] == 0) {

				counter++;
				if (counter == TYPES_OF_ENEMIES) {
					enemy = -1;
					break;
				}

				enemy++;
				if (enemy == (waveShift - 1) * TYPES_OF_ENEMIES + TYPES_OF_ENEMIES) {
					enemy -= TYPES_OF_ENEMIES;
				}
			}

			if (enemy == -1) {
				enemy = (wave - 1) * TYPES_OF_ENEMIES + TYPES_OF_ENEMIES;	//this wave is used for when it is before,
				waveStarted = false;										//enmeis gets reset in calculate
				//StartNextWave ();
				return;
			}
		}

		enemies [enemy]--;

		enemy++;
		if (enemy == (waveShift - 1) * TYPES_OF_ENEMIES + TYPES_OF_ENEMIES) {
			enemy -= TYPES_OF_ENEMIES;
		}

		SpawnEnemey (enemy);
	}

	void CalculateWaveEnemies () {

		enemy = 0;

		formulaWaves [0] = wave * wave / 5;
		formulaWaves [1] = (wave % 5) * 2;
		formulaWaves [2] = (wave % 3) * 5;
		formulaWaves [3] = (wave % 4) * 5;
	}

	void SpawnEnemey (int enemy) {

		enemy %= TYPES_OF_ENEMIES;

		switch (enemy) {

		case 0:
			Instantiate (mogwai[wave >= waveOfMogwaiUpgrade2 ? 2 : (wave >= waveOfMogwaiUpgrade1 ? 1 : 0)], 
				spawnPoint.position, Quaternion.identity);
			break;

		case 1:
			Instantiate (niumowang[wave >= waveOfNiumowangUpgrade2 ? 2 : (wave >= waveOfNiumowangUpgrade1 ? 1 : 0)], 
				spawnPoint.position, Quaternion.identity);
			break;

		case 2:
			Instantiate (yaomo[wave >= waveOfYaomoUpgrade2 ? 2 : (wave >= waveOfYaomoUpgrade1 ? 1 : 0)], 
				spawnPoint.position, Quaternion.identity);
			break;

		case 3:
			Instantiate (yaojing[wave >= waveOfYaojingUpgrade2 ? 2 : (wave >= waveOfYaojingUpgrade1 ? 1 : 0)],
				spawnPoint.position, Quaternion.identity);
			break;

		default:
			Debug.Log ("error");
			break;
		}
	}

	public void StartNextWave () {

		wave++;
		waveStarted = true;

		if (wave * TYPES_OF_ENEMIES > wavesBeforeFormula.Length) {
			CalculateWaveEnemies ();
		}
	}

	public int GetWave () {
		return wave;
	}
	public bool GetWaveStarted()
	{
		return waveStarted;
	}
}
