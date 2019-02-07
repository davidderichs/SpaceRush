using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shields : Collectible {

	void OnTriggerEnter2D(Collider2D other){
		findGameManager();
		if (other.transform.gameObject.name == "Spacecraft1"){
				game.player_1.AddItem("shield");
			// Debug.Log("collected");
		}
		if (other.transform.gameObject.name == "Spacecraft2"){
				game.player_2.AddItem("shield");
			// Debug.Log("collected");
		}
		collected();
	}
}