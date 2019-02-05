using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    //Attributes for Players
    public int playerId;
    public int lives;
    public int shields;
    public float mainFuel;
    public float addFuel;
    private int lastCheckpoint;
    public Color32 playerColor;
    public GameObject space;
    private string weapon1;
    private string weapon2;
    public ActionStack actionStack;
    public ActionStack actionSelection;
    private int cardCounter;
    public List<int> check;

    void Start()
    {
        // For testing purpose
        weapon1 = "gravityMine";
        weapon2 = "";

        init_Start_Values();
        init_card_Stack();
    }

    void init_Start_Values()
    {
        lives = 10;

        shields = 5;

        mainFuel = 5;

        addFuel = 3;

        check = new List<int>();

        cardCounter = 0;

        if (playerId == 1)
        {
            // Blue
            playerColor = Player_Stats.Player_1_color;
        }

        if (playerId == 2)
        {
            //Yellow
            playerColor = Player_Stats.Player_2_color;
        }
    }

    public void addCheckpoint(int checkpoint)
    {
        check.Add(checkpoint);
        lastCheckpoint = checkpoint;
        EventManager.TriggerEvent("Player_Reached_A_Checkpoint");
    }

    public void addWeapon(string weapon)
    {
        if (weapon1 == "")
        {
            weapon1 = weapon;
        }
        else if (weapon2 == "")
        {
            weapon2 = weapon;
        }
    }

    public void removeWeapon(int wpnr)
    {
        if (wpnr == 1)
            weapon1 = "";
        if (wpnr == 2)
            weapon2 = "";
    }

    public int getLastCheckpoint()
    {
        return lastCheckpoint;
    }

    public void looseLive(int damage)
    {
        if (shields > 0)
        {
            shields = shields - damage;
            if (shields < 0)
            {
                lives = lives + shields;
                shields = 0;
            }
        }
        else lives = lives - damage;

    }

    private void playerLost()
    {
        if (lives <= 0)
        {
            if (playerId == 1)
            {
                EventManager.TriggerEvent("Player_1_lost");
            }
            if (playerId == 2)
            {
                EventManager.TriggerEvent("Player_2_lost");
            }
        }
    }

    public void looseFuel(float fuel)
    {
        if (addFuel > 0)
        {
            addFuel = addFuel - fuel;
            if (addFuel < 0)
            {
                mainFuel = mainFuel + addFuel;
                addFuel = 0;
            }
        }
        else mainFuel = mainFuel - fuel;
    }

    public void AddFuel(float fuel)
    {
        mainFuel = mainFuel + fuel;
        if (mainFuel > 5)
        {
            float overflow = mainFuel - 5;
            addFuel = addFuel + overflow;
            mainFuel = 5;
        }
    }

    public void resetFuel()
    {
        mainFuel = 5;
    }
    public String getWeapon(int nr)
    {
        switch (nr)
        {
            case 1: return weapon1;
            case 2: return weapon2;
            default: return "";
        }
    }
    void init_card_Stack()
    {
        this.actionStack = new ActionStack(5);
        this.actionSelection = new ActionStack(0);
        this.actionStack.actionList.Add(ActionCardStorage.getForward());
        this.actionStack.actionList.Add(ActionCardStorage.getBackward());
        this.actionStack.actionList.Add(ActionCardStorage.getRotationRight());
        this.actionStack.actionList.Add(ActionCardStorage.getRotationLeft());
        this.actionStack.actionList.Add(ActionCardStorage.getEmpty());
    }
    public void CardCounterChange(int change)
    {
        cardCounter = cardCounter + change;
        if (cardCounter == 5)
            EventManager.TriggerEvent("Player_Card_Selection_Complete");
        else
            EventManager.TriggerEvent("Player_Card_Selection_Incomplete");
    }
    public void ResetCounter()
    {
        cardCounter = 0;
    }
}