using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	[SerializeField] private GameObject[] towerImages = null;

	private EnemyManager em;

	private float offsetX;
	private bool shown = true;
	[SerializeField] private Sprite sprPause = null;
	[SerializeField] private Sprite sprNext = null;
	[SerializeField] private Sprite sprResume = null;
	private bool isNext = true;
	private bool isPaused = false;

	private Image nextButton;

	void Start () {

		em = GameObject.Find ("Map").GetComponent<EnemyManager> ();

		nextButton = GameObject.Find ("NextButton").GetComponent<Image> ();

		offsetX = ((RectTransform)transform).anchoredPosition.x;
		ToggleShown ();
	}

	void FixedUpdate () {
		
		if (!em.GetWaveStarted() && GameObject.FindGameObjectsWithTag("Enemy").Length == 0) {
			nextButton.sprite = sprNext;
			isNext = true;
			isPaused = false;
		}
	}

	public void ToggleShown () {

		shown = !shown;
		((RectTransform) transform).anchoredPosition = new Vector2 (-offsetX, ((RectTransform) transform).anchoredPosition.y);
		offsetX = -offsetX;
	}

	public GameObject SpawnTower(int tower){

		Vector2 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		GameObject ghostTower = ((GameObject) Instantiate (towerImages [tower], pos, Quaternion.identity));
		ToggleShown ();

		return ghostTower;
	}

	public void NextButton () {
		if (isNext) {
			em.StartNextWave ();
			nextButton.sprite = sprPause;
			isNext = false;

		} else {
		
			if (isPaused) {
				//Resume function
				Time.timeScale = 1;
				nextButton.sprite = sprPause;
				isPaused = false;
			
			} else {
				//Pause function
				Time.timeScale = 0;
				nextButton.sprite = sprResume;
				isPaused = true;
			}
		}
	}
}