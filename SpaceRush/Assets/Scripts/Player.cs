using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    //Attributes for Players
    public int playerId;
    public int lives;
    public int shields;
    public int cards;
    public int main_fuel; 
    public int add_fuel; 
    public List<int> check;

    public GameObject space;

    public HUD hud;

    // Only for Debug/Testing
     private Movements movements;

	// Use this for initialization
	void Start () {
        init_HUD();
        init_Start_Values();
	}

    void init_HUD(){
        hud = GameObject.FindWithTag("HUD").GetComponent<HUD>();
    }

    void init_Start_Values(){
        lives = 10;
        shields = 0;
        cards = 10;
        main_fuel = 5;
        add_fuel = 0;
        check = new List<int>();

        updateHUD();
    }
	
	// Update is called once per frame
	void Update () {
        updateHUD();
	}

    void updateHUD(){
        this.hud.live.set_ActiveItemsColor(lives);
        this.hud.main_fuel.set_ActiveItemsColor(this.main_fuel);
        this.hud.add_fuel.set_ActiveItemsColor(this.add_fuel);
        this.hud.shield.set_ActiveItemsColor(this.shields);
    }

    void liveChange(int change){
        lives = lives + change;
        this.hud.live.set_ActiveItemsColor(change);
    }

    void shieldChange(int change){
        shields = shields + change;
    }

    void cardsChange(int change){
        cards = cards + change;
    }
    void fuelChange(int change){
        main_fuel += change;
    }

    Vector2 getPosition(){
        Vector3 pos = space.transform.position;
        return new Vector2(pos.x, pos.y);
    }
    public void addCheckpoint(int checkpoint){
        check.Add(checkpoint); 
    }

}