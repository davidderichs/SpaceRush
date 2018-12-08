using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_Additional_Fuel_Indicator : HUD_Component_Template {

	override public void Awake (){
		Debug.Log("Initializing HUD_Additional_Fuel_Indicator");
		this.initColors();
		this.maxValue = 5;
		this.item_List = new List<KeyValuePair<int, GameObject>>();
		this.itemNameClass = "HUD_Add_Fuel_Item_";
		this.useSprite = true;
		this.spritePath = "Sprites/TankIndicator_Item_Image";
		this.initItems();
	}
	
	override public void initColors(){
		this.color_active = new Color32(9, 96, 166, 255);
		this.color_inactive = new Color32(34, 151, 245, 48);
	}
}
