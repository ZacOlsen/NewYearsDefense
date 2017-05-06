using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	protected const float errorRange = .05f;
	[SerializeField] protected float speed = 10f;

	protected int damage;
	protected GameObject target;

    protected AudioSource audioPlayer;
	[SerializeField] protected AudioClip explosion;
	[SerializeField] protected AudioClip flying;

	protected Animator anim;
	protected const float explosionAnimSpeed = 3f;

    void Start () {
		
        audioPlayer = GetComponent<AudioSource> ();
		anim = GetComponent<Animator> ();

		audioPlayer.PlayOneShot (flying);
	}

	void FixedUpdate () {

		if (target == null) {
			Destroy (gameObject);
			return;
		}

		transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * 
			Mathf.Atan2 (target.transform.position.y - transform.position.y, 
			target.transform.position.x - transform.position.x) - 90);

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

			audioPlayer.Stop ();
			AudioSource.PlayClipAtPoint(explosion, transform.position);

			anim.enabled = true;
			anim.speed = explosionAnimSpeed;

			Destroy (gameObject, anim.GetCurrentAnimatorStateInfo(0).length / explosionAnimSpeed);
			Destroy (this);
		}
	}
}
