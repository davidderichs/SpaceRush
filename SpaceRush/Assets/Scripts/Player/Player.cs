using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    //Attributes for Players
    public int playerId;
    public int lives;
    private int m_lives;
    public int shields;
    private int m_shields;

    public int m_number_of_cards;
    private int m_number_of_selected_cards;

    private int last_Checkpoint;

    public MoveCards card_Stack;
    public MoveCards card_Selection;
    public int main_fuel;
    private int m_main_fuel;
    public int add_fuel;
    private int m_add_fuel;
    public List<int> check;

    public Color playerColor;

    public GameObject space;

    public HUD hud;

    private string weapon_1;

    private string weapon_2;
    private int ready;
    // Only for Debug/Testing
    private Movements movements;


    void Awake()
    {

    }
    // Use this for initialization
    void Start()
    {
        // For testing purpose
        weapon_1 = "Weapon_Gravity_Mine";
        weapon_2 = "";

        init_Start_Values();
        init_card_Stack();
    }


    void init_Start_Values()
    {
        lives = 10;
        m_lives = 0;

        shields = 5;
        m_shields = 0;

        main_fuel = 5;
        m_main_fuel = 0;

        add_fuel = 3;
        m_add_fuel = 0;

        check = new List<int>();

        if(playerId == 1)
            playerColor = Color.blue;
        if(playerId == 2)
            playerColor = Color.yellow;
    }

    void init_card_Stack()
    {
        this.card_Stack = new MoveCards(10);
        this.card_Selection = new MoveCards(0);
        this.card_Stack.card_List.Add(MoveCardCreator.getForward());
        this.card_Stack.card_List.Add(MoveCardCreator.getBackward());
        this.card_Stack.card_List.Add(MoveCardCreator.getRotationLeft30());
        this.card_Stack.card_List.Add(MoveCardCreator.getRotationRight30());
        this.card_Stack.card_List.Add(MoveCardCreator.getRotationLeft60());
        this.card_Stack.card_List.Add(MoveCardCreator.getRotationRight60());
        this.card_Stack.card_List.Add(MoveCardCreator.getRotationLeft90());
        this.card_Stack.card_List.Add(MoveCardCreator.getRotationRight90());
        if (weapon_1 != "")
            this.card_Stack.card_List.Add(MoveCardCreator.getWeapon(weapon_1));
        else
            this.card_Stack.card_List.Add(MoveCardCreator.getForwardFast());
        if (weapon_2 != "")
            this.card_Stack.card_List.Add(MoveCardCreator.getWeapon(weapon_2));
        else
            this.card_Stack.card_List.Add(MoveCardCreator.getBackwardFast());
        m_number_of_cards = 0;
        //card_stack_changed();
    }

    // Update is called once per frame
    void Update()
    {
        /*     if (card_Selection.size() == 5 && ready == 0)
            {
                EventManager.TriggerEvent("Player_Card_Selection_Complete");
                ready++;
            }
            else if(ready == 2)
            {
                EventManager.TriggerEvent("Player_Card_Selection_Incomplete");
                ready = 0;
            } */
        if (m_lives != lives) liveChange();
        if (m_main_fuel != main_fuel) fuelChange();
        if (m_add_fuel != add_fuel) add_fuel_change();
        if (m_shields != shields) shieldChange();
        //if (m_number_of_cards != card_Stack.size()) card_stack_changed();
        //if (m_number_of_selected_cards != card_Selection.size()) card_selection_changed();
    }

    void card_stack_changed()
    {
        m_number_of_cards = card_Stack.size();
        EventManager.TriggerEvent("Player_Card_Stack_Changed");
    }
    void card_selection_changed()
    {
        m_number_of_selected_cards = card_Selection.size();
        if (card_Selection.size() == 5)
        {
            EventManager.TriggerEvent("Player_Card_Selection_Complete");
        }
        else
        {
            EventManager.TriggerEvent("Player_Card_Selection_Incomplete");
        }
        EventManager.TriggerEvent("Player_Card_Selection_Changed");
    }

    void liveChange()
    {
        m_lives = lives;
        EventManager.TriggerEvent("Player_Live_Has_Changed");
    }

    void shieldChange()
    {
        m_shields = shields;
        EventManager.TriggerEvent("Player_Shield_Has_Changed");
    }

    void fuelChange()
    {
        m_main_fuel = main_fuel;
        EventManager.TriggerEvent("Player_Main_Fuel_Has_Changed");
    }

    void add_fuel_change()
    {
        m_add_fuel = add_fuel;
        EventManager.TriggerEvent("Player_Add_Fuel_Has_Changed");
    }

    Vector2 getPosition()
    {
        Vector3 pos = space.transform.position;
        EventManager.TriggerEvent("Player_Position_Has_Changed");
        return new Vector2(pos.x, pos.y);
    }

    public void addCheckpoint(int checkpoint)
    {
        check.Add(checkpoint);
        last_Checkpoint = checkpoint;
        EventManager.TriggerEvent("Player_Reached_A_Checkpoint");
    }

    public void addWeapon(string weapon)
    {
        if (weapon_1 == "")
        {
            weapon_1 = weapon;
        }
        else if (weapon_2 == "")
        {
            weapon_2 = weapon;
        }
    }

    public void removeWeapon(int wpnr)
    {
        if (wpnr == 1)
            weapon_1 = "";
        if (wpnr == 2)
            weapon_2 = "";
    }

    public int getLastCheckpoint()
    {
        return last_Checkpoint;
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

    public void looseFuel(int fuel)
    {
        if (add_fuel > 0)
        {
            add_fuel = add_fuel - fuel;
            if (add_fuel < 0)
            {
                main_fuel = main_fuel + add_fuel;
                add_fuel = 0;
            }
        }
        else main_fuel = main_fuel - fuel;
    }

    public void resetFuel()
    {
        main_fuel = 5;
    }
    public String getWeapon(int nr)
    {
        switch (nr)
        {
            case 1: return weapon_1;
            case 2: return weapon_2;
            default: return "";
        }
    }

    public void readyCounter(int counter)
    {
        m_number_of_cards = m_number_of_cards + counter;
        if (m_number_of_cards == 5)
        {
            EventManager.TriggerEvent("Player_Card_Selection_Complete");
            m_number_of_cards = 0;
        }
    }
}