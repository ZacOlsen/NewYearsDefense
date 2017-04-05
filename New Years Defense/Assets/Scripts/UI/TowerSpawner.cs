using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerSpawner : MonoBehaviour, IPointerDownHandler {

	[SerializeField] private int towerID = -1;
	[SerializeField] private int cost = 25;

	BaseStats baseStats;
	UIManager manager;

	void Start () {

		baseStats = GameObject.Find ("Base Stats").GetComponent<BaseStats> ();
		manager = GameObject.Find ("UI").GetComponent<UIManager> ();
	}

	public void OnPointerDown (PointerEventData data) {

		if (baseStats.Spend (cost)) {
			manager.SpawnTower (towerID).GetComponent<GhostTowerDragger> ().SetCost (cost);
		}
	}
}
