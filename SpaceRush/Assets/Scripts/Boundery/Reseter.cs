using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reseter : MonoBehaviour {
	public GameManager game;
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Space"){
				game.resetPlayer(game.player_1);
		}
	}

}
