using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : Collectible {

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log("collected");
		findGameManager();
		
		if (other.transform.gameObject.name == "Spacecraft"){
			game.player_1.main_fuel = game.player_1.main_fuel + 5; 
			Debug.Log("collected");
		}
		collected();
	}
}
