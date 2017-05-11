using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLowDamageImmune : EnemyController {

	[SerializeField] private int damageImmunity = 2;

	public new void TakeDamage (int damage) {

		if(damage > damageImmunity){
			base.TakeDamage (damage - 2);
		}
	}
}
