using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_Menu : MonoBehaviour {

	private Button button_continue;

	private Button button_restart;

	private Button button_exit_to_main;

	private Button button_exit_to_Windows;

	// Use this for initialization
	void Start () {
		button_continue = GameObject.Find("Pause_Menu_Button_Continue").GetComponent<Button>();
		button_restart = GameObject.Find("Pause_Menu_Button_Restart").GetComponent<Button>();
		button_exit_to_main = GameObject.Find("Pause_Menu_Button_Exit_To_Main").GetComponent<Button>();
		button_exit_to_Windows = GameObject.Find("Pause_Menu_Button_Exit_To_Windows").GetComponent<Button>();

		button_continue.onClick.AddListener(continue_game);
		button_restart.onClick.AddListener(restart_game);
		button_exit_to_main.onClick.AddListener(exit_to_main);
		button_exit_to_Windows.onClick.AddListener(exit_to_Windows);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void continue_game(){
		EventManager.TriggerEvent("Pause_Menu_Button_Continue_Clicked");
	}
	void restart_game(){
		EventManager.TriggerEvent("Pause_Menu_Button_Restart_Clicked");
	}
	void exit_to_main(){
		EventManager.TriggerEvent("Pause_Menu_Button_Exit_to_Main_Clicked");
	}
	void exit_to_Windows(){
		EventManager.TriggerEvent("Pause_Menu_Button_Exit_to_Windows_Clicked");	
	}
}
