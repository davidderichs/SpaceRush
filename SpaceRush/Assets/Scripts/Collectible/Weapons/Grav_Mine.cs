﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grav_Mine : Collectible {

	void OnTriggerEnter2D(Collider2D other){
		findGameManager();
		if (other.transform.gameObject.name == "Spacecraft1"){
			game.player_1.addWeapon("gravityMine");
		}
		if (other.transform.gameObject.name == "Spacecraft2"){
			game.player_2.addWeapon("gravityMine");
		}
		collected();
	}
}
