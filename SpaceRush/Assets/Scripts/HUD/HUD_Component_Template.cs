using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class HUD_Component_Template : MonoBehaviour {

	public List<KeyValuePair<int,GameObject>>  item_List;

	public Color color_active;
	public Color color_inactive;

	public string itemNameClass;

	public int maxValue;

	public bool useSprite;
	public string spritePath;


	public abstract void Awake ();

	public abstract void initColors();


	public void set_ActiveItemsColor(int activeItems){

		if (activeItems < 0) activeItems = 0;
		if (activeItems > maxValue) activeItems = maxValue;

		foreach(KeyValuePair<int, GameObject> entry in this.item_List){
			if (entry.Key <= activeItems){
				entry.Value.GetComponent<Image>().color = this.color_active;
			} else {
				entry.Value.GetComponent<Image>().color = this.color_inactive;
			}
		}
	}

	public void initItems(){
		// Debug.Log("Initialising Items in Template");
		// Debug.Log("MaxValue: " + maxValue);
		for (int i=1; i<=maxValue; i++){
			GameObject runtime_GameObject = GameObject.Find(this.itemNameClass + i);

			Image image = runtime_GameObject.AddComponent<Image>();

			if(useSprite) addSpriteToImage(image);

			setImageColor(image, this.color_inactive);

			KeyValuePair<int, GameObject> new_KeyValuePair_GameObject = new KeyValuePair<int, GameObject>(i,runtime_GameObject);
			this.item_List.Add(new_KeyValuePair_GameObject);
		}
	}

	public void addSpriteToImage(Image image){		
		image.sprite = Resources.Load <Sprite>(this.spritePath);
	}

	public void setImageColor (Image image, Color32 color){
		image.color = color;
	}



	public void fillUp(){
		this.set_ActiveItemsColor(maxValue);
	}
}
