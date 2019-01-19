using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shields : Collectible {

	void OnTriggerEnter2D(Collider2D other){
		findGameManager();
		if (other.transform.gameObject.name == "Spacecraft"){
			game.player_1.shields = game.player_1.shields + 2;
			Debug.Log("collected");
		}
		collected();
	}
}