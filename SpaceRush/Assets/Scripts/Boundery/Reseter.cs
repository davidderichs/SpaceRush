using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reseter : MonoBehaviour {
	private GameManager game;

	void start(){
		game = GameObject.Find("Gamemanager").GetComponent<GameManager>();
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.transform.gameObject.name == "Spacecraft"){
				game.resetPlayer(game.player_1);
		}
	}

}
