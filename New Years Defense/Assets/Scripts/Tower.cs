using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	[SerializeField] private float timeBetweenShots = .3f;
	private float timeOfLastShot;

	[SerializeField] private float range = 3f;
	[SerializeField] private int damage = 5;

	[SerializeField] private GameObject projectile = null;

	private List<GameObject> enemiesInRange;

	void Start () {

		enemiesInRange = new List<GameObject> ();
		GetComponent<CircleCollider2D> ().radius = range;
	}

	void FixedUpdate () {

		while (enemiesInRange.Count > 0 && enemiesInRange [0] == null) {
			enemiesInRange.RemoveAt (0);
		}
			
		if (enemiesInRange.Count > 0 && Time.time - timeOfLastShot > timeBetweenShots) {
		
			Projectile proj = ((GameObject) Instantiate (projectile, transform.position, Quaternion.identity)).GetComponent<Projectile> ();
			proj.SetDamageAndTarget (damage, enemiesInRange [0]);

			timeOfLastShot = Time.time;
		}
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
