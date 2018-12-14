using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HUD_Card_Stack : MonoBehaviour {

	string cardImageNamePrefix = "HUD_Available_Move_CardImage_";
	string cardTextNamePrefix = "HUD_Available_Move_Text_";

	Button[] available_moves;
	MoveCards moveCards;

	private UnityAction HUD_Listener;

	void Awake(){		
		// this.HUD_Listener = new UnityAction(delegate {EventManager.TriggerEvent("HUD_Card_Selected");});
        // EventManager.StartListening ("HUD_Card_Selected", HUD_Listener);
	}

	// Use this for initialization
	void Start () {	
		available_moves = new Button[15];
	}

	void setOnClickListeners(){
		for(int i=0; i<moveCards.size(); i++){
			// available_moves[i] = GameObject.Find("HUD_Available_Move_" + (i+1)).GetComponent<Button>();
			// available_moves[i].onClick.AddListener(this.HUD_Listener);
		}
	}

	void card_selected(int id){
		Debug.Log("Available Move Clicked with index: " + id);
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
