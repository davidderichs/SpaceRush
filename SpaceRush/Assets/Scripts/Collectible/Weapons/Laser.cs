﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Collectible {
    void OnTriggerEnter2D(Collider2D other){
		findGameManager();
		if (other.transform.gameObject.name == "Spacecraft"){
			game.player_1.addWeapon("Laser");
			Debug.Log("collected");
		}
		if (other.transform.gameObject.name == "Spacecraft2"){
			game.player_2.addWeapon("Laser");
			Debug.Log("collected");
		}
		collected();
	}
}