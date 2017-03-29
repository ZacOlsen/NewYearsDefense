﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseStats : MonoBehaviour {

	[SerializeField] private int health;
	[SerializeField] private int money;

	private Text statDisplay;

	void Start () {
		
		statDisplay = GameObject.Find ("Stat Display").GetComponent<Text> ();
		UpdateStats ();
	}

	public void TakeDamage (int damage) {

		health -= damage;
		UpdateStats ();
	}

	public void AddMoney (int money) {

		this.money += money;
		UpdateStats ();
	}

	public bool Spend (int money) {

		if (this.money - money >= 0) {
			this.money -= money;
			return true;
		}

		return false;
	}

	private void UpdateStats () {
		statDisplay.text = "Health: " + health + "\nMoney: " + money;
	}
}