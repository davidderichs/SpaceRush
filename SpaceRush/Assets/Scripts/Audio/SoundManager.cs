using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundManager : MonoBehaviour {

	private UnityAction card_selected_listener;
	private UnityAction card_unselected_listener;
	private UnityAction card_selection_impossible;
	private UnityAction player_ready_listener;
	private UnityAction spacecraft_collition_listener;
	private UnityAction spacecraft_boost_start_listener;
	private UnityAction spacecraft_boost_stop_listener;

	// Use this for initialization
	void Start () {
		card_selected_listener = new UnityAction (play_sound_card_selected);
		EventManager.StartListening("HUD_Card_Stack_Item_Selected", card_selected_listener);

		card_selection_impossible = new UnityAction (play_sound_card_selection_impossible);
		EventManager.StartListening("HUD_Card_Selection_Impossible", card_selection_impossible);

		card_unselected_listener = new UnityAction (play_sound_card_unselected);
		EventManager.StartListening("HUD_Card_Stack_Item_Unselected", card_unselected_listener);

		player_ready_listener = new UnityAction (play_sound_card_selection_complete);
		EventManager.StartListening("Player_Card_Selection_Complete", player_ready_listener);

		spacecraft_collition_listener = new UnityAction (play_sound_spacecraft_collition);
		EventManager.StartListening("spacecraft_spacecraft_collision", spacecraft_collition_listener);

		spacecraft_boost_start_listener = new UnityAction (play_sound_spacecraft_boost);
		EventManager.StartListening("spacecraft_boost_start", spacecraft_boost_start_listener);

		spacecraft_boost_stop_listener = new UnityAction (play_sound_spacecraft_boost);
		EventManager.StartListening("spacecraft_boost_start", spacecraft_boost_stop_listener);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void play_sound_card_selected(){
		// this.HUD_Button_Ready.GetComponentInChildren<Text>().color = new Color32(255, 255, 255, 255);
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
	void play_sound_spacecraft_collition(){
		GameObject.Find("Audio_Source_Spacecraft_Collition").GetComponent<AudioSource>().Play();
	}
	void play_sound_spacecraft_boost(){

	}
	void stop_sound_spacecraft_boost(){

	}
}
