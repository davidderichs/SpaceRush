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
                    if (player.actionStack.getActionCard(copy) is MoveActionCard && player.actionStack.getActionCard(copy).type.Equals("forward"))
                        player.currentSpeed = player.currentSpeed + player.actionStack.getActionCard(copy).forceOrVelocity;
                    if (player.actionStack.getActionCard(copy) is MoveActionCard && player.actionStack.getActionCard(copy).type.Equals("Backward"))
                        player.currentSpeed = player.currentSpeed - player.actionStack.getActionCard(copy).forceOrVelocity;
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
                    currentAction.forceOrVelocity = currentAction.forceOrVelocity + 100;
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
                    currentAction.forceOrVelocity = currentAction.forceOrVelocity - 100;
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

            //Text for the Powerinfos
            Text powerComponent = GameObject.Find("HUDAvailableActionPower" + i).GetComponent<Text>();
            if (currentAction.type.Equals("forward") || currentAction.type.Equals("backward"))
                powerComponent.text = actionStack.getActionCard(i).forceOrVelocity.ToString() + "kN";
            else if (currentAction.type.Equals("rotateRight") || currentAction.type.Equals("rotateLeft"))
                powerComponent.text = (actionStack.getActionCard(i).forceOrVelocity * 2).ToString() + "°";
            powerComponent.alignment = TextAnchor.MiddleCenter;
            powerComponent.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            powerComponent.fontSize = 40;
            //Text for the Fuelinfos
            Text fuelComponent = GameObject.Find("HUDAvailableActionFuel" + i).GetComponent<Text>();
            fuelComponent.text = currentAction.fuelCost + "";
            fuelComponent.alignment = TextAnchor.MiddleCenter;
            fuelComponent.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            fuelComponent.fontSize = 40;
            //Text for CurrentSpeed
            Text currentSpeed = GameObject.Find("HUDBoostPower").GetComponent<Text>();
            currentSpeed.text = player.currentSpeed + "kN";
            currentSpeed.alignment = TextAnchor.MiddleCenter;
            currentSpeed.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            currentSpeed.fontSize = 40;
        }
        setListeners();
        setWeapons();
        AddWeaponListener();
        SetItems();
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
                    case "rocket":
                        if (i == 1)
                        {
                            weapon1.sprite = Resources.Load<Sprite>("Sprites/WeaponRocket");
                            break;
                        }
                        else
                        {
                            weapon2.sprite = Resources.Load<Sprite>("Sprites/WeaponRocket");
                            break;
                        }
                    case "laser":
                        if (i == 1)
                        {
                            weapon1.sprite = Resources.Load<Sprite>("Sprites/WeaponLaser");
                            break;
                        }
                        else
                        {
                            weapon2.sprite = Resources.Load<Sprite>("Sprites/WeaponLaser");
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
                                    player.actionSelection.addActionCard(ActionCardStorage.GetGravityMine());
                                    player.looseFuel(3);
                                    player.CardCounterChange(1);
                                    removeWeapon(player.getWeapon(1), player);
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
                                    player.actionSelection.addActionCard(ActionCardStorage.GetGravityMine());
                                    player.CardCounterChange(1);
                                    player.looseFuel(3);
                                    removeWeapon(player.getWeapon(2), player);
                                    EventManager.TriggerEvent("Player_Card_Selection_Changed");
                                    EventManager.TriggerEvent("Player_Main_Fuel_Has_Changed");
                                    EventManager.TriggerEvent("Player_Add_Fuel_Has_Changed");
                                }
                            });
                        }
                        break;
                    case "rocket":
                        if (i == 1)
                        {
                            GameObject.Find("HUD_Weapon_1").GetComponent<Button>().onClick.AddListener(delegate
                            {
                                if (player.actionSelection.getSize() < 5)
                                {
                                    player.actionSelection.addActionCard(ActionCardStorage.GetRocket());
                                    player.looseFuel(3);
                                    player.CardCounterChange(1);
                                    removeWeapon(player.getWeapon(1), player);
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
                                    player.actionSelection.addActionCard(ActionCardStorage.GetRocket());
                                    player.CardCounterChange(1);
                                    player.looseFuel(3);
                                    removeWeapon(player.getWeapon(2), player);
                                    EventManager.TriggerEvent("Player_Card_Selection_Changed");
                                    EventManager.TriggerEvent("Player_Main_Fuel_Has_Changed");
                                    EventManager.TriggerEvent("Player_Add_Fuel_Has_Changed");
                                }
                            });
                        }
                        break;
                    case "laser":
                        if (i == 1)
                        {
                            GameObject.Find("HUD_Weapon_1").GetComponent<Button>().onClick.AddListener(delegate
                            {
                                if (player.actionSelection.getSize() < 5)
                                {
                                    player.actionSelection.addActionCard(ActionCardStorage.GetLaser());
                                    player.looseFuel(3);
                                    player.CardCounterChange(1);
                                    removeWeapon(player.getWeapon(1), player);
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
                                    player.actionSelection.addActionCard(ActionCardStorage.GetLaser());
                                    player.CardCounterChange(1);
                                    player.looseFuel(3);
                                    removeWeapon(player.getWeapon(2), player);
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

    public void SetItems()
    {
        RemoveImageListeners();
        Image item1 = GameObject.Find("HUD_Item_1").GetComponent<Image>();
        Image item2 = GameObject.Find("HUD_Item_2").GetComponent<Image>();
        for (int i = 0; i < 2; i++)
        {
            if (player.GetItem(i) != "")
                switch (player.GetItem(i))
                {
                    case "fuel":
                        if (i == 1)
                        {
                            item1.sprite = Resources.Load<Sprite>("Sprites/fuel");
                            break;
                        }
                        else
                        {
                            item2.sprite = Resources.Load<Sprite>("Sprites/fuel");
                            break;
                        }
                    case "repair":
                        if (i == 1)
                        {
                            item1.sprite = Resources.Load<Sprite>("Sprites/repair");
                            break;
                        }
                        else
                        {
                            item2.sprite = Resources.Load<Sprite>("Sprites/repair");
                            break;
                        }
                    case "shield":
                        if (i == 1)
                        {
                            item1.sprite = Resources.Load<Sprite>("Sprites/shield");
                            break;
                        }
                        else
                        {
                            item2.sprite = Resources.Load<Sprite>("Sprites/shield");
                            break;
                        }
                }
        }
        SetImageListener();
    }

    public void SetImageListener()
    {
        Button item1 = GameObject.Find("HUD_Item_1").GetComponent<Button>();
        Button item2 = GameObject.Find("HUD_Item_2").GetComponent<Button>();
        for (int i = 0; i < 2; i++)
        {
            if (player.GetItem(i) != "")
                switch (player.GetItem(i))
                {
                    case "fuel":
                        if (i == 1)
                        {
                            item1.onClick.AddListener(delegate
                            {
                                player.AddFuel(5);
                                player.removeItem(1);
                                EventManager.TriggerEvent("Player_Indicator_Change");
                            });
                            break;
                        }
                        else
                        {
                            item2.onClick.AddListener(delegate
                            {
                                player.AddFuel(5);
                                player.removeItem(2);
                                EventManager.TriggerEvent("Player_Indicator_Change");
                            });
                            break;
                        }
                    case "shield":
                        if (i == 1)
                        {
                            item1.onClick.AddListener(delegate
                            {
                                player.AddShield(2);
                                player.removeItem(1);
                                EventManager.TriggerEvent("Player_Indicator_Change");
                            });
                            break;
                        }
                        else
                        {
                            item2.onClick.AddListener(delegate
                            {
                                player.AddShield(2);
                                player.removeItem(2);
                                EventManager.TriggerEvent("Player_Indicator_Change");
                            });
                            break;
                        }
                    case "repair":
                        if (i == 1)
                        {
                            item1.onClick.AddListener(delegate
                            {
                                player.AddLive(3);
                                player.removeItem(1);
                                EventManager.TriggerEvent("Player_Indicator_Change");
                            });
                            break;
                        }
                        else
                        {
                            item2.onClick.AddListener(delegate
                            {
                                player.AddLive(3);
                                player.removeItem(2);
                                EventManager.TriggerEvent("Player_Indicator_Change");
                            });
                            break;
                        }
                }
        }
    }

    public void RemoveImageListeners()
    {
        GameObject.Find("HUD_Item_1").GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/empty");
        GameObject.Find("HUD_Item_2").GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/empty");
        GameObject.Find("HUD_Item_1").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("HUD_Item_2").GetComponent<Button>().onClick.RemoveAllListeners();
    }
}