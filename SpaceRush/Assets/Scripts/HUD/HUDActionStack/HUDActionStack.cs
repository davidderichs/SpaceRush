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
                if (player.actionSelection.getSize() < 5 && (player.mainFuel + player.addFuel) >= player.actionStack.getActionCard(copy).fuelCost)
                {
                    player.actionSelection.addActionCard(
                        player.actionStack.getActionCard(copy)
                    );
                    player.looseFuel(player.actionStack.getActionCard(copy).fuelCost);
                    player.CardCounterChange(1);
                    if (player.actionStack.getActionCard(copy) is WeaponActionCard)
                        removeWeapon(player.actionStack.getActionCard(copy).type, player);
                    EventManager.TriggerEvent("Player_Card_Selection_Changed");
                    EventManager.TriggerEvent("Player_Main_Fuel_Has_Changed");
                    EventManager.TriggerEvent("Player_Add_Fuel_Has_Changed");
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
            int copy = i;
            GameObject.Find("HUDButtonPlus").GetComponent<Button>().onClick.RemoveAllListeners();
            GameObject.Find("HUDButtonMinus").GetComponent<Button>().onClick.RemoveAllListeners();
            GameObject.Find("HUDAvailableActionImage" + copy).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/empty");
            GameObject.Find("HUDAvailableActionText" + copy).GetComponent<Text>().text = "";
            GameObject.Find("HUDAvailableAction" + copy).GetComponent<Button>().onClick.RemoveAllListeners();
        }
        GameObject.Find("HUD_Weapon_1").GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/empty");
        GameObject.Find("HUD_Weapon_2").GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/empty");
        GameObject.Find("HUD_Weapon_1").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("HUD_Weapon_2").GetComponent<Button>().onClick.RemoveAllListeners();
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
                fuelComponent.text = (actionStack.getActionCard(i).forceOrVelocity * 2).ToString() + "°";
            fuelComponent.alignment = TextAnchor.MiddleCenter;
            fuelComponent.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            fuelComponent.fontSize = 40;
        }
        setListeners();
        setWeapons();
        AddWeaponListener();
    }

    public void setWeapons()
    {
        Image weapon1 = GameObject.Find("HUD_Weapon_1").GetComponent<Image>();
        Image weapon2 = GameObject.Find("HUD_Weapon_2").GetComponent<Image>();
        for (int i = 0; i < 2; i++)
        {
            if (player.getWeapon(i) != "")
                switch (player.getWeapon(i))
                {
                    case "gravityMine":
                        if (i == 1)
                        {
                            weapon1.sprite = Resources.Load<Sprite>("Sprites/WeaponGravityMine");
                            break;
                        }
                        else
                        { 
                            weapon2.sprite = Resources.Load<Sprite>("Sprites/WeaponGravityMine");
                            break;
                        }
                }
        }
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

    private void AddWeaponListener()
    {
        for (int i = 0; i < 2; i++)
        {
            if (player.getWeapon(i) != "" && player.mainFuel >= 3)
                switch (player.getWeapon(i))
                {
                    case "gravityMine":
                        if (i == 1)
                        {
                            GameObject.Find("HUD_Weapon_1").GetComponent<Button>().onClick.AddListener(delegate
                            {
                                if (player.actionSelection.getSize() < 5)
                                {
                                    player.actionSelection.addActionCard(ActionCardStorage.getGravityMine());
                                    player.looseFuel(3);
                                    player.CardCounterChange(1);
                                    removeWeapon(player.getWeapon(1),player);
                                    EventManager.TriggerEvent("Player_Card_Selection_Changed");
                                    EventManager.TriggerEvent("Player_Main_Fuel_Has_Changed");
                                    EventManager.TriggerEvent("Player_Add_Fuel_Has_Changed");
                                }
                            });
                        }
                        else
                        {    
                            GameObject.Find("HUD_Weapon_2").GetComponent<Button>().onClick.AddListener(delegate
                            {
                                if (player.actionSelection.getSize() < 5)
                                {
                                    player.actionSelection.addActionCard(ActionCardStorage.getGravityMine());
                                    player.CardCounterChange(1);
                                    player.looseFuel(3);
                                    removeWeapon(player.getWeapon(2),player);
                                    EventManager.TriggerEvent("Player_Card_Selection_Changed");
                                    EventManager.TriggerEvent("Player_Main_Fuel_Has_Changed");
                                    EventManager.TriggerEvent("Player_Add_Fuel_Has_Changed");
                                }
                            });
                        }
                        break;
                }

        }

    }
    public void removeWeapon(string type, Player currentPlayer)
    {
        switch (type)
        {
            case "gravityMine":
                //Debug.Log(player.getWeapon(1));
                if (player.getWeapon(1) == "gravityMine")
                    player.removeWeapon(1);
                else
                    player.removeWeapon(2);
                break;
            case "laser":
                if (player.getWeapon(1) == "laser")
                    player.removeWeapon(1);
                else
                    player.removeWeapon(2);
                break;
            case "rocket":
                if (player.getWeapon(1) == "rocket")
                    player.removeWeapon(1);
                else
                    player.removeWeapon(2);
                break;
        }
        EventManager.TriggerEvent("Player_Card_Stack_Changed");
    }
}