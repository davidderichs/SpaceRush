using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Help : MonoBehaviour {

	private Button help_Button;
	private GameObject mainMenu_Panel;
	private GameObject mainMenu_Tutorial_Canvas;

	private Button tutorial_Button_MainRules;
	private Button tutorial_Button_Checkpoints;
	private Button tutorial_Button_Spacecrafts;
	private Button tutorial_Button_Planets;
	private Button tutorial_Button_Movement;
	private Button tutorial_Button_Weapons;
	private Button tutorial_Button_Life;
	private Button tutorial_Button_Boost;
	private Button tutorial_Button_Collectables;
	private Image tutorial_Explaining_Image;

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
				this.help_Button.GetComponentInChildren<Text>().text = "Back to Menu";
				this.setup_Tutorial_Explaning_Image();
				this.setup_Tutorial_Buttons();

				
			} else {
				this.mainMenu_Panel.SetActive(true);
				this.mainMenu_Tutorial_Canvas.SetActive(false);
				this.help_Button.GetComponentInChildren<Text>().text = "Game Rules";
			}
			
		});
	}

	private void setup_Tutorial_Explaning_Image(){
		tutorial_Explaining_Image = GameObject.Find("Tutorial_Explaining_Image").GetComponent<Image>();
		set_Tutorial_Image_Source("Sprites/Tutorial_Images/MainRules");
	}
	private void setup_Tutorial_Buttons(){
		tutorial_Button_MainRules = GameObject.Find("Tutorial_Button_MainRules").GetComponent<Button>();
		tutorial_Button_MainRules.onClick.AddListener(delegate{
			set_Tutorial_Image_Source("");
		});

		tutorial_Button_Checkpoints = GameObject.Find("Tutorial_Button_Checkpoints").GetComponent<Button>();
		tutorial_Button_Checkpoints.onClick.AddListener(delegate{
			set_Tutorial_Image_Source("");
		});

		tutorial_Button_Spacecrafts = GameObject.Find("Tutorial_Button_Spacecrafts").GetComponent<Button>();
		tutorial_Button_Spacecrafts.onClick.AddListener(delegate{
			set_Tutorial_Image_Source("");
		});

		tutorial_Button_Planets = GameObject.Find("Tutorial_Button_Planets").GetComponent<Button>();
		tutorial_Button_Planets.onClick.AddListener(delegate{
			set_Tutorial_Image_Source("Sprites/Tutorial_Images/PlanetGray");
		});

		tutorial_Button_Movement = GameObject.Find("Tutorial_Button_Movement").GetComponent<Button>();
		tutorial_Button_Movement.onClick.AddListener(delegate{
			set_Tutorial_Image_Source("Sprites/Tutorial_Images/MovementSelection");
		});

		tutorial_Button_Weapons = GameObject.Find("Tutorial_Button_Weapons").GetComponent<Button>();
		tutorial_Button_Weapons.onClick.AddListener(delegate{
			set_Tutorial_Image_Source("Sprites/Tutorial_Images/WeaponSlots");
		});

		tutorial_Button_Life = GameObject.Find("Tutorial_Button_Life").GetComponent<Button>();
		tutorial_Button_Life.onClick.AddListener(delegate{
			set_Tutorial_Image_Source("Sprites/Tutorial_Images/Life");
		});

		tutorial_Button_Boost = GameObject.Find("Tutorial_Button_Boost").GetComponent<Button>();
		tutorial_Button_Boost.onClick.AddListener(delegate{
			set_Tutorial_Image_Source("Sprites/Tutorial_Images/FuelTankMain");
		});

		tutorial_Button_Collectables = GameObject.Find("Tutorial_Button_Collectables").GetComponent<Button>();
		tutorial_Button_Collectables.onClick.AddListener(delegate{
			set_Tutorial_Image_Source("");
		});
	}

	private void set_Tutorial_Image_Source(string path){
		this.tutorial_Explaining_Image.sprite = Resources.Load <Sprite>(path);
		this.tutorial_Explaining_Image.preserveAspect = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
