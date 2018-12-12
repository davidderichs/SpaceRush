using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Available_Movements : MonoBehaviour {

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
			available_moves[i] = GameObject.Find("HUD_Available_Move_" + (i+1)).GetComponent<Button>();
			switch (i){
				case 0:
					available_moves[i].onClick.AddListener(delegate {available_Move_Clicked(0);});
					break;
				case 1:
					available_moves[i].onClick.AddListener(delegate {available_Move_Clicked(2);});
					break;
				case 2:
					available_moves[i].onClick.AddListener(delegate {available_Move_Clicked(2);});
					break;
				case 3:
					available_moves[i].onClick.AddListener(delegate {available_Move_Clicked(3);});
					break;
				case 4:
					available_moves[i].onClick.AddListener(delegate {available_Move_Clicked(4);});
					break;
				case 5:
					available_moves[i].onClick.AddListener(delegate {available_Move_Clicked(5);});
					break;
				case 6:
					available_moves[i].onClick.AddListener(delegate {available_Move_Clicked(6);});
					break;
				case 7:
					available_moves[i].onClick.AddListener(delegate {available_Move_Clicked(7);});
					break;
				case 8:
					available_moves[i].onClick.AddListener(delegate {available_Move_Clicked(8);});
					break;
				case 9:
					available_moves[i].onClick.AddListener(delegate {available_Move_Clicked(9);});
					break;
				case 10:
					available_moves[i].onClick.AddListener(delegate {available_Move_Clicked(10);});
					break;
				case 11:
					available_moves[i].onClick.AddListener(delegate {available_Move_Clicked(11);});
					break;
				case 12:
					available_moves[i].onClick.AddListener(delegate {available_Move_Clicked(12);});
					break;
				case 13:
					available_moves[i].onClick.AddListener(delegate {available_Move_Clicked(13);});
					break;
				case 14:
					available_moves[i].onClick.AddListener(delegate {available_Move_Clicked(14);});
					break;
			}
		}
	}

	void available_Move_Clicked(int id){
		Debug.Log("Available Move Clicked with index: " + id);
		MoveCard clickedCard = this.moveCards.get_MoveCard(id);
		Player player = GameObject.Find("Player").GetComponent<Player>();
		if(player.card_Selection.size()<5){
			// player.card_Selection.add_MoveCard(clickedCard);			
			// this.reset_moveCards();
			// player.card_Stack.remove_MoveCard(clickedCard);
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
