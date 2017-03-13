using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	[SerializeField] private float speed = 5f;
	protected const float errorRange = .05f;

//	[SerializeField] private int damage = 1;
	[SerializeField] private int health = 20;

	private float slow;
	private float timeOfSlow = 0;
	private float slowDuration;

	private GameObject map;
	private int currentIndex = 1;

	void Start () {

		map = GameObject.Find ("Map");
	}
	
	void FixedUpdate () {

		transform.position = Vector3.Lerp (transform.position, map.transform.GetChild (currentIndex).transform.position, 
			Time.fixedDeltaTime * (Time.time - timeOfSlow > slowDuration ? speed : speed * slow) / 
			Vector3.Distance (transform.position, map.transform.GetChild (currentIndex).transform.position));
	
		if (Vector3.Distance (transform.position, map.transform.GetChild (currentIndex).transform.position) < errorRange) {
			currentIndex++;

			if (currentIndex >= map.transform.childCount) {
				Destroy (gameObject);
			}
		}
	}

	public void TakeDamage (int damage) {

		health -= damage;

		if (health <= 0) {
			Destroy (gameObject);
		}
	}

	public void SetSlowAndDuration (float slow, float duration){

		this.slow = slow;
		slowDuration = duration;
		timeOfSlow = Time.time;
	}
}
