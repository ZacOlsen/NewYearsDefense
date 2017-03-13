using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour {

	[SerializeField] protected float range = 3f;
	[SerializeField] protected int damage = 5;

	protected int damageBuff;

	protected List<GameObject> enemiesInRange;

	protected void Start () {

		enemiesInRange = new List<GameObject> ();

		if (GetComponent<CircleCollider2D>() != null) {
			GetComponent<CircleCollider2D> ().radius = range;
		}
	}

	public int GetDamage () {
		return damage + damageBuff;
	}

	public void BuffDamage (int buff) {
		damageBuff += buff;
	}

	public void NerfDamage (int nerf) {
		damage -= nerf;
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.CompareTag ("Enemy")) {
			enemiesInRange.Add (other.gameObject);
		}
	}

	void OnTriggerExit2D (Collider2D other) {

		if (other.CompareTag ("Enemy")) {
			enemiesInRange.Remove (other.gameObject);
		}
	}
}
