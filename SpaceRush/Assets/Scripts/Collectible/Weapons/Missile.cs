﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Collectible {
    void OnTriggerEnter2D(Collider2D other){
		findGameManager();
		if (other.transform.gameObject.name == "Spacecraft1"){
			game.player_1.addWeapon("rocket");
			//Debug.Log("collected");
		}
		if (other.transform.gameObject.name == "Spacecraft2"){
			game.player_2.addWeapon("rocket");
			//Debug.Log("collected");
		}
		collected();
	}
}