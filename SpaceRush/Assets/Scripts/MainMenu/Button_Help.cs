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
	private Text tutorial_headline;
	private Text tutorial_text;

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
				this.setup_Tutorial_Texts();
				this.setup_Tutorial_Buttons();
				this.un_highlight_Tutorial_Buttons();
				this.highlight_Tutorial_Button(tutorial_Button_MainRules);
				this.change_tutorial_headline("Main Rules");
				this.change_tutorial_text("These are the main Rules: blablabla...");
				
			} else {
				this.mainMenu_Panel.SetActive(true);
				this.mainMenu_Tutorial_Canvas.SetActive(false);
				this.help_Button.GetComponentInChildren<Text>().text = "Game Rules";
			}
			
		});
	}

	private void change_tutorial_headline(string headlineText){
		tutorial_headline.text = headlineText;
	}

	private void change_tutorial_text(string text){
		tutorial_text.text = text;
	}

	private void setup_Tutorial_Texts(){
		tutorial_headline = GameObject.Find("Tutorial_Explaining_Headline").GetComponent<Text>();
		tutorial_text = GameObject.Find("Tutorial_Explaining_Text").GetComponent<Text>();
	}

	private void setup_Tutorial_Explaning_Image(){
		tutorial_Explaining_Image = GameObject.Find("Tutorial_Explaining_Image").GetComponent<Image>();
		set_Tutorial_Image_Source("Sprites/Tutorial_Images/MainRules");
	}
	private void setup_Tutorial_Buttons(){
		tutorial_Button_MainRules = GameObject.Find("Tutorial_Button_MainRules").GetComponent<Button>();
		tutorial_Button_MainRules.onClick.AddListener(delegate{
			set_Tutorial_Image_Source("");				
			this.un_highlight_Tutorial_Buttons();
			this.highlight_Tutorial_Button(tutorial_Button_MainRules);
			this.change_tutorial_headline("Main Rules");
			this.change_tutorial_text("These are the main Rules: blablabla...");
		});

		tutorial_Button_Checkpoints = GameObject.Find("Tutorial_Button_Checkpoints").GetComponent<Button>();
		tutorial_Button_Checkpoints.onClick.AddListener(delegate{
			set_Tutorial_Image_Source("");				
			this.un_highlight_Tutorial_Buttons();
			this.highlight_Tutorial_Button(tutorial_Button_Checkpoints);
			this.change_tutorial_headline("Checkpoints");
			this.change_tutorial_text("Checkpoints have to be reached. The player who first reached all Checkpoints wins the game.");
		});

		tutorial_Button_Spacecrafts = GameObject.Find("Tutorial_Button_Spacecrafts").GetComponent<Button>();
		tutorial_Button_Spacecrafts.onClick.AddListener(delegate{
			set_Tutorial_Image_Source("");				
			this.un_highlight_Tutorial_Buttons();
			this.highlight_Tutorial_Button(tutorial_Button_Spacecrafts);
			this.change_tutorial_headline("SpaceCrafts");
			this.change_tutorial_text("Spacecrafts are the players Avatar. They need to be moved around the playing area." +
			"Use Boosts and Rotation to move around.");
		});

		tutorial_Button_Planets = GameObject.Find("Tutorial_Button_Planets").GetComponent<Button>();
		tutorial_Button_Planets.onClick.AddListener(delegate{
			set_Tutorial_Image_Source("Sprites/Tutorial_Images/PlanetGray");				
			this.un_highlight_Tutorial_Buttons();
			this.highlight_Tutorial_Button(tutorial_Button_Planets);
			this.change_tutorial_headline("Planets");
			this.change_tutorial_text("Do not crush into Planets. It will cause you to loose live points. If you loose all life points the game is over.");
		});

		tutorial_Button_Movement = GameObject.Find("Tutorial_Button_Movement").GetComponent<Button>();
		tutorial_Button_Movement.onClick.AddListener(delegate{
			set_Tutorial_Image_Source("Sprites/Tutorial_Images/MovementSelection");				
			this.un_highlight_Tutorial_Buttons();
			this.highlight_Tutorial_Button(tutorial_Button_Movement);
			this.change_tutorial_headline("Movement");
			this.change_tutorial_text("Use Forward, Backward and Rotation to move your Spacecraft." + 
			"You can choose the amount of fuel to be used while boosting which increases throttle. Rotation costs no Fuel");
		});

		tutorial_Button_Weapons = GameObject.Find("Tutorial_Button_Weapons").GetComponent<Button>();
		tutorial_Button_Weapons.onClick.AddListener(delegate{
			set_Tutorial_Image_Source("Sprites/Tutorial_Images/WeaponSlots");				
			this.un_highlight_Tutorial_Buttons();
			this.highlight_Tutorial_Button(tutorial_Button_Weapons);
			this.change_tutorial_headline("Weapons");
			this.change_tutorial_text("Use Weapons in your Weapons slot in order to fire them during the round.");
		});

		tutorial_Button_Life = GameObject.Find("Tutorial_Button_Life").GetComponent<Button>();
		tutorial_Button_Life.onClick.AddListener(delegate{
			set_Tutorial_Image_Source("Sprites/Tutorial_Images/Life");				
			this.un_highlight_Tutorial_Buttons();
			this.highlight_Tutorial_Button(tutorial_Button_Life);
			this.change_tutorial_headline("Life");
			this.change_tutorial_text("Life is indicated in green color. All collitions and weapon based impacts cost life points." + 
			"If you loose all your life, the game is over.");
		});

		tutorial_Button_Boost = GameObject.Find("Tutorial_Button_Boost").GetComponent<Button>();
		tutorial_Button_Boost.onClick.AddListener(delegate{
			set_Tutorial_Image_Source("Sprites/Tutorial_Images/FuelTankMain");				
			this.un_highlight_Tutorial_Buttons();
			this.highlight_Tutorial_Button(tutorial_Button_Boost);
			this.change_tutorial_headline("Fuel & Boost");
			this.change_tutorial_text("The boost indicators show how much fuel you have left. Use fuel to fire your spacecraft boosters.");
		});

		tutorial_Button_Collectables = GameObject.Find("Tutorial_Button_Collectables").GetComponent<Button>();
		tutorial_Button_Collectables.onClick.AddListener(delegate{
			set_Tutorial_Image_Source("");				
			this.un_highlight_Tutorial_Buttons();
			this.highlight_Tutorial_Button(tutorial_Button_Collectables);
			this.change_tutorial_headline("Collectables");
			this.change_tutorial_text("You can collect items along your way. For example fuel items that you can use to fill up your fuel tanks." + 
			"You can also collect weapons which will then be available in your weapon slots.");
		});
	}

	void un_highlight_Tutorial_Buttons(){
		tutorial_Button_MainRules.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		tutorial_Button_Checkpoints.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		tutorial_Button_Spacecrafts.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		tutorial_Button_Planets.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		tutorial_Button_Movement.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		tutorial_Button_Weapons.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		tutorial_Button_Life.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		tutorial_Button_Boost.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		tutorial_Button_Collectables.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
	}

	void highlight_Tutorial_Button(Button clickedButton){
		clickedButton.transform.localScale += new Vector3(0.2f, 0.2f, 0.0f);
	}

	private void set_Tutorial_Image_Source(string path){
		this.tutorial_Explaining_Image.sprite = Resources.Load <Sprite>(path);
		this.tutorial_Explaining_Image.preserveAspect = true;
		this.tutorial_Explaining_Image.color = new Color32(255, 255, 255, 255);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
