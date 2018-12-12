using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spacecraft : MonoBehaviour {
	private SpacecraftController spacecraftControl;
	private Movements move;
	public Player play;
	
	void Start() {
		gameObject.AddComponent<SpacecraftController>();
		spacecraftControl = GetComponent<SpacecraftController>();
		gameObject.AddComponent<Movements>();
		move = GetComponent<Movements>();
		spacecraftControl.angularSpeed = 10;
		spacecraftControl.boostBackwardsForce = 100;
		spacecraftControl.boostForwardsForce = 100;
	}
}
