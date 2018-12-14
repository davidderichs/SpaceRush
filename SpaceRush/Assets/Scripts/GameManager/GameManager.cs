using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public Player pl1;
	//public Player pl2;
	public Checkpoint checkpoint1;
	public Checkpoint checkpoint2;
	public Checkpoint checkpoint3;
	public Checkpoint checkpoint4;

	public Startpoint start;
	// Use this for initialization

	void Awake(){
		
	}

	void Start () {
		pl1.space.transform.position = start.position;
	}
	public void checkpointTriggered(int id, Player player){
		player.addCheckpoint(id);
	}
	void Update(){
		if (pl1.check.Count == 4){
			Debug.Log("Player 1 Win");
		}
	}

	public void resetPlayer(Player player){
		int number = player.check.Count;
		int lastDig = player.check[number-1];
		Debug.Log(lastDig);
		if(lastDig == 1){
			player.space.transform.position = checkpoint1.transform.position;
		}
		if(lastDig == 2){
			player.space.transform.position = checkpoint2.transform.position;
		}
		if(lastDig == 3){
			player.space.transform.position = checkpoint3.transform.position;
		}
		if(lastDig == 4){
			player.space.transform.position = checkpoint4.transform.position;
		}
	}
}