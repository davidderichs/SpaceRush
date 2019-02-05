using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Settings : MonoBehaviour {

	Button settings_Button;

	Button player_1_blue;
	Button player_1_red;
	Button player_1_yellow;
	Button player_1_green;
	Button player_2_blue;
	Button player_2_red;
	Button player_2_yellow;
	Button player_2_green;

	GameObject settings_panel;

	GameObject player_1_settings_spacecraft;
	GameObject player_2_settings_spacecraft;

	bool settings_active;

	// Use this for initialization
	void Start () {

		player_1_settings_spacecraft = GameObject.Find("spacecraft_player_1");
		player_2_settings_spacecraft = GameObject.Find("spacecraft_player_2");

		Player_Stats.Player_1_color = new Color32(0,29,226,255);
		Player_Stats.Player_2_color = new Color32(195,170,0,255);

		player_1_blue = GameObject.Find("settings_player_1_color_blue").GetComponent<Button>();
		player_1_red = GameObject.Find("settings_player_1_color_red").GetComponent<Button>();
		player_1_yellow = GameObject.Find("settings_player_1_color_yellow").GetComponent<Button>();
		player_1_green = GameObject.Find("settings_player_1_color_green").GetComponent<Button>();

		player_2_blue = GameObject.Find("settings_player_2_color_blue").GetComponent<Button>();
		player_2_red = GameObject.Find("settings_player_2_color_red").GetComponent<Button>();
		player_2_yellow = GameObject.Find("settings_player_2_color_yellow").GetComponent<Button>();
		player_2_green = GameObject.Find("settings_player_2_color_green").GetComponent<Button>();


		player_1_blue.onClick.AddListener(delegate{
			player_1_Color(new Color32(0,29,226,255));
		});
		player_1_red.onClick.AddListener(delegate{
			player_1_Color(new Color32(255,0,0,255));
		});
		player_1_yellow.onClick.AddListener(delegate{
			player_1_Color(new Color32(195,170,0,255));
		});
		player_1_green.onClick.AddListener(delegate{
			player_1_Color(new Color32(10,166,0,255));
		});

		player_2_blue.onClick.AddListener(delegate{
			player_2_Color(new Color32(0,29,226,255));
		});
		player_2_red.onClick.AddListener(delegate{
			player_2_Color(new Color32(255,0,0,255));
		});
		player_2_yellow.onClick.AddListener(delegate{
			player_2_Color(new Color32(195,170,0,255));
		});
		player_2_green.onClick.AddListener(delegate{
			player_2_Color(new Color32(10,166,0,255));
		});


		settings_Button = this.GetComponent<Button>();
        settings_Button.onClick.AddListener(TaskOnClick);
		settings_active = false;
		Debug.Log("Settings_Panel inactive");
		settings_panel = GameObject.Find("Settings_Panel");
		settings_panel.SetActive(false);
	}

	void Update(){
		player_1_settings_spacecraft.GetComponent<MeshRenderer>().material.color = Player_Stats.Player_1_color;
		player_2_settings_spacecraft.GetComponent<MeshRenderer>().material.color = Player_Stats.Player_2_color;
	}

	void player_1_Color(Color32 color){
		Player_Stats.Player_1_color = color;
	}

	void player_2_Color(Color32 color){
		Player_Stats.Player_2_color = color;
	}
	
    void TaskOnClick()
    {		
		if(settings_active){
			settings_active = false;			
			settings_panel.SetActive(false);
		} else{
			settings_active = true;
			settings_panel.SetActive(true);
		}
    }
}
