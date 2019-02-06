using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkLight : MonoBehaviour {

	private double counter;
	public double lightPhase;
	public double offPhase;
	public float intensity;
	private bool on;
	private Light light;
	// Use this for initialization
	void Start () {
		light = GetComponent<Light>();
		counter = 0;
		light.intensity = 0;
		on = false;
	}
	
	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime;
		if(on && counter >= lightPhase) {
			light.intensity = 0;
			on = false;
			counter = 0;
		} else if(!on && counter >= offPhase) {
			light.intensity = intensity;
			on = true;
			counter = 0;
		}
	}
}
