using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDActionStack : MonoBehaviour
{
    public int playerNr;
    private Player player;

    void Start()
    {
        string startPlayer = "Player" + playerNr;
        player = GameObject.Find(startPlayer).GetComponent<Player>();
        setInit();
    }
    void setListeners()
    {
        for (int i = 0; i < player.actionStack.getSize(); i++)
        {
            int copy = i;
            Button HUD_clickable_Card = GameObject.Find("HUDAvailableAction" + (copy)).GetComponent<Button>();
            HUD_clickable_Card.onClick.AddListener(delegate
            {
                if (player.actionSelection.getSize() < 5)
                {
                    player.actionSelection.addActionCard(
                        player.actionStack.getActionCard(copy)
                    );
                    player.CardCounterChange(1);
                    EventManager.TriggerEvent("Player_Card_Selection_Changed");
                }
                else
                {
                    EventManager.TriggerEvent("HUD_Card_Selection_Impossible");
                }
            });
        }
        Button HUDPlus = GameObject.Find("HUDButtonPlus").GetComponent<Button>();
        HUDPlus.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/plusButton");
        Button HUDMinus = GameObject.Find("HUDButtonMinus").GetComponent<Button>();
        HUDMinus.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/minusButton");
        HUDPlus.onClick.AddListener(delegate
        {
            for (int i = 0; i < 5; i++)
            {
                ActionCard currentAction = player.actionStack.getActionCard(i);
                if (currentAction.type.Equals("forward") && currentAction.fuelCost < 6 || currentAction.type.Equals("backward") && currentAction.fuelCost < 6)
                {
                    currentAction.forceOrVelocity = currentAction.forceOrVelocity * 2;
                    currentAction.fuelCost = currentAction.fuelCost + 1;
                    EventManager.TriggerEvent("Player_Card_Selection_Changed");
                    Debug.Log("test");
                }

                else if (currentAction.type.Equals("rotateRight") && currentAction.forceOrVelocity < 45 || currentAction.type.Equals("rotateLeft") && currentAction.forceOrVelocity < 45)
                {
                    currentAction.forceOrVelocity = currentAction.forceOrVelocity + 5;
                    EventManager.TriggerEvent("Player_Card_Selection_Changed");
                }
            }
        });
        HUDMinus.onClick.AddListener(delegate
        {
            for (int i = 0; i < 5; i++)
            {
                ActionCard currentAction = player.actionStack.getActionCard(i);
                if (currentAction.type.Equals("forward") && currentAction.fuelCost > 1 || currentAction.type.Equals("backward") && currentAction.fuelCost > 1)
                {
                    currentAction.forceOrVelocity = currentAction.forceOrVelocity / 2;
                    currentAction.fuelCost = currentAction.fuelCost - 1;
                    EventManager.TriggerEvent("Player_Card_Selection_Changed");
                    Debug.Log("test");
                }

                else if (currentAction.type.Equals("rotateRight") && currentAction.forceOrVelocity > 5 || currentAction.type.Equals("rotateLeft") && currentAction.forceOrVelocity > 5)
                {
                    currentAction.forceOrVelocity = currentAction.forceOrVelocity - 5;
                    EventManager.TriggerEvent("Player_Card_Selection_Changed");
                }
            }
        });
    }

    void removeListeners()
    {
        for (int i = 0; i < player.actionStack.getSize(); i++)
        {
            {
                int copy = i;
                GameObject.Find("HUDButtonPlus").GetComponent<Button>().onClick.RemoveAllListeners();
                GameObject.Find("HUDButtonMinus").GetComponent<Button>().onClick.RemoveAllListeners();
                GameObject.Find("HUDAvailableActionImage" + copy).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/empty");
                GameObject.Find("HUDAvailableActionText" + copy).GetComponent<Text>().text = "";
                GameObject.Find("HUDAvailableAction" + copy).GetComponent<Button>().onClick.RemoveAllListeners();
            }
        }
    }


    public void SetActionCards(ActionStack actionStack)
    {
        removeListeners();
        for (int i = 0; i < actionStack.getSize(); i++)
        {
            ActionCard currentAction = actionStack.getActionCard(i);
            //Set Image
            GameObject actionImage = GameObject.Find("HUDAvailableActionImage" + i);
            Image image;
            if (actionImage.GetComponent<Image>() == null)
            {
                actionImage.AddComponent<Image>();
            }
            image = actionImage.GetComponent<Image>();
            image.sprite = Resources.Load<Sprite>("Sprites/" + currentAction.spriteName);
            //Set Text
            GameObject actionText = GameObject.Find("HUDAvailableActionText" + i);

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

            //Text for the Powerinfos
            Text fuelComponent = GameObject.Find("HUDAvailableActionFuel" + i).GetComponent<Text>();
            if (currentAction.type.Equals("forward") || currentAction.type.Equals("backward"))
                fuelComponent.text = actionStack.getActionCard(i).forceOrVelocity.ToString();
            else if (currentAction.type.Equals("rotateRight") || currentAction.type.Equals("rotateLeft"))
                fuelComponent.text = (actionStack.getActionCard(i).forceOrVelocity*2).ToString() + "°";
            fuelComponent.alignment = TextAnchor.MiddleCenter;
            fuelComponent.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            fuelComponent.fontSize = 40;
        }
        setListeners();
    }

    private void setInit()
    {
        for (int i = 0; i < 5; i++)
        {
            int copy = i;
            GameObject actionImage = GameObject.Find("HUDAvailableActionImage" + copy);
            actionImage.AddComponent<Image>();
            Image image = actionImage.GetComponent<Image>();
            image.sprite = Resources.Load<Sprite>("Sprites/empty");
            GameObject actionText = GameObject.Find("HUDAvailableActionText" + copy);
            actionText.AddComponent<Text>();
        }
    }

    public void changePlayer(int playerNr)
    {
        string playername = "Player" + playerNr;
        player = GameObject.Find(playername).GetComponent<Player>();
    }
}