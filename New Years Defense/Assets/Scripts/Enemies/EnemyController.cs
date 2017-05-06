using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	[SerializeField] private float speed = 5f;
	protected const float errorRange = .05f;

	[SerializeField] private int damage = 3;
	[SerializeField] private int health = 20;

	[SerializeField] private int moneyDrop = 5;

	private AudioSource audioPlayer;
	[SerializeField] private AudioClip puddleStep = null;
	[SerializeField] private AudioClip grunt = null;

	private float slow;
	private float timeOfSlow = 0;
	private float slowDuration;

	private GameObject map;
	private int currentIndex = 1;

	private BaseStats baseStats;

	void Start () {

		map = GameObject.Find ("Map");
		baseStats = GameObject.FindGameObjectWithTag ("Base").GetComponent<BaseStats> ();

		transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * 
			Mathf.Atan2 (map.transform.GetChild (currentIndex).transform.position.y	- transform.position.y, 
			map.transform.GetChild (currentIndex).transform.position.x - transform.position.x) - 90);

		audioPlayer = GetComponent<AudioSource> ();
		audioPlayer.loop = true;
		audioPlayer.clip = grunt;
		audioPlayer.Play ();

		StartCoroutine ("LoopDelayedAudio");
	}
	
	void FixedUpdate () {

		transform.position = Vector3.Lerp (transform.position, map.transform.GetChild (currentIndex).transform.position, 
			Time.fixedDeltaTime * (Time.time - timeOfSlow > slowDuration ? speed : speed * slow) / 
			Vector3.Distance (transform.position, map.transform.GetChild (currentIndex).transform.position));

		if (Vector3.Distance (transform.position, map.transform.GetChild (currentIndex).transform.position) < errorRange) {
			currentIndex++;

			if (currentIndex >= map.transform.childCount) {
				baseStats.TakeDamage (damage);
				Destroy (gameObject);
			} else {
				
				transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * 
					Mathf.Atan2 (map.transform.GetChild (currentIndex).transform.position.y	- transform.position.y, 
					map.transform.GetChild (currentIndex).transform.position.x - transform.position.x) - 90);
			}
		}
	}

	IEnumerator LoopDelayedAudio () {

		while (this != null) {
			audioPlayer.PlayOneShot (puddleStep);
			yield return new WaitForSeconds (.66f);
		}
	}

	public void TakeDamage (int damage) {

		health -= damage;

		if (health <= 0) {
			baseStats.AddMoney (moneyDrop);
			Destroy (gameObject);
		}
	}

	public virtual void SetSlowAndDuration (float slow, float duration){

		this.slow = slow;
		slowDuration = duration;
		timeOfSlow = Time.time;
	}
}
