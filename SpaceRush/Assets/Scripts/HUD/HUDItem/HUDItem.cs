using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDItem : MonoBehaviour
{
    public static void SetItems(Player player)
    {
        RemoveListeners();
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
        SetListener(player);
    }

    public static void SetListener(Player player)
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

    public static void RemoveListeners()
    {
        GameObject.Find("HUD_Item_1").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("HUD_Item_2").GetComponent<Button>().onClick.RemoveAllListeners();
    }
}