using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Selected_Cards : MonoBehaviour
{

    string cardImageNamePrefix = "HUD_Move_CardImage_";
    string cardTextNamePrefix = "HUD_Move_Text_";

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

    // Update is called once per frame
    void Update()
    {

    }

    void setOnClickListeners()
    {

        for (int i = 0; i < player.card_Selection.size(); i++)
        {
            // Debug.Log("Setting up Listeners in HUD_Card_Selection");
            Button HUD_clickable_Card = GameObject.Find("HUD_Selected_Move_" + (i)).GetComponent<Button>();
            switch (i)
            {
                case 0:
                    HUD_clickable_Card.onClick.AddListener(delegate
                    {
                        /* player.card_Stack.add_MoveCard(
                            player.card_Selection.get_MoveCard(0)
                        );*/
                        player.card_Selection.remove_MoveCard_With_Index(0);
                        player.readyCounter(-1);
                        EventManager.TriggerEvent("HUD_Card_Stack_Item_Unselected");
                        EventManager.TriggerEvent("Player_Card_Selection_Changed");
                        // Debug.Log("HUD_Selected_Card Clicked with id: 0");
                    });

                    break;
                case 1:
                    {
                        HUD_clickable_Card.onClick.AddListener(delegate
                        {
                            /*player.card_Stack.add_MoveCard(
                                player.card_Selection.get_MoveCard(1)
                            );*/
                            player.card_Selection.remove_MoveCard_With_Index(1);
                            player.readyCounter(-1);
                            EventManager.TriggerEvent("HUD_Card_Stack_Item_Unselected");
                            EventManager.TriggerEvent("Player_Card_Selection_Changed");
                            // Debug.Log("HUD_Selected_Card Clicked with id: 1");
                        });

                        break;
                    }
                case 2:
                    {
                        HUD_clickable_Card.onClick.AddListener(delegate
                        {
                            /*player.card_Stack.add_MoveCard(
                                player.card_Selection.get_MoveCard(2)
                            );*/
                            player.card_Selection.remove_MoveCard_With_Index(2);
                            player.readyCounter(-1);
                            EventManager.TriggerEvent("HUD_Card_Stack_Item_Unselected");
                            EventManager.TriggerEvent("Player_Card_Selection_Changed");
                            // Debug.Log("HUD_Selected_Card Clicked with id: 2");
                        });
                    }
                    break;
                case 3:
                    {
                        HUD_clickable_Card.onClick.AddListener(delegate
                        {
                            /*player.card_Stack.add_MoveCard(
                                player.card_Selection.get_MoveCard(3)
                            );*/
                            player.card_Selection.remove_MoveCard_With_Index(3);
                            player.readyCounter(-1);
                            EventManager.TriggerEvent("HUD_Card_Stack_Item_Unselected");
                            EventManager.TriggerEvent("Player_Card_Selection_Changed");
                            // Debug.Log("HUD_Selected_Card Clicked with id: 3");
                        });
                    }
                    break;
                case 4:
                    {
                        HUD_clickable_Card.onClick.AddListener(delegate
                        {
                            /* player.card_Stack.add_MoveCard(
                                player.card_Selection.get_MoveCard(4)
                            );*/
                            player.card_Selection.remove_MoveCard_With_Index(4);
                            player.readyCounter(-1);
                            EventManager.TriggerEvent("HUD_Card_Stack_Item_Unselected");
                            EventManager.TriggerEvent("Player_Card_Selection_Changed");
                            // Debug.Log("HUD_Selected_Card Clicked with id: 4");
                        });
                    }
                    break;
            }
        }
    }

    public void set_MoveCards(MoveCards movecards)
    {

        this.reset_moveCards();

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

            GameObject moveText = GameObject.Find(this.cardTextNamePrefix + i);

            Text textComponent;
            if (moveText.GetComponent<Text>() == null)
            {
                moveText.AddComponent<Text>();
            }
            textComponent = moveText.GetComponent<Text>();

            textComponent.text = currentCard.intensity.ToString();
            textComponent.alignment = TextAnchor.MiddleCenter;
            textComponent.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            textComponent.fontSize = 40;
        }

        setOnClickListeners();
    }

    public void reset_moveCards()
    {
        for (int i = 0; i < m_card_stack_size; i++)
        {
            GameObject.Find(this.cardImageNamePrefix + i).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/empty");
            GameObject.Find(this.cardTextNamePrefix + i).GetComponent<Text>().text = "";
            GameObject.Find("HUD_Selected_Move_" + (i)).GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }

    public void setImageColor(Image image, Color32 color)
    {
        image.color = color;
    }

    public void addSpriteToImage(Image image, string spritePath)
    {
        image.sprite = Resources.Load<Sprite>(spritePath);
    }

    public void changePlayer(int playerNr)
    {
        string playername = "Player" + playerNr;
        player = GameObject.Find(playername).GetComponent<Player>();
    }
}
