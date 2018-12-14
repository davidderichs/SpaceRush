using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {
	public Player player_1;
	//public Player pl2;
	public Checkpoint checkpoint1;
	public Checkpoint checkpoint2;
	public Checkpoint checkpoint3;
	public Checkpoint checkpoint4;

	private UnityAction player_live_listener;
	private UnityAction player_main_fuel_listener;
	private UnityAction player_add_fuel_listener;
	private UnityAction player_shield_listener;

	public Startpoint start;
	// Use this for initialization

	private HUD hud;

	void Awake(){
		player_live_listener = new UnityAction (propagate_Player_live_change);
		EventManager.StartListening("Player_Live_Has_Changed", player_live_listener);	

		player_main_fuel_listener = new UnityAction (propagate_Player_main_fuel_change);
		EventManager.StartListening("Player_Main_Fuel_Has_Changed", player_main_fuel_listener);		

		player_add_fuel_listener = new UnityAction (propagate_Player_add_fuel_change);
		EventManager.StartListening("Player_Add_Fuel_Has_Changed", player_add_fuel_listener);		

		player_shield_listener = new UnityAction (propagate_Player_shield_change);
		EventManager.StartListening("Player_Shield_Has_Changed", player_shield_listener);		
	}

	void Start () {

        this.hud = GameObject.FindWithTag("HUD").GetComponent<HUD>();
		this.player_1 = GameObject.Find("Player").GetComponent<Player>();

		player_1.space.transform.position = start.position;
	}

	void propagate_Player_live_change(){
		this.hud.live.set_ActiveItemsColor(this.player_1.lives);
	}
	void propagate_Player_main_fuel_change(){
		this.hud.main_fuel.set_ActiveItemsColor(this.player_1.main_fuel);
	}
	void propagate_Player_add_fuel_change(){
		this.hud.add_fuel.set_ActiveItemsColor(this.player_1.add_fuel);
	}
	void propagate_Player_shield_change(){
		this.hud.shield.set_ActiveItemsColor(this.player_1.shields);
	}

	public void checkpointTriggered(int id, Player player){
		player_1.addCheckpoint(id);
	}
	void Update(){
		if (player_1.check.Count == 4){
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