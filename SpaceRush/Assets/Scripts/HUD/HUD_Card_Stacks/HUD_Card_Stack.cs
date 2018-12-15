using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Card_Stack : MonoBehaviour {

	string cardImageNamePrefix = "HUD_Available_Move_CardImage_";
	string cardTextNamePrefix = "HUD_Available_Move_Text_";

	int m_card_stack_size;

	void Awake(){

	}

	// Use this for initialization
	void Start () {	
	}

	void setOnClickListeners(){	

		for(int i=0; i<GameObject.Find("Player").GetComponent<Player>().card_Stack.size(); i++){
			// Debug.Log("Setting up Listeners in HUD_Card_Stack");
			Button HUD_clickable_Card = GameObject.Find("HUD_Available_Move_" + (i)).GetComponent<Button>();
			switch (i){
				case 0:					
					HUD_clickable_Card.onClick.AddListener(delegate {
						if(GameObject.Find("Player").GetComponent<Player>().card_Selection.size() < 5){
							EventManager.TriggerEvent("HUD_Card_Stack_Item_Selected");
							GameObject.Find("Player").GetComponent<Player>().card_Selection.add_MoveCard(
								GameObject.Find("Player").GetComponent<Player>().card_Stack.get_MoveCard(0)
							);
							GameObject.Find("Player").GetComponent<Player>().card_Stack.remove_MoveCard_With_Index(0);
							// Debug.Log("HUD_Stack_Card Clicked with id: 0");
						} else {
							EventManager.TriggerEvent("HUD_Card_Selection_Impossible");
						}
					});
					break;
				case 1:
					HUD_clickable_Card.onClick.AddListener(delegate {
						if(GameObject.Find("Player").GetComponent<Player>().card_Selection.size() < 5){
							EventManager.TriggerEvent("HUD_Card_Stack_Item_Selected");
							GameObject.Find("Player").GetComponent<Player>().card_Selection.add_MoveCard(
								GameObject.Find("Player").GetComponent<Player>().card_Stack.get_MoveCard(1)
							);
							GameObject.Find("Player").GetComponent<Player>().card_Stack.remove_MoveCard_With_Index(1);
							// Debug.Log("HUD_Stack_Card Clicked with id: 1");
						} else {
							EventManager.TriggerEvent("HUD_Card_Selection_Impossible");
						}
					});
					break;
				case 2:
					HUD_clickable_Card.onClick.AddListener(delegate {
						if(GameObject.Find("Player").GetComponent<Player>().card_Selection.size() < 5){
							EventManager.TriggerEvent("HUD_Card_Stack_Item_Selected");
							GameObject.Find("Player").GetComponent<Player>().card_Selection.add_MoveCard(
								GameObject.Find("Player").GetComponent<Player>().card_Stack.get_MoveCard(2)
							);
							GameObject.Find("Player").GetComponent<Player>().card_Stack.remove_MoveCard_With_Index(2);
							// Debug.Log("HUD_Stack_Card Clicked with id: 2");
						} else {
							EventManager.TriggerEvent("HUD_Card_Selection_Impossible");
						}
					});
					break;
				case 3:
					HUD_clickable_Card.onClick.AddListener(delegate {
						if(GameObject.Find("Player").GetComponent<Player>().card_Selection.size() < 5){
							EventManager.TriggerEvent("HUD_Card_Stack_Item_Selected");
							GameObject.Find("Player").GetComponent<Player>().card_Selection.add_MoveCard(
								GameObject.Find("Player").GetComponent<Player>().card_Stack.get_MoveCard(3)
							);
							GameObject.Find("Player").GetComponent<Player>().card_Stack.remove_MoveCard_With_Index(3);
							// Debug.Log("HUD_Stack_Card Clicked with id: 3");
						} else {
							EventManager.TriggerEvent("HUD_Card_Selection_Impossible");
						}
					});
					break;
				case 4:
					HUD_clickable_Card.onClick.AddListener(delegate {
						if(GameObject.Find("Player").GetComponent<Player>().card_Selection.size() < 5){
							EventManager.TriggerEvent("HUD_Card_Stack_Item_Selected");
							GameObject.Find("Player").GetComponent<Player>().card_Selection.add_MoveCard(
								GameObject.Find("Player").GetComponent<Player>().card_Stack.get_MoveCard(4)
							);
							GameObject.Find("Player").GetComponent<Player>().card_Stack.remove_MoveCard_With_Index(4);
							// Debug.Log("HUD_Stack_Card Clicked with id: 4");
						} else {
							EventManager.TriggerEvent("HUD_Card_Selection_Impossible");
						}
					});
					break;
				case 5:
					HUD_clickable_Card.onClick.AddListener(delegate {
						if(GameObject.Find("Player").GetComponent<Player>().card_Selection.size() < 5){
							EventManager.TriggerEvent("HUD_Card_Stack_Item_Selected");
							GameObject.Find("Player").GetComponent<Player>().card_Selection.add_MoveCard(
								GameObject.Find("Player").GetComponent<Player>().card_Stack.get_MoveCard(5)
							);
							GameObject.Find("Player").GetComponent<Player>().card_Stack.remove_MoveCard_With_Index(5);
							// Debug.Log("HUD_Stack_Card Clicked with id: 5");
						} else {
							EventManager.TriggerEvent("HUD_Card_Selection_Impossible");
						}
					});
					break;
				case 6:
					HUD_clickable_Card.onClick.AddListener(delegate {
						if(GameObject.Find("Player").GetComponent<Player>().card_Selection.size() < 5){
							EventManager.TriggerEvent("HUD_Card_Stack_Item_Selected");
							GameObject.Find("Player").GetComponent<Player>().card_Selection.add_MoveCard(
								GameObject.Find("Player").GetComponent<Player>().card_Stack.get_MoveCard(6)
							);
							GameObject.Find("Player").GetComponent<Player>().card_Stack.remove_MoveCard_With_Index(6);
							// Debug.Log("HUD_Stack_Card Clicked with id: 6");
						} else {
							EventManager.TriggerEvent("HUD_Card_Selection_Impossible");
						}
					});
					break;
				case 7:
					HUD_clickable_Card.onClick.AddListener(delegate {
						if(GameObject.Find("Player").GetComponent<Player>().card_Selection.size() < 5){
							EventManager.TriggerEvent("HUD_Card_Stack_Item_Selected");
							GameObject.Find("Player").GetComponent<Player>().card_Selection.add_MoveCard(
								GameObject.Find("Player").GetComponent<Player>().card_Stack.get_MoveCard(7)
							);
							GameObject.Find("Player").GetComponent<Player>().card_Stack.remove_MoveCard_With_Index(7);
							// Debug.Log("HUD_Stack_Card Clicked with id: 7");
						} else {
							EventManager.TriggerEvent("HUD_Card_Selection_Impossible");
						}
					});
					break;
				case 8:
					HUD_clickable_Card.onClick.AddListener(delegate{
						if(GameObject.Find("Player").GetComponent<Player>().card_Selection.size() < 5){
							EventManager.TriggerEvent("HUD_Card_Stack_Item_Selected");
							GameObject.Find("Player").GetComponent<Player>().card_Selection.add_MoveCard(
								GameObject.Find("Player").GetComponent<Player>().card_Stack.get_MoveCard(8)
							);
							GameObject.Find("Player").GetComponent<Player>().card_Stack.remove_MoveCard_With_Index(8);
							// Debug.Log("HUD_Stack_Card Clicked with id: 8");
						} else {
							EventManager.TriggerEvent("HUD_Card_Selection_Impossible");
						}
					});
					break;
				case 9:
					HUD_clickable_Card.onClick.AddListener(delegate {
						if(GameObject.Find("Player").GetComponent<Player>().card_Selection.size() < 5){
							EventManager.TriggerEvent("HUD_Card_Stack_Item_Selected");
							GameObject.Find("Player").GetComponent<Player>().card_Selection.add_MoveCard(
								GameObject.Find("Player").GetComponent<Player>().card_Stack.get_MoveCard(9)
							);
							GameObject.Find("Player").GetComponent<Player>().card_Stack.remove_MoveCard_With_Index(9);
							// Debug.Log("HUD_Stack_Card Clicked with id: 9");
						} else {
							EventManager.TriggerEvent("HUD_Card_Selection_Impossible");
						}
					});
					break;
				case 10:
					HUD_clickable_Card.onClick.AddListener(delegate {
						if(GameObject.Find("Player").GetComponent<Player>().card_Selection.size() < 5){
							EventManager.TriggerEvent("HUD_Card_Stack_Item_Selected");
							GameObject.Find("Player").GetComponent<Player>().card_Selection.add_MoveCard(
								GameObject.Find("Player").GetComponent<Player>().card_Stack.get_MoveCard(10)
							);
							GameObject.Find("Player").GetComponent<Player>().card_Stack.remove_MoveCard_With_Index(10);
							// Debug.Log("HUD_Stack_Card Clicked with id: 10");
						} else {
							EventManager.TriggerEvent("HUD_Card_Selection_Impossible");
						}
					});
					break;
				case 11:
					HUD_clickable_Card.onClick.AddListener(delegate {
						if(GameObject.Find("Player").GetComponent<Player>().card_Selection.size() < 5){
							EventManager.TriggerEvent("HUD_Card_Stack_Item_Selected");
							GameObject.Find("Player").GetComponent<Player>().card_Selection.add_MoveCard(
								GameObject.Find("Player").GetComponent<Player>().card_Stack.get_MoveCard(11)
							);
							GameObject.Find("Player").GetComponent<Player>().card_Stack.remove_MoveCard_With_Index(11);
							// Debug.Log("HUD_Stack_Card Clicked with id: 11");
						} else {
							EventManager.TriggerEvent("HUD_Card_Selection_Impossible");
						}
					});
					break;
				case 12:
					HUD_clickable_Card.onClick.AddListener(delegate {
						if(GameObject.Find("Player").GetComponent<Player>().card_Selection.size() < 5){
							EventManager.TriggerEvent("HUD_Card_Stack_Item_Selected");
							GameObject.Find("Player").GetComponent<Player>().card_Selection.add_MoveCard(
								GameObject.Find("Player").GetComponent<Player>().card_Stack.get_MoveCard(12)
							);
							GameObject.Find("Player").GetComponent<Player>().card_Stack.remove_MoveCard_With_Index(12);
							// Debug.Log("HUD_Stack_Card Clicked with id: 12");
						} else {
							EventManager.TriggerEvent("HUD_Card_Selection_Impossible");
						}
					});
					break;
				case 13:
					HUD_clickable_Card.onClick.AddListener(delegate {
						if(GameObject.Find("Player").GetComponent<Player>().card_Selection.size() < 5){
							EventManager.TriggerEvent("HUD_Card_Stack_Item_Selected");
							GameObject.Find("Player").GetComponent<Player>().card_Selection.add_MoveCard(
								GameObject.Find("Player").GetComponent<Player>().card_Stack.get_MoveCard(13)
							);
							GameObject.Find("Player").GetComponent<Player>().card_Stack.remove_MoveCard_With_Index(13);
							// Debug.Log("HUD_Stack_Card Clicked with id: 13");
						} else {
							EventManager.TriggerEvent("HUD_Card_Selection_Impossible");
						}
					});
					break;
				case 14:
					HUD_clickable_Card.onClick.AddListener(delegate {
						if(GameObject.Find("Player").GetComponent<Player>().card_Selection.size() < 5){
							EventManager.TriggerEvent("HUD_Card_Stack_Item_Selected");
							GameObject.Find("Player").GetComponent<Player>().card_Selection.add_MoveCard(
								GameObject.Find("Player").GetComponent<Player>().card_Stack.get_MoveCard(14)
							);
							GameObject.Find("Player").GetComponent<Player>().card_Stack.remove_MoveCard_With_Index(14);
							// Debug.Log("HUD_Stack_Card Clicked with id: 14");
						} else {
							EventManager.TriggerEvent("HUD_Card_Selection_Impossible");
						}
					});
					break;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
	private void reset_moveCards(){
		for (int i=0; i<m_card_stack_size; i++){
			GameObject.Find(this.cardImageNamePrefix + i).GetComponent<Image>().sprite = Resources.Load <Sprite>("Sprites/empty");
			GameObject.Find(this.cardTextNamePrefix + i).GetComponent<Text>().text = "";	
			GameObject.Find("HUD_Available_Move_" + (i)).GetComponent<Button>().onClick.RemoveAllListeners();		
		}		
	}

	public void set_MoveCards(MoveCards movecards){

		reset_moveCards();

		m_card_stack_size = movecards.size();

		for (int i=0; i<movecards.size(); i++){

			MoveCard currentCard = movecards.get_MoveCard(i);


			GameObject moveImage = GameObject.Find(this.cardImageNamePrefix + i);

			Image image;
			if (moveImage.GetComponent<Image>() == null){
				moveImage.AddComponent<Image>();
			}	
			image = moveImage.GetComponent<Image>();	

			if(currentCard.useSprite) {
				addSpriteToImage(image, currentCard.spritePath + currentCard.direction);
			}
			setImageColor(image, currentCard.color);

			GameObject moveText = GameObject.Find(this.cardTextNamePrefix + i);

			Text textComponent;
			if(moveText.GetComponent<Text>() == null){
				moveText.AddComponent<Text>();
			}
			textComponent = moveText.GetComponent<Text>();
			
			textComponent.text =  currentCard.intensity.ToString();
			textComponent.alignment = TextAnchor.MiddleCenter;
			textComponent.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
			textComponent.fontSize = 40;
		}

		setOnClickListeners();
	}		

	public void setImageColor (Image image, Color32 color){
		image.color = color;
	}

	public void addSpriteToImage(Image image, string spritePath){		
		image.sprite = Resources.Load <Sprite>(spritePath);
	}
}