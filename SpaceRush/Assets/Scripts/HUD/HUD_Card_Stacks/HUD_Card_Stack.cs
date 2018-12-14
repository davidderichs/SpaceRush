using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Card_Stack : MonoBehaviour {

	string cardImageNamePrefix = "HUD_Available_Move_CardImage_";
	string cardTextNamePrefix = "HUD_Available_Move_Text_";

	Button[] available_moves;
	MoveCards moveCards;

	void Awake(){

	}

	// Use this for initialization
	void Start () {	
		available_moves = new Button[15];
	}

	void setOnClickListeners(){
		for(int i=0; i<moveCards.size(); i++){
			available_moves[i] = GameObject.Find("HUD_Available_Move_" + (i)).GetComponent<Button>();
			switch (i){
				case 0:
					available_moves[i].onClick.AddListener(delegate {EventManager.TriggerEvent("HUD_Card_Stack_Item_0_Clicked", new EventInformation(0, "HUD_Card_Stack_Item"));});
					break;
				case 1:
					available_moves[i].onClick.AddListener(delegate {EventManager.TriggerEvent("HUD_Card_Stack_Item_1_Clicked", new EventInformation(1, "HUD_Card_Stack_Item"));});
					break;
				case 2:
					available_moves[i].onClick.AddListener(delegate {EventManager.TriggerEvent("HUD_Card_Stack_Item_2_Clicked", new EventInformation(2, "HUD_Card_Stack_Item"));});
					break;
				case 3:
					available_moves[i].onClick.AddListener(delegate {EventManager.TriggerEvent("HUD_Card_Stack_Item_3_Clicked", new EventInformation(3, "HUD_Card_Stack_Item"));});
					break;
				case 4:
					available_moves[i].onClick.AddListener(delegate {EventManager.TriggerEvent("HUD_Card_Stack_Item_4_Clicked", new EventInformation(4, "HUD_Card_Stack_Item"));});
					break;
				case 5:
					available_moves[i].onClick.AddListener(delegate {EventManager.TriggerEvent("HUD_Card_Stack_Item_5_Clicked", new EventInformation(5, "HUD_Card_Stack_Item"));});
					break;
				case 6:
					available_moves[i].onClick.AddListener(delegate {EventManager.TriggerEvent("HUD_Card_Stack_Item_6_Clicked", new EventInformation(6, "HUD_Card_Stack_Item"));});
					break;
				case 7:
					available_moves[i].onClick.AddListener(delegate {EventManager.TriggerEvent("HUD_Card_Stack_Item_7_Clicked", new EventInformation(7, "HUD_Card_Stack_Item"));});
					break;
				case 8:
					available_moves[i].onClick.AddListener(delegate {EventManager.TriggerEvent("HUD_Card_Stack_Item_8_Clicked", new EventInformation(8, "HUD_Card_Stack_Item"));});
					break;
				case 9:
					available_moves[i].onClick.AddListener(delegate {EventManager.TriggerEvent("HUD_Card_Stack_Item_9_Clicked", new EventInformation(9, "HUD_Card_Stack_Item"));});
					break;
				case 10:
					available_moves[i].onClick.AddListener(delegate {EventManager.TriggerEvent("HUD_Card_Stack_Item_10_Clicked", new EventInformation(10, "HUD_Card_Stack_Item"));});
					break;
				case 11:
					available_moves[i].onClick.AddListener(delegate {EventManager.TriggerEvent("HUD_Card_Stack_Item_11_Clicked", new EventInformation(11, "HUD_Card_Stack_Item"));});
					break;
				case 12:
					available_moves[i].onClick.AddListener(delegate {EventManager.TriggerEvent("HUD_Card_Stack_Item_12_Clicked", new EventInformation(12, "HUD_Card_Stack_Item"));});
					break;
				case 13:
					available_moves[i].onClick.AddListener(delegate {EventManager.TriggerEvent("HUD_Card_Stack_Item_13_Clicked", new EventInformation(13, "HUD_Card_Stack_Item"));});
					break;
				case 14:
					available_moves[i].onClick.AddListener(delegate {EventManager.TriggerEvent("HUD_Card_Stack_Item_14_Clicked", new EventInformation(14, "HUD_Card_Stack_Item"));});
					break;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void reset_moveCards(){
		for (int i=1; i<=this.moveCards.size(); i++){
			GameObject moveImage = GameObject.Find(this.cardImageNamePrefix + i);
			Destroy(moveImage.GetComponent<Image>());
			GameObject moveText = GameObject.Find(this.cardTextNamePrefix + i);
			Destroy(moveText.GetComponent<Text>());
		}
	}
	public void set_MoveCards(MoveCards movecards){

		this.moveCards = movecards;

		setOnClickListeners();

		for (int i=1; i<=movecards.size(); i++){

			MoveCard currentCard = movecards.get_MoveCard(i-1);

			GameObject moveImage = GameObject.Find(this.cardImageNamePrefix + i);

			Image image = moveImage.AddComponent<Image>();
			if(currentCard.useSprite) {
				addSpriteToImage(image, currentCard.spritePath + currentCard.direction);
			}
			setImageColor(image, currentCard.color);

			GameObject moveText = GameObject.Find(this.cardTextNamePrefix + i);
			Text textComponent = moveText.AddComponent<Text>();
			
			textComponent.text =  currentCard.intensity.ToString();
			textComponent.alignment = TextAnchor.MiddleCenter;
			textComponent.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
			textComponent.fontSize = 40;
		}
	}		

	public void setImageColor (Image image, Color32 color){
		image.color = color;
	}

	public void addSpriteToImage(Image image, string spritePath){		
		image.sprite = Resources.Load <Sprite>(spritePath);
	}
}