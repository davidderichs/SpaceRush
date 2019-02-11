using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_Shield_Indicator : HUD_Indicator {

	override public void Awake (){
		// Debug.Log("Initializing HUD_Shield_Indicator");
		this.initColors();
		this.maxValue = 5;
		this.item_List = new List<KeyValuePair<int, GameObject>>();
		this.itemNameClass = "HUD_Shield_Item_";
		this.useSprite = false;
		this.spritePath = "";
		this.initItems();
	}
	
	override public void initColors(){
		this.color_active = new Color32(54,161,202,255);
		this.color_inactive = new Color32(54,161,202,50);
	}
}
