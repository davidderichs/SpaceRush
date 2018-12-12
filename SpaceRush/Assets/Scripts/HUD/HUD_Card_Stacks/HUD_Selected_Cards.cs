using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Selected_Cards : MonoBehaviour {

	string cardImageNamePrefix = "HUD_Move_CardImage_";
	string cardTextNamePrefix = "HUD_Move_Text_";

	void Awake(){

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void set_MoveCards(MoveCards movecards){

		this.reset_moveCards();

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

	private void reset_moveCards(){
		Debug.Log("Resetting Images and Texts");
		for (int i=1; i<=5; i++){
			GameObject moveImage = GameObject.Find(this.cardImageNamePrefix + i);
			Destroy(moveImage.GetComponent<Image>());
			GameObject moveText = GameObject.Find(this.cardTextNamePrefix + i);
			Destroy(moveText.GetComponent<Text>());
		}
	}

	public void setImageColor (Image image, Color32 color){
		image.color = color;
	}

	public void addSpriteToImage(Image image, string spritePath){		
		image.sprite = Resources.Load <Sprite>(spritePath);
	}
}
