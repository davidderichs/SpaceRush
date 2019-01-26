﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_Weapons_Indicator : HUD_Indicator {

	// Use this for initialization
	override public void Awake (){
		// Debug.Log("Initializing HUD_Live_Indicator");
		this.initColors();
		this.maxValue = 2;
		this.item_List = new List<KeyValuePair<int, GameObject>>();
		this.itemNameClass = "HUD_Item_";
		this.useSprite = false;
		this.spritePath = "";
		this.initItems();
	}
	
	override public void initColors(){
		this.color_active = new Color32(0, 0, 0, 0);
		this.color_inactive = new Color32(0, 0, 0, 0);
	}
}
