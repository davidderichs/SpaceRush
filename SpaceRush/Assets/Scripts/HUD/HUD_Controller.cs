using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_Controller : MonoBehaviour {

	HUD_Live_Indicator liveIndicator;

	// Use this for initialization
	void Start () {
		liveIndicator = gameObject.AddComponent(typeof(HUD_Live_Indicator)) as HUD_Live_Indicator;
	}
	
	// Update is called once per frame
	void Update () { 
		
	}
}
