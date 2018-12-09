using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Main_Fuel_Indicator : HUD_Component_Template {

	override public void Awake (){
		// Debug.Log("Initializing HUD_Fuel_Indicator");
		this.initColors();
		this.maxValue = 5;
		this.item_List = new List<KeyValuePair<int, GameObject>>();
		this.itemNameClass = "HUD_Main_Fuel_Item_";
		this.useSprite = true;
		this.spritePath = "Sprites/TankIndicator_Item_Image";
		this.initItems();
	}
	
	override public void initColors(){
		this.color_active = new Color32(255, 23, 0, 255);
		this.color_inactive = new Color32(204, 32, 1, 109);
	}
}