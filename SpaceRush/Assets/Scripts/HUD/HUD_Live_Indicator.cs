using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Live_Indicator : HUD_Component_Template {

	override public void Awake (){
		// Debug.Log("Initializing HUD_Live_Indicator");
		this.initColors();
		this.maxValue = 10;
		this.item_List = new List<KeyValuePair<int, GameObject>>();
		this.itemNameClass = "HUD_Live_Item_";
		this.useSprite = false;
		this.spritePath = "";
		this.initItems();
	}
	
	override public void initColors(){
		this.color_active = new Color32(0, 203, 34, 255);
		this.color_inactive = new Color32(0, 246, 27, 59);
	}
}
