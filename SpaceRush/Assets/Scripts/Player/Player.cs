using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour {
    //Attributes for Players
    public int playerId;
    public int lives;
    private int m_lives;
    public int shields;
    private int m_shields;

    private int m_number_of_cards;
    private int m_number_of_selected_cards;

    public MoveCards card_Stack;
    public MoveCards card_Selection;
    public int main_fuel; 
    private int m_main_fuel;
    public int add_fuel; 
    private int m_add_fuel;
    public List<int> check;

    public GameObject space;

    public HUD hud;

    private string weapon_1;

    private string weapon_2;
    // Only for Debug/Testing
     private Movements movements;


    void Awake(){
        
    }
	// Use this for initialization
	void Start () {
        init_Start_Values();
        init_card_Stack();
	}

    
    void init_Start_Values(){
        lives = 10;
        m_lives = 0;

        shields = 5;
        m_shields = 0;

        main_fuel = 5;
        m_main_fuel = 0;

        add_fuel = 3;
        m_add_fuel = 0;

        check = new List<int>();
    }

    void init_card_Stack(){
        this.card_Selection = new MoveCards(0);
        this.card_Stack = MoveCards.get_random_Movecards(10);
        m_number_of_cards = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (m_lives != lives) liveChange();
        if (m_main_fuel != main_fuel) fuelChange();
        if (m_add_fuel != add_fuel) add_fuel_change();
        if (m_shields != shields) shieldChange();
        if (m_number_of_cards != card_Stack.size()) card_stack_changed();
        if (m_number_of_selected_cards != card_Selection.size()) card_selection_changed();
	}

    void card_stack_changed(){
        m_number_of_cards = card_Stack.size();        
        EventManager.TriggerEvent("Player_Card_Stack_Changed");
    }
    void card_selection_changed(){
        m_number_of_selected_cards = card_Selection.size();
        if(card_Selection.size() == 5) {
            EventManager.TriggerEvent("Player_Card_Selection_Complete");
        } else {
            EventManager.TriggerEvent("Player_Card_Selection_Incomplete");
        }
        EventManager.TriggerEvent("Player_Card_Selection_Changed");
    }

    void liveChange(){
        m_lives = lives;
        EventManager.TriggerEvent("Player_Live_Has_Changed");
    }

    void shieldChange(){
        m_shields = shields;
        EventManager.TriggerEvent("Player_Shield_Has_Changed");
    }

    void fuelChange(){
        m_main_fuel = main_fuel;
        EventManager.TriggerEvent("Player_Main_Fuel_Has_Changed");
    }

    void add_fuel_change(){
        m_add_fuel = add_fuel;
        EventManager.TriggerEvent("Player_Add_Fuel_Has_Changed");
    }

    Vector2 getPosition(){
        Vector3 pos = space.transform.position;
        EventManager.TriggerEvent("Player_Position_Has_Changed");
        return new Vector2(pos.x, pos.y);
    }

    public void addCheckpoint(int checkpoint){
        check.Add(checkpoint); 
        EventManager.TriggerEvent("Player_Reached_A_Checkpoint");
    }

    public void addWeapon(string weapon){
        if(weapon_1 == "")
        {
            weapon_1 = weapon;
        }else if(weapon_2 == "")
        {
            weapon_2 = weapon;
        }
    }

    public void removeWeapon(int wpnr){
        if(wpnr == 1)
            weapon_1 = "";
        if(wpnr == 2)
            weapon_2 = "";
    }
}