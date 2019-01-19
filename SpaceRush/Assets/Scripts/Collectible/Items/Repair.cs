using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : Collectible {

	void OnTriggerEnter2D(Collider2D other){
		findGameManager();
		if (other.transform.gameObject.name == "Spacecraft"){
			game.player_1.lives = game.player_1.lives + 2;
			if(game.player_1.lives >  10)
				game.player_1.lives = 10;
			Debug.Log("collected");
		}
		collected();
	}
}
