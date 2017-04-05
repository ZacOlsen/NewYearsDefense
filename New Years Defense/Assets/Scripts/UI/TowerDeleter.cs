using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerDeleter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	private bool selected;
	private BaseStats baseStats;

	void Start () {
		baseStats = GameObject.Find ("Base Stats").GetComponent<BaseStats> ();
	}

	void Update () {

		if (selected && Input.GetMouseButtonUp (0)) {

			GameObject tower = GameObject.FindGameObjectWithTag ("Ghost");
			baseStats.AddMoney (tower.GetComponent<GhostTowerDragger> ().GetCost());

			Destroy (tower);
		}
	}

	public void OnPointerEnter (PointerEventData data) {
		selected = true;
	}

	public void OnPointerExit (PointerEventData data) {
		selected = false;
	}
}
