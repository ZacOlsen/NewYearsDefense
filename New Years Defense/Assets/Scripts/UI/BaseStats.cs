using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseStats : MonoBehaviour {

	[SerializeField] private int health;
	[SerializeField] private int money;

	[SerializeField] private AudioClip backgroundMusic = null;
	private AudioSource audioPlayer;

	private EnemyManager enemyManager;
	private Text statDisplay;

	void Start () {
		
		statDisplay = GameObject.Find ("Stat Display").GetComponent<Text> ();
		enemyManager = GameObject.Find ("Map").GetComponent<EnemyManager> ();
		UpdateStats ();

		audioPlayer = GetComponent<AudioSource> ();
		audioPlayer.clip = backgroundMusic;
		audioPlayer.loop = true;
		audioPlayer.Play ();
	}

	public void TakeDamage (int damage) {

		health -= damage;
		UpdateStats ();

		if (health <= 0) {
			GameObject.Find ("UI").GetComponent<UIManager> ().Lose ();
		}
	}

	public void AddMoney (int money) {

		this.money += money;
		UpdateStats ();
	}

	public bool Spend (int money) {

		if (this.money - money >= 0) {
			this.money -= money;
			UpdateStats ();
			return true;
		}

		return false;
	}

	private void UpdateStats () {
		statDisplay.text = health + "\n" + money + "\n" + enemyManager.GetWave();
	}
}
