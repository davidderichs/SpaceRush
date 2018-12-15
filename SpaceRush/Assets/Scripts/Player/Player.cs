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
	}

    void card_stack_changed(){
        m_number_of_cards = card_Stack.size();
        EventManager.TriggerEvent("Player_Card_Stack_Changed", new EventInformation(this.playerId, "Player"+this.playerId+"live"));
    }

    void liveChange(){
        m_lives = lives;
        EventManager.TriggerEvent("Player_Live_Has_Changed", new EventInformation(this.playerId, "Player"+this.playerId+"live"));
    }

    void shieldChange(){
        m_shields = shields;
        EventManager.TriggerEvent("Player_Shield_Has_Changed", new EventInformation(this.playerId, "Player"+this.playerId+"shield"));
    }

    void fuelChange(){
        m_main_fuel = main_fuel;
        EventManager.TriggerEvent("Player_Main_Fuel_Has_Changed", new EventInformation(this.playerId, "Player"+this.playerId+"fuel"));
    }

    void add_fuel_change(){
        m_add_fuel = add_fuel;
        EventManager.TriggerEvent("Player_Add_Fuel_Has_Changed", new EventInformation(this.playerId, "Player"+this.playerId+"add_fuel"));
    }

    Vector2 getPosition(){
        Vector3 pos = space.transform.position;
        EventManager.TriggerEvent("Player_Position_Has_Changed", new EventInformation(this.playerId, "Player"+this.playerId+"position"));
        return new Vector2(pos.x, pos.y);
    }

    public void addCheckpoint(int checkpoint){
        check.Add(checkpoint); 
        EventManager.TriggerEvent("Player_Reached_A_Checkpoint", new EventInformation(this.playerId, "Player"+this.playerId+"checkpoint"));
    }
}