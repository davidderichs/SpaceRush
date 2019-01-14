using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shields : Collectible {

	void OnTriggerEnter2D(Collider2D other){
		findGameManager();
		if (other.transform.gameObject.name == "Spacecraft"){
			//game.player_1.add_fuel(5);
			Debug.Log("collected");
		}
		collected();
	}
}
