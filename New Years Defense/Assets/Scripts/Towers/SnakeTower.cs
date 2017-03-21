using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTower : Tower, AttackSpeedIncreasable {

	[SerializeField] private float rotationAngleSec = 360f;
	private float rotationRateIncrease;

	void FixedUpdate () {
		transform.RotateAround (transform.position, Vector3.forward, GetFiringRate () * Time.fixedDeltaTime);
	}

	public void IncreaseFiringRate (float rate) {
		rotationRateIncrease = Mathf.Clamp01 (rotationRateIncrease + rate);
	}

	public void DecreaseFiringRate (float rate) {
		rotationRateIncrease = Mathf.Clamp01 (rotationRateIncrease - rate);
	}

	public float GetFiringRate () { 
		return rotationAngleSec + (rotationRateIncrease * rotationAngleSec); 
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.CompareTag ("Enemy")) {
			other.GetComponent<EnemyController> ().TakeDamage (GetDamage ());
		}
	}
}
