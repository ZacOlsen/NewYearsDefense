using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface AttackSpeedIncreasable  {

	void IncreaseFiringRate (float rate);
	void DecreaseFiringRate (float rate);
	float GetFiringRate ();
}
