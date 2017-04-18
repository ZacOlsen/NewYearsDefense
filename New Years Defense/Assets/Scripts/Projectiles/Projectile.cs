using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	protected const float errorRange = .05f;
	[SerializeField] protected float speed = 10f;

	protected int damage;
	protected GameObject target;

    protected AudioSource audioPlayer;
    [SerializeField] protected AudioClip sound;

    void Start () {
        audioPlayer = GetComponent<AudioSource> ();
    }

	void FixedUpdate () {

		if (target == null) {
			Destroy (gameObject);
			return;
		}

		transform.position = Vector3.Lerp (transform.position, target.transform.position, 
			Time.fixedDeltaTime * speed / Vector3.Distance (transform.position, target.transform.position));
	}

	public virtual void SetDamageAndTarget (int damage, GameObject target) {

		this.damage = damage;
		this.target = target;
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.gameObject == target) {

			target.GetComponent<EnemyController> ().TakeDamage (damage);
            AudioSource.PlayClipAtPoint(sound, transform.position);
            Destroy(gameObject);
		}
	}
}
