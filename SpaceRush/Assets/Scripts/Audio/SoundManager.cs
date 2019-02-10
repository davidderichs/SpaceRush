﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundManager : MonoBehaviour {

	private bool boostSoundStopped;

	private UnityAction card_selected_listener;
	private UnityAction card_unselected_listener;
	private UnityAction card_selection_impossible_listener;
	private UnityAction card_selection_complete_listener;
	private UnityAction player_ready_listener;
	private UnityAction spacecraft_collision_listener;
	private UnityAction spacecraft_boost_start_listener;
	private UnityAction spacecraft_boost_stop_listener;
	private UnityAction simulation_start_listener;
	private UnityAction simulation_stop_listener;

	// Use this for initialization
	void Start () {



		card_selected_listener = new UnityAction (play_sound_card_selected);
		EventManager.StartListening("HUD_Card_Stack_Item_Selected", card_selected_listener);

		card_selection_impossible_listener = new UnityAction (play_sound_card_selection_impossible);
		EventManager.StartListening("HUD_Card_Selection_Impossible", card_selection_impossible_listener);

		card_unselected_listener = new UnityAction (play_sound_card_unselected);
		EventManager.StartListening("HUD_Card_Stack_Item_Unselected", card_unselected_listener);

		card_selection_complete_listener = new UnityAction (play_sound_card_selection_complete);
		EventManager.StartListening("Player_Card_Selection_Complete", card_selection_complete_listener);

		player_ready_listener = new UnityAction (play_sound_player_ready);
		EventManager.StartListening("HUD_Player_is_ready", player_ready_listener);

		spacecraft_collision_listener = new UnityAction (play_sound_spacecraft_collision);
		EventManager.StartListening("spacecraft_spacecraft_collision", spacecraft_collision_listener);
		EventManager.StartListening("spacecraft_planet_collision", spacecraft_collision_listener);

		spacecraft_boost_start_listener = new UnityAction (play_sound_spacecraft_boost);
		EventManager.StartListening("spacecraft_boost_start", spacecraft_boost_start_listener);

		spacecraft_boost_stop_listener = new UnityAction (stop_sound_spacecraft_boost);
		EventManager.StartListening("spacecraft_boost_stop", spacecraft_boost_stop_listener);

		simulation_stop_listener = new UnityAction (stop_simulation_reladed_sounds);
		EventManager.StartListening("stop_simulation", simulation_stop_listener);

		simulation_start_listener = new UnityAction (simulation_start_routine);
		EventManager.StartListening("start_simulation", simulation_start_listener);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void simulation_start_routine(){
		boostSoundStopped = false;
	}
	void stop_simulation_reladed_sounds(){
		GameObject.Find("Audio_Source_Spacecraft_Boost").GetComponent<AudioSource>().Stop();
	}

	void play_sound_card_selected(){
		GameObject.Find("Audio_Source_Card_Selected").GetComponent<AudioSource>().Play();
	}
	void play_sound_card_unselected(){
		GameObject.Find("Audio_Source_Card_Unselected").GetComponent<AudioSource>().Play();
	}
	void play_sound_card_selection_impossible(){
		GameObject.Find("Audio_Source_Card_Selection_Impossible").GetComponent<AudioSource>().Play();
	}
	void play_sound_card_selection_complete(){
		GameObject.Find("Audio_Source_Card_Selection_Complete").GetComponent<AudioSource>().Play();
	}
	void play_sound_player_ready(){
		GameObject.Find("Audio_Source_Player_Ready").GetComponent<AudioSource>().Play();
	}

	void play_sound_spacecraft_collision(){
		GameObject.Find("Audio_Source_Spacecraft_Collision").GetComponent<AudioSource>().Play();
	}
	void play_sound_spacecraft_boost(){		
		if(!this.boostSoundStopped){
			if (!GameObject.Find("Audio_Source_Spacecraft_Boost").GetComponent<AudioSource>().isPlaying){
				Debug.Log("Starting Boost Sound");
				GameObject.Find("Audio_Source_Spacecraft_Boost").GetComponent<AudioSource>().Play();
			}	
		}	
	}
	void stop_sound_spacecraft_boost(){
		Debug.Log("############## Stopping Boost Sound");
		GameObject.Find("Audio_Source_Spacecraft_Boost").GetComponent<AudioSource>().Stop();
		this.boostSoundStopped = true;
	}
}
