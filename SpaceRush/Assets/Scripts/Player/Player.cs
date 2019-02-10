using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    //Attributes for Players
    public int playerId;
    public float currentSpeed;
    public int lives;
    public int shields;
    public float mainFuel;
    public float addFuel;
    private int lastCheckpoint;
    public Color32 playerColor;
    public GameObject space;
    public Spacecraft spacecraft;
    private string weapon1;
    private string weapon2;
    private string item1;
    private string item2;
    public ActionStack actionStack;
    public ActionStack actionSelection;
    private int cardCounter;
    public List<int> check;

    void Start()
    {
        // For testing purpose
        weapon1 = "rocket";
        weapon2 = "";
        item1 = "fuel";
        item2 = "";
        currentSpeed = 0;

        init_Start_Values();
        init_card_Stack();

        spacecraft = space.GetComponent<Spacecraft>();
    }

    void Update()
    {
        if (!GameManager.GetInstance().gameHasEnded)
        {
            playerLost();
        }
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
            playerColor = Player_Stats.Player_1_color;
        }

        if (playerId == 2)
        {
            playerColor = Player_Stats.Player_2_color;
        }
    }

    public void addCheckpoint(int checkpoint)
    {
        if (AlreadyChecked(checkpoint))
        {
            check.Add(checkpoint);
            lastCheckpoint = checkpoint;
            EventManager.TriggerEvent("Player_Reached_A_Checkpoint");
            if (check.Count == 4)
                GameManager.GetInstance().PlayerWon(this);
        }
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

    public void AddItem(string item)
    {
        if (item1 == "")
        {
            item1 = item;
        }
        else if (item2 == "")
        {
            item2 = item;
        }
    }

    public void removeWeapon(int wpnr)
    {
        if (wpnr == 1)
            weapon1 = "";
        if (wpnr == 2)
            weapon2 = "";
    }

    public void removeItem(int itemnr)
    {
        if (itemnr == 1)
            item1 = "";
        if (itemnr == 2)
            item2 = "";
    }

    public int getLastCheckpoint()
    {
        return lastCheckpoint;
    }

    public void looseLive(int damage)
    {
        spacecraft.ShowDamage(2);
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
            if (addFuel <= 0)
            {
                mainFuel = mainFuel + addFuel;
                addFuel = 0;
            }
        }
        else mainFuel = mainFuel - fuel;
    }
    public void AddMainFuel(float fuel)
    {
        if (mainFuel <= 5)
            mainFuel = mainFuel + fuel;
        if (mainFuel > 5)
        {
            addFuel = addFuel + mainFuel - 5;
            mainFuel = 5;
        }
    }

    public void AddFuel(float fuel)
    {
        addFuel = addFuel + fuel;
    }

    public void AddShield(int shield)
    {
        shields = shields + shield;
        if (shields > 5)
            shields = 5;
    }

    public void AddLive(int live)
    {
        lives = lives + live;
        if (lives > 10)
            lives = 10;
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

    public String GetItem(int nr)
    {
        if (nr == 1)
            return item1;
        else
            return item2;
    }

    void init_card_Stack()
    {
        this.actionStack = new ActionStack(5);
        this.actionSelection = new ActionStack(0);
        this.actionStack.actionList.Add(ActionCardStorage.GetForward());
        this.actionStack.actionList.Add(ActionCardStorage.GetBackward());
        this.actionStack.actionList.Add(ActionCardStorage.GetRotationRight());
        this.actionStack.actionList.Add(ActionCardStorage.GetRotationLeft());
        this.actionStack.actionList.Add(ActionCardStorage.GetEmpty());
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

    public bool AlreadyChecked(int id)
    {
        bool activated = false;
        for (int i = 0; i < check.Count; i++)
        {
            if (check[i] == id)
                return true;
        }
        return activated;
    }
}