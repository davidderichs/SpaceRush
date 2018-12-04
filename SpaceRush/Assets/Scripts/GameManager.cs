using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public Player pl1;
	//public Player pl2;
	public Startpoint start;
	// Use this for initialization
	void Start () {
		pl1.space.transform.position = start.position;
	}
	
	// Update is called once per frame
	void Update () {
         
	}
	public void checkpointTriggered(int id, Player player){

	}
}