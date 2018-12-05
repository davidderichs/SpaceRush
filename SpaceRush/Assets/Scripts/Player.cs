using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    //Attributes for Players
    public int playerId;
    private int lives;
    private int shields;
    private int cards;
    private int fuel; 
    public List<int> check;

    public GameObject space;

    // Only for Debug/Testing
     private Movements movements;

	// Use this for initialization
	void Start () {
        lives = 5;
        shields = 0;
        cards = 10;
        fuel = 5;
        check = new List<int>();
	}
	
	// Update is called once per frame
	void Update () {
         
	}

    void liveChange(int change){
        lives = lives + change;
    }

    void shieldChange(int change){
        shields = shields + change;
    }

    void cardsChange(int change){
        cards = cards + change;
    }
    void fuelChange(int change){
        fuel = fuel + change;
    }

    Vector2 getPosition(){
        Vector3 pos = space.transform.position;
        return new Vector2(pos.x, pos.y);
    }
    public void addCheckpoint(int checkpoint){
        check.Add(checkpoint); 
    }

}