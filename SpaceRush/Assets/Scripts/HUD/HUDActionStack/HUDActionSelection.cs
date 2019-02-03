using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDActionSelection : MonoBehaviour
{
    public int playerNr;
    private Player player;
    void Start()
    {
        string startPlayer = "Player" + playerNr;
        player = GameObject.Find(startPlayer).GetComponent<Player>();
        SetImages();
    }
    void setListeners()
    {
        for (int i = 0; i < player.actionSelection.getSize(); i++)
        {
            int copy = i;
            Button HUD_clickable_Card = GameObject.Find("HUDSelectedAction" + (copy)).GetComponent<Button>();
            HUD_clickable_Card.onClick.AddListener(delegate
            {
                if (player.actionSelection.getActionCard(copy) is WeaponActionCard){
                    switch(player.actionSelection.getActionCard(copy).type){
                        case "gravityMine":
                        player.addWeapon("gravityMine");
                        break;
                        case "laser":
                        player.addWeapon("laser");
                        break;
                        case "rocket":
                        player.addWeapon("rocket");
                        break;
                    }
                }

                player.AddFuel(player.actionSelection.getActionCard(copy).fuelCost);
                player.actionSelection.removeActionCardwithIndex(copy);
                player.CardCounterChange(-1);
                EventManager.TriggerEvent("Player_Card_Selection_Changed");
                EventManager.TriggerEvent("Player_Main_Fuel_Has_Changed");
                EventManager.TriggerEvent("Player_Add_Fuel_Has_Changed");
            });
        }
    }


    void removeListeners()
    {

        for (int i = 0; i < 5; i++)
        {
            int copy = i;
            GameObject.Find("SelectedActionCardImage" + copy).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/empty");
            GameObject.Find("SelectedActionCardText" + copy).GetComponent<Text>().text = "";
            GameObject.Find("HUDSelectedAction" + copy).GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }

    public void SetImages()
    {
        for (int i = 0; i < 5; i++)
        {
            int copy = i;
            GameObject actionImage = GameObject.Find("SelectedActionCardImage" + copy);
            actionImage.AddComponent<Image>();
            Image image = actionImage.GetComponent<Image>();
            image.sprite = Resources.Load<Sprite>("Sprites/empty");
            GameObject actionText = GameObject.Find("SelectedActionCardText" + copy);
            actionText.AddComponent<Text>();
        }
    }
    public void SetActionCards(ActionStack actionStack)
    {
        removeListeners();
        for (int i = 0; i < actionStack.getSize(); i++)
        {
            ActionCard currentAction = actionStack.getActionCard(i);
            //Debug.Log("CardDesc: " + currentAction.description + ", Force: " + currentAction.forceOrVelocity);
            //Set Image
            GameObject actionImage = GameObject.Find("SelectedActionCardImage" + i);
            Image image;
            if (actionImage.GetComponent<Image>() == null)
            {
                actionImage.AddComponent<Image>();
            }
            image = actionImage.GetComponent<Image>();
            image.sprite = Resources.Load<Sprite>("Sprites/" + currentAction.spriteName);
            //Set Text
            GameObject actionText = GameObject.Find("SelectedActionCardText" + i);

            Text textComponent;
            if (actionText.GetComponent<Text>() == null)
            {
                actionText.AddComponent<Text>();
            }
            textComponent = actionText.GetComponent<Text>();

            textComponent.text = currentAction.description;
            textComponent.alignment = TextAnchor.MiddleCenter;
            textComponent.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            textComponent.fontSize = 40;
        }
        setListeners();
    }
    public void changePlayer(int playerNr)
    {
        string playername = "Player" + playerNr;
        player = GameObject.Find(playername).GetComponent<Player>();
    }
}