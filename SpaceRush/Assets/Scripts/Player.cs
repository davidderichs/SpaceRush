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

    public int number_of_cards;
    private int m_number_of_cards;
    public int number_of_selected_cards;
    private int m_numberof_selected_cards;

    public MoveCards card_Stack;
    private MoveCards m_card_Stack;
    public MoveCards card_Selection;
    private MoveCards m_card_selection;
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
        init_HUD();
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
        this.card_Selection = MoveCards.get_random_Movecards(5);
        m_card_selection = null;

        this.card_Stack = MoveCards.get_random_Movecards(10);
        m_card_Stack = null;

        this.number_of_cards = this.card_Stack.size();
        m_number_of_cards = 0;

        this.number_of_selected_cards = 0;
        m_numberof_selected_cards = 0;
    }

    void init_HUD(){
        this.hud = GameObject.FindWithTag("HUD").GetComponent<HUD>();
    }
	
	// Update is called once per frame
	void Update () {
        if (m_lives != lives) liveChange();
        if (m_main_fuel != main_fuel) fuelChange();
        if (m_card_selection != card_Selection) selected_Cards_Changed();
        // if (m_card_Stack != card_Stack) available_Cards_Changed();
        if (m_add_fuel != add_fuel) add_fuel_change();
        if (m_shields != shields) shieldChange();
	}

    void liveChange(){
        this.hud.live.set_ActiveItemsColor(this.lives);
        m_lives = lives;
    }

    void shieldChange(){
        this.hud.shield.set_ActiveItemsColor(this.shields);
        m_shields = shields;
    }

    void selected_Cards_Changed(){
        this.hud.selected_movements.set_MoveCards(this.card_Selection);
        m_card_selection = card_Selection;
    }
    void available_Cards_Changed(){
        this.hud.available_movements.set_MoveCards(this.card_Stack);
        m_card_Stack = card_Stack;
    }
    void fuelChange(){
        this.hud.main_fuel.set_ActiveItemsColor(this.main_fuel);
        m_main_fuel = main_fuel;
    }

    void add_fuel_change(){
        this.hud.add_fuel.set_ActiveItemsColor(this.add_fuel);
        m_add_fuel = add_fuel;
    }

    Vector2 getPosition(){
        Vector3 pos = space.transform.position;
        return new Vector2(pos.x, pos.y);
    }
    public void addCheckpoint(int checkpoint){
        check.Add(checkpoint); 
    }

}