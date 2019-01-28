﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	public HUD_Indicator live;
	public HUD_Indicator weapons;
	public HUD_Indicator items;
	public HUD_Indicator shield;
	public HUD_Indicator main_fuel;
	public HUD_Indicator add_fuel;
	public HUD_Selected_Cards selected_cards;
	public HUD_Card_Stack card_stack;

	public Button HUD_Button_Ready;

	public bool hud_visible;

	private Vector3[] hud_Children_Rect_Positions;


	void Awake(){
		
	}
	// Use this for initialization
	void Start () {
		this.weapons = GameObject.Find("HUD_Weapons_Indicator").GetComponent<HUD_Weapons_Indicator>();
		this.items = GameObject.Find("HUD_Items_Indicator").GetComponent<HUD_Items_Indicator>();

		this.live = GameObject.Find("HUD_Live_Indicator").GetComponent<HUD_Live_Indicator>();
		this.main_fuel = GameObject.Find("HUD_Main_Fuel_Indicator").GetComponent<HUD_Main_Fuel_Indicator>();
		this.add_fuel = GameObject.Find("HUD_Additional_Fuel_Indicator").GetComponent<HUD_Additional_Fuel_Indicator>();
		this.shield = GameObject.Find("HUD_Shield_Indicator").GetComponent<HUD_Shield_Indicator>();
		this.selected_cards = GameObject.Find("HUD_Selected_Cards").GetComponent<HUD_Selected_Cards>();
		this.card_stack = GameObject.Find("HUD_Card_Stack").GetComponent<HUD_Card_Stack>();
		this.HUD_Button_Ready = GameObject.Find("HUD_Button_Ready").GetComponent<Button>();
		this.hud_visible = true;
	}

	public void hide(){
		Debug.Log("Hinding HUD");
		this.GetComponent<Canvas>().enabled = false;
	}

	public void show(){
		Debug.Log("Showing HUD");
		this.GetComponent<Canvas>().enabled = true;
	}

	public void setHUDColor(Color32 newColor){
		this.live.GetComponent<Image>().color = newColor;
		this.shield.GetComponent<Image>().color = newColor;
		this.selected_cards.GetComponent<Image>().color =newColor;
		this.weapons.GetComponent<Image>().color = newColor;
		this.items.GetComponent<Image>().color = newColor;
	}

	public void activate_Ready_Button(){

		this.HUD_Button_Ready.onClick.RemoveAllListeners();

		if(this.HUD_Button_Ready.GetComponent<Button>().IsActive()){
			this.HUD_Button_Ready.GetComponent<Image>().color = new Color32(0,255,0,255);
			this.HUD_Button_Ready.GetComponentInChildren<Text>().color = new Color32(255, 255, 255, 255);
		} else {
			this.HUD_Button_Ready.GetComponent<Image>().color = new Color32(84,111,84,255);
			this.HUD_Button_Ready.GetComponentInChildren<Text>().color = new Color32(255, 255, 255, 100);
		}

		this.HUD_Button_Ready.onClick.AddListener(delegate {
			EventManager.TriggerEvent("HUD_Player_is_ready");
		});
	}
	public void deactivate_Ready_Button(){
		this.HUD_Button_Ready.onClick.RemoveAllListeners();
		this.HUD_Button_Ready.GetComponent<Image>().color = new Color32(0,0,0,0);
		this.HUD_Button_Ready.GetComponentInChildren<Text>().color = new Color32(0,0,0,0);
	}


	
	// Update is called once per frame
	void Update () { 
	}
}
