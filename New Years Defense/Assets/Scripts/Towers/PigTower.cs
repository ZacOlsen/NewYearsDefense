using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigTower : MonoBehaviour {

	[SerializeField] private float timeBetweenGoldGen = 10f;
	[SerializeField] private int amountToGen = 5;

	private float timeOfLastGen;
	private bool allowGen = true;

	private BaseStats baseStats;

	void Start () {
		baseStats = GameObject.FindGameObjectWithTag ("Base").GetComponent<BaseStats> ();
	}

	void FixedUpdate () {

		if (allowGen && Time.time - timeOfLastGen > timeBetweenGoldGen) {
			baseStats.AddMoney(amountToGen);
			timeOfLastGen = Time.time;
		}
	}
}
