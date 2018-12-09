using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour {

	public HUD_Live_Indicator live;
	public HUD_Shield_Indicator shield;
	public HUD_Main_Fuel_Indicator main_fuel;
	public HUD_Additional_Fuel_Indicator add_fuel;
	public HUD_Selected_Movements selected_movements;

	// Use this for initialization
	void Start () {
		this.live = GameObject.Find("HUD_Live_Indicator").GetComponent<HUD_Live_Indicator>();
		this.main_fuel = GameObject.Find("HUD_Main_Fuel_Indicator").GetComponent<HUD_Main_Fuel_Indicator>();
		this.add_fuel = GameObject.Find("HUD_Additional_Fuel_Indicator").GetComponent<HUD_Additional_Fuel_Indicator>();
		this.shield = GameObject.Find("HUD_Shield_Indicator").GetComponent<HUD_Shield_Indicator>();
		this.selected_movements = GameObject.Find("HUD_Selected_Movements").GetComponent<HUD_Selected_Movements>();
	}
	
	// Update is called once per frame
	void Update () { 
		
	}
}
