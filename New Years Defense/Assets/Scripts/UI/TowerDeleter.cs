using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TowerDeleter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	[SerializeField] private Sprite closed = null;
	[SerializeField] private Sprite open = null;

	private Image image;
	private bool selected;
	private BaseStats baseStats;

	void Start () {
		
		baseStats = GameObject.Find ("Base Stats").GetComponent<BaseStats> ();

		image = GetComponent<Image> ();
		image.sprite = closed;
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
		image.sprite = open;
	}

	public void OnPointerExit (PointerEventData data) {

		selected = false;
		image.sprite = closed;
	}
}
