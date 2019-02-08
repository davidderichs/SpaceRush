using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Help : MonoBehaviour {

	private Button help_Button;
	private GameObject mainMenu_Panel;
	private GameObject mainMenu_Tutorial_Canvas;

	// Use this for initialization
	void Start () {
		this.help_Button = GameObject.Find("Button_Help").GetComponent<Button>();
		this.mainMenu_Panel = GameObject.Find("MainMenu_Panel");
		this.mainMenu_Tutorial_Canvas = GameObject.Find("Tutorial_Canvas");
		this.mainMenu_Tutorial_Canvas.SetActive(false);

		help_Button.onClick.AddListener(delegate{
			if(this.mainMenu_Panel.activeSelf){
				this.mainMenu_Panel.SetActive(false);
				this.mainMenu_Tutorial_Canvas.SetActive(true);
				this.help_Button.GetComponentInChildren<Text>().text = "Close";
			} else {
				this.mainMenu_Panel.SetActive(true);
				this.mainMenu_Tutorial_Canvas.SetActive(false);
				this.help_Button.GetComponentInChildren<Text>().text = "Game Rules";
			}
			
		});
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
