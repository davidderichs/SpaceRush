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
			Debug.Log("Setting up Listeners in HUD_Card_Stack");
			Button HUD_clickable_Card = GameObject.Find("HUD_Available_Move_" + (i)).GetComponent<Button>();
			switch (i){
				case 0:
					HUD_clickable_Card.onClick.AddListener(delegate {
						GameObject.Find("Player").GetComponent<Player>().card_Stack.card_List.RemoveAt(0);
						Debug.Log("HUD_Stack_Card Clicked with id: 0");
					});
					break;
				case 1:
					HUD_clickable_Card.onClick.AddListener(delegate {
						GameObject.Find("Player").GetComponent<Player>().card_Stack.remove_MoveCard_With_Index(1);
						Debug.Log("HUD_Stack_Card Clicked with id: 1");
					});
					break;
				case 2:
					HUD_clickable_Card.onClick.AddListener(delegate {
						GameObject.Find("Player").GetComponent<Player>().card_Stack.remove_MoveCard_With_Index(2);
						Debug.Log("HUD_Stack_Card Clicked with id: 2");
					});
					break;
				case 3:
					HUD_clickable_Card.onClick.AddListener(delegate {
						GameObject.Find("Player").GetComponent<Player>().card_Stack.remove_MoveCard_With_Index(3);
						Debug.Log("HUD_Stack_Card Clicked with id: 3");
					});
					break;
				case 4:
					HUD_clickable_Card.onClick.AddListener(delegate {
						GameObject.Find("Player").GetComponent<Player>().card_Stack.remove_MoveCard_With_Index(4);
						Debug.Log("HUD_Stack_Card Clicked with id: 4");
					});
					break;
				case 5:
					HUD_clickable_Card.onClick.AddListener(delegate {
						GameObject.Find("Player").GetComponent<Player>().card_Stack.remove_MoveCard_With_Index(5);
						Debug.Log("HUD_Stack_Card Clicked with id: 5");
					});
					break;
				case 6:
					HUD_clickable_Card.onClick.AddListener(delegate {
						GameObject.Find("Player").GetComponent<Player>().card_Stack.remove_MoveCard_With_Index(6);
						Debug.Log("HUD_Stack_Card Clicked with id: 6");
					});
					break;
				case 7:
					HUD_clickable_Card.onClick.AddListener(delegate {
						GameObject.Find("Player").GetComponent<Player>().card_Stack.remove_MoveCard_With_Index(7);
						Debug.Log("HUD_Stack_Card Clicked with id: 7");
					});
					break;
				case 8:
					HUD_clickable_Card.onClick.AddListener(delegate{
						GameObject.Find("Player").GetComponent<Player>().card_Stack.remove_MoveCard_With_Index(8);
						Debug.Log("HUD_Stack_Card Clicked with id: 8");
					});
					break;
				case 9:
					HUD_clickable_Card.onClick.AddListener(delegate {
						GameObject.Find("Player").GetComponent<Player>().card_Stack.remove_MoveCard_With_Index(9);
						Debug.Log("HUD_Stack_Card Clicked with id: 9");
					});
					break;
				case 10:
					HUD_clickable_Card.onClick.AddListener(delegate {
						GameObject.Find("Player").GetComponent<Player>().card_Stack.remove_MoveCard_With_Index(10);
						Debug.Log("HUD_Stack_Card Clicked with id: 10");
					});
					break;
				case 11:
					HUD_clickable_Card.onClick.AddListener(delegate {
						GameObject.Find("Player").GetComponent<Player>().card_Stack.remove_MoveCard_With_Index(11);
						Debug.Log("HUD_Stack_Card Clicked with id: 11");
					});
					break;
				case 12:
					HUD_clickable_Card.onClick.AddListener(delegate {
						GameObject.Find("Player").GetComponent<Player>().card_Stack.remove_MoveCard_With_Index(12);
						Debug.Log("HUD_Stack_Card Clicked with id: 12");
					});
					break;
				case 13:
					HUD_clickable_Card.onClick.AddListener(delegate {
						GameObject.Find("Player").GetComponent<Player>().card_Stack.remove_MoveCard_With_Index(13);
						Debug.Log("HUD_Stack_Card Clicked with id: 13");
					});
					break;
				case 14:
					HUD_clickable_Card.onClick.AddListener(delegate {
						GameObject.Find("Player").GetComponent<Player>().card_Stack.remove_MoveCard_With_Index(14);
						Debug.Log("HUD_Stack_Card Clicked with id: 14");
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