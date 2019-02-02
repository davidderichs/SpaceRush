using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : Collectible {

	void OnTriggerEnter2D(Collider2D other){
		findGameManager();
		if (other.transform.gameObject.name == "Spacecraft"){
			game.player_1.addFuel = game.player_1.addFuel + 5;
			if(game.player_1.addFuel > 5){
				game.player_1.addFuel = 5;
			} 
			// Debug.Log("collected");
		}
		collected();
	}
}
