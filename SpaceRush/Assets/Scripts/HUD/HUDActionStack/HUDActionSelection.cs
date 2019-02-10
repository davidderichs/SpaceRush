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
                ActionCard currentActionCard = player.actionSelection.getActionCard(copy);
                if (currentActionCard is WeaponActionCard)
                {
                    switch (currentActionCard.type)
                    {
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
                if (currentActionCard is MoveActionCard && player.actionStack.getActionCard(copy).type.Equals("forward"))
                {
                    Debug.Log(player.currentSpeed);
                    Debug.Log(currentActionCard.forceOrVelocity);
                    player.currentSpeed = player.currentSpeed - currentActionCard.forceOrVelocity;
                }
                else
                if (currentActionCard is MoveActionCard && player.actionStack.getActionCard(copy).type.Equals("backward"))
                {
                    Debug.Log(player.currentSpeed);
                    Debug.Log(currentActionCard.forceOrVelocity);
                    player.currentSpeed = player.currentSpeed + currentActionCard.forceOrVelocity;
                }
                player.AddMainFuel(currentActionCard.fuelCost);
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
            GameObject.Find("HUDSelectedAction" + copy).GetComponent<Button>().onClick.RemoveAllListeners();
            GameObject.Find("SelectedActionCardPower" + copy).GetComponent<Text>().text = "";
            GameObject.Find("SelectedActionCardFuel" + copy).GetComponent<Text>().text = "";
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

            //Text for the Powerinfos
            Text powerComponent = GameObject.Find("SelectedActionCardPower" + i).GetComponent<Text>();
            if (currentAction.type.Equals("forward") || currentAction.type.Equals("backward"))
                powerComponent.text = actionStack.getActionCard(i).forceOrVelocity.ToString() + "kN";
            else if (currentAction.type.Equals("rotateRight") || currentAction.type.Equals("rotateLeft"))
                powerComponent.text = (actionStack.getActionCard(i).forceOrVelocity * 2).ToString() + "°";
            powerComponent.alignment = TextAnchor.MiddleCenter;
            powerComponent.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            powerComponent.fontSize = 40;
            //Text for the Fuelinfos
            Text fuelComponent = GameObject.Find("SelectedActionCardFuel" + i).GetComponent<Text>();
            fuelComponent.text = currentAction.fuelCost + "";
            fuelComponent.alignment = TextAnchor.MiddleCenter;
            fuelComponent.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            fuelComponent.fontSize = 40;
            Text currentSpeed = GameObject.Find("HUDBoostPower").GetComponent<Text>();
            currentSpeed.text = player.currentSpeed + "kN";
            currentSpeed.alignment = TextAnchor.MiddleCenter;
            currentSpeed.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            currentSpeed.fontSize = 40;
        }
        setListeners();
    }
    public void changePlayer(int playerNr)
    {
        string playername = "Player" + playerNr;
        player = GameObject.Find(playername).GetComponent<Player>();
    }
}