using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Card_Stack : MonoBehaviour {

	string cardImageNamePrefix = "HUD_Available_Move_CardImage_";
	string cardTextNamePrefix = "HUD_Available_Move_Text_";

	void Awake(){

	}

	// Use this for initialization
	void Start () {	
	}

	void setOnClickListeners(){
		for(int i=0; i<GameObject.Find("Player").GetComponent<Player>().card_Stack.size(); i++){
			Button HUD_clickable_Card = GameObject.Find("HUD_Available_Move_" + (i)).GetComponent<Button>();
			switch (i){
				case 0:
					HUD_clickable_Card.onClick.AddListener(delegate {
						Debug.Log("HUD_Stack_Card Clicked");
					});
					break;
				case 1:
					HUD_clickable_Card.onClick.AddListener(delegate {
						Debug.Log("HUD_Stack_Card Clicked");
					});
					break;
				case 2:
					HUD_clickable_Card.onClick.AddListener(delegate {
						Debug.Log("HUD_Stack_Card Clicked");
					});
					break;
				case 3:
					HUD_clickable_Card.onClick.AddListener(delegate {
						Debug.Log("HUD_Stack_Card Clicked");
					});
					break;
				case 4:
					HUD_clickable_Card.onClick.AddListener(delegate {
						Debug.Log("HUD_Stack_Card Clicked");
					});
					break;
				case 5:
					HUD_clickable_Card.onClick.AddListener(delegate {
						Debug.Log("HUD_Stack_Card Clicked");
					});
					break;
				case 6:
					HUD_clickable_Card.onClick.AddListener(delegate {
						Debug.Log("HUD_Stack_Card Clicked");
					});
					break;
				case 7:
					HUD_clickable_Card.onClick.AddListener(delegate {
						Debug.Log("HUD_Stack_Card Clicked");
					});
					break;
				case 8:
					HUD_clickable_Card.onClick.AddListener(delegate{
						Debug.Log("HUD_Stack_Card Clicked");
					});
					break;
				case 9:
					HUD_clickable_Card.onClick.AddListener(delegate {
						Debug.Log("HUD_Stack_Card Clicked");
					});
					break;
				case 10:
					HUD_clickable_Card.onClick.AddListener(delegate {
						Debug.Log("HUD_Stack_Card Clicked");
					});
					break;
				case 11:
					HUD_clickable_Card.onClick.AddListener(delegate {
						Debug.Log("HUD_Stack_Card Clicked");
					});
					break;
				case 12:
					HUD_clickable_Card.onClick.AddListener(delegate {
						Debug.Log("HUD_Stack_Card Clicked");
					});
					break;
				case 13:
					HUD_clickable_Card.onClick.AddListener(delegate {
						Debug.Log("HUD_Stack_Card Clicked");
					});
					break;
				case 14:
					HUD_clickable_Card.onClick.AddListener(delegate {
						Debug.Log("HUD_Stack_Card Clicked");
					});
					break;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
	private void reset_moveCards(){
		if(GameObject.Find("Player").GetComponent<Player>().card_Stack != null){
			for (int i=0; i<GameObject.Find("Player").GetComponent<Player>().card_Stack.size(); i++){
				GameObject cardImage = GameObject.Find(this.cardImageNamePrefix + i);
				Destroy(cardImage.GetComponent<Image>());
				GameObject cardText = GameObject.Find(this.cardTextNamePrefix + i);
				Destroy(cardText.GetComponent<Text>());
			}
		}
	}

	public void set_MoveCards_FromPlayer(){
		reset_moveCards();

		for (int i=0; i<GameObject.Find("Player").GetComponent<Player>().card_Stack.size(); i++){

			MoveCard currentCard = GameObject.Find("Player").GetComponent<Player>().card_Stack.get_MoveCard(i);

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
	public void set_MoveCards(MoveCards movecards){

		reset_moveCards();

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

		setOnClickListeners();
	}		

	public void setImageColor (Image image, Color32 color){
		image.color = color;
	}

	public void addSpriteToImage(Image image, string spritePath){		
		image.sprite = Resources.Load <Sprite>(spritePath);
	}
}