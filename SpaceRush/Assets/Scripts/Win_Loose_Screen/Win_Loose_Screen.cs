using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win_Loose_Screen : MonoBehaviour {

	private Button button_restart;

	private Button button_exit_to_main;

	private Button button_exit_to_Windows;

	// Use this for initialization
	void Start () {
		button_restart = GameObject.Find("Win_Loose_Screen_Button_Restart").GetComponent<Button>();
		button_exit_to_main = GameObject.Find("Win_Loose_Screen_Button_Exit_To_Main").GetComponent<Button>();
		button_exit_to_Windows = GameObject.Find("Win_Loose_Screen_Button_Exit_To_Windows").GetComponent<Button>();

		button_restart.onClick.AddListener(restart_game);
		button_exit_to_main.onClick.AddListener(exit_to_main);
		button_exit_to_Windows.onClick.AddListener(exit_to_Windows);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void restart_game(){
		EventManager.TriggerEvent("Win_Loose_Screen_Button_Restart_Clicked");
	}
	void exit_to_main(){
		EventManager.TriggerEvent("Win_Loose_Screen_Button_Exit_to_Main_Clicked");
	}
	void exit_to_Windows(){
		EventManager.TriggerEvent("Win_Loose_Screen_Button_Exit_to_Windows_Clicked");	
	}
}
