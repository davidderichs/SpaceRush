using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Quit : MonoBehaviour {

	Button quit_Button;

	// Use this for initialization
	void Start () {
		quit_Button = this.GetComponent<Button>();
        quit_Button.onClick.AddListener(TaskOnClick);
	}
	
	// Update is called once per frame
    void TaskOnClick()
    {		
		Application.Quit();
    }
}
