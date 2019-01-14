using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {
	protected GameManager game;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	protected void collected(){
		Destroy(gameObject);
	}

	protected void findGameManager(){
		game = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
}
