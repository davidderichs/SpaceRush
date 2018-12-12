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

    public MoveCards card_Stack;
    private int m_card_Stack_size;
    public MoveCards card_Selection;
    private int m_card_selection_size;
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
        this.card_Selection = new MoveCards(0);
        this.m_card_selection_size = 0;

        this.card_Stack = MoveCards.get_random_Movecards(10);
        this.m_card_Stack_size = 0;
    }

    void init_HUD(){
        this.hud = GameObject.FindWithTag("HUD").GetComponent<HUD>();
    }
	
	// Update is called once per frame
	void Update () {
        if (m_lives != lives) liveChange();
        if (m_main_fuel != main_fuel) fuelChange();
        if (m_card_selection_size != card_Selection.size()) selected_Cards_Changed();
        if (m_card_Stack_size != card_Stack.size()) available_Cards_Changed();
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

    public void selected_Cards_Changed(){
        Debug.Log("Card Selection has changed");
        this.hud.selected_movements.set_MoveCards(this.card_Selection);
        m_card_selection_size = card_Selection.size();
    }
    void available_Cards_Changed(){
        Debug.Log("Card Stack has changed");
        this.hud.available_movements.set_MoveCards(this.card_Stack);
        this.m_card_Stack_size = this.card_Stack.size();
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