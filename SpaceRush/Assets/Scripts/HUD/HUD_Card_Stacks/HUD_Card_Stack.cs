using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Card_Stack : MonoBehaviour
{/*

    string cardImageNamePrefix = "HUD_Available_Move_CardImage_";
    string cardTextNamePrefix = "HUD_Available_Move_Text_";

    public int playerNr;
    private Player player;
    int m_card_stack_size;

    void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {
        string playername = "Player" + playerNr;
        player = GameObject.Find(playername).GetComponent<Player>();
    }

    void setOnClickListeners()
    {

        for (int i = 0; i < player.card_Stack.size(); i++)
        {
            // Debug.Log("Setting up Listeners in HUD_Card_Stack");
            Button HUD_clickable_Card = GameObject.Find("HUD_Available_Move_" + (i)).GetComponent<Button>();
            HUD_clickable_Card.onClick.AddListener(delegate
            {
                EventManager.TriggerEvent("HUD_Card_Stack_Item_Selected");
                player.card_Selection.add_MoveCard(
                    player.card_Stack.get_MoveCard(i)
                );
                player.readyCounter(1);
                EventManager.TriggerEvent("Player_Card_Selection_Changed");
            });
        }

    }

    public void reset_moveCards()
    {
        for (int i = 0; i < m_card_stack_size; i++)
        {
            GameObject.Find(this.cardImageNamePrefix + i).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/empty");
            GameObject.Find(this.cardTextNamePrefix + i).GetComponent<Text>().text = "";
            GameObject.Find("HUD_Available_Move_" + (i)).GetComponent<Button>().onClick.RemoveAllListeners();
        }
        if (GameObject.Find("HUD_Weapon_1") != null)
        {
            GameObject.Find("HUD_Weapon_1").GetComponent<Button>().onClick.RemoveAllListeners();
        }

        if (GameObject.Find("HUD_Weapon_2") != null)
        {
            GameObject.Find("HUD_Weapon_2").GetComponent<Button>().onClick.RemoveAllListeners();
        }

    }

    public void set_MoveCards(MoveCards movecards)
    {

        reset_moveCards();

        m_card_stack_size = movecards.size();

        for (int i = 0; i < movecards.size(); i++)
        {

            MoveCard currentCard = movecards.get_MoveCard(i);


            GameObject moveImage = GameObject.Find(this.cardImageNamePrefix + i);

            Image image;
            if (moveImage.GetComponent<Image>() == null)
            {
                moveImage.AddComponent<Image>();
            }
            image = moveImage.GetComponent<Image>();

            if (currentCard.useSprite)
            {
                addSpriteToImage(image, currentCard.spritePath + currentCard.direction);
            }
            setImageColor(image, currentCard.color);

            GameObject actionText = GameObject.Find(this.cardTextNamePrefix + i);

            Text textComponent;
            if (actionText.GetComponent<Text>() == null)
            {
                actionText.AddComponent<Text>();
            }
            textComponent = actionText.GetComponent<Text>();

            textComponent.text = currentCard.name;
            textComponent.alignment = TextAnchor.MiddleCenter;
            textComponent.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            textComponent.fontSize = 40;
        }

        setOnClickListeners();
    }

    private MoveCard createWeaponCard(string Name)
    {
        MoveCard weaponMove = new MoveCard("", 0, new Color(1, 1, 1, 1), true, "Sprites/", name, 2, 0);

        return weaponMove;
    }

    public void setImageColor(Image image, Color32 color)
    {
        image.color = color;
    }

    public void addSpriteToImage(Image image, string spritePath)
    {
        image.sprite = Resources.Load<Sprite>(spritePath);
    }

    public void hide()
    {
        reset_moveCards();
    }

    public void changePlayer(int playerNr)
    {
        string playername = "Player" + playerNr;
        player = GameObject.Find(playername).GetComponent<Player>();
    } */
}