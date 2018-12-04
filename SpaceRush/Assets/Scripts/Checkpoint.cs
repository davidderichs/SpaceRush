using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
	private Collider2D coll;
	public int id;
	public GameManager game;

	// Use this for initialization
	void Start () {
		coll = GetComponent<Collider2D>();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "MyGameObjectTag"){

		}
		//game.checkpointTriggered(id, );
	}
}
