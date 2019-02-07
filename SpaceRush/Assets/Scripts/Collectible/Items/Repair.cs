using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : Collectible {

	void OnTriggerEnter2D(Collider2D other){
		findGameManager();
		if (other.transform.gameObject.name == "Spacecraft1"){
				game.player_1.AddItem("repair");
			// Debug.Log("collected");
		}
		if (other.transform.gameObject.name == "Spacecraft2"){
				game.player_2.AddItem("repair");
			// Debug.Log("collected");
		}
		collected();
	}
}
