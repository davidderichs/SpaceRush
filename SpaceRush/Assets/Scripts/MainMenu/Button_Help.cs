using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Help : MonoBehaviour
{

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
    private Image tutorial_Explaining_Image;
    private Text tutorial_headline;
    private Text tutorial_text;

    // Use this for initialization
    void Start()
    {
        this.help_Button = GameObject.Find("Button_Help").GetComponent<Button>();
        this.mainMenu_Panel = GameObject.Find("MainMenu_Panel");
        this.mainMenu_Tutorial_Canvas = GameObject.Find("Tutorial_Canvas");
        this.mainMenu_Tutorial_Canvas.SetActive(false);

        help_Button.onClick.AddListener(delegate
        {
            if (this.mainMenu_Panel.activeSelf)
            {
                this.mainMenu_Panel.SetActive(false);
                this.mainMenu_Tutorial_Canvas.SetActive(true);
                this.help_Button.GetComponentInChildren<Text>().text = "Back to Menu";
                this.setup_Tutorial_Explaning_Image();
                this.setup_Tutorial_Texts();
                this.setup_Tutorial_Buttons();
                this.un_highlight_Tutorial_Buttons();
                this.highlight_Tutorial_Button(tutorial_Button_MainRules);
                this.change_tutorial_headline("Goal");
                this.change_tutorial_text("The Mission is to reach all checkpoints faster than the opponent by tactical use of movements, fuel, weapons, items and health. Survive by avoiding crashes with planets attacks of the opponent or other dangers in this foreign galaxy.");

            }
            else
            {
                this.mainMenu_Panel.SetActive(true);
                this.mainMenu_Tutorial_Canvas.SetActive(false);
                this.help_Button.GetComponentInChildren<Text>().text = "Game Rules";
            }

        });
    }

    private void change_tutorial_headline(string headlineText)
    {
        tutorial_headline.text = headlineText;
    }

    private void change_tutorial_text(string text)
    {
        tutorial_text.text = text;
    }

    private void setup_Tutorial_Texts()
    {
        tutorial_headline = GameObject.Find("Tutorial_Explaining_Headline").GetComponent<Text>();
        tutorial_text = GameObject.Find("Tutorial_Explaining_Text").GetComponent<Text>();
    }

    private void setup_Tutorial_Explaning_Image()
    {
        tutorial_Explaining_Image = GameObject.Find("Tutorial_Explaining_Image").GetComponent<Image>();
        set_Tutorial_Image_Source("");
        this.tutorial_Explaining_Image.color = new Color32(255, 255, 255, 0);
    }
    private void setup_Tutorial_Buttons()
    {
        tutorial_Button_MainRules = GameObject.Find("Tutorial_Button_MainRules").GetComponent<Button>();
        tutorial_Button_MainRules.onClick.AddListener(delegate
        {
            set_Tutorial_Image_Source("Sprites/Tutorial_Images/Main");
            this.un_highlight_Tutorial_Buttons();
            this.highlight_Tutorial_Button(tutorial_Button_MainRules);
            this.change_tutorial_headline("Goal");
            this.change_tutorial_text("The Mission is to reach all checkpoints faster than the opponent by tactical use of movements, fuel, weapons, items and health. Survive by avoiding crashes with planets attacks of the opponent or other dangers in this foreign galaxy.");
        });

        tutorial_Button_Checkpoints = GameObject.Find("Tutorial_Button_Checkpoints").GetComponent<Button>();
        tutorial_Button_Checkpoints.onClick.AddListener(delegate
        {
            set_Tutorial_Image_Source("Sprites/Tutorial_Images/Checkpoints");
            this.un_highlight_Tutorial_Buttons();
            this.highlight_Tutorial_Button(tutorial_Button_Checkpoints);
            this.change_tutorial_headline("Checkpoints");
            this.change_tutorial_text("If a checkpoint is reached they'll be marked with the colour of the player. The last reached checkpoint is used as a respawn point if the players ship is destroyed.");
        });

        tutorial_Button_Spacecrafts = GameObject.Find("Tutorial_Button_Spacecrafts").GetComponent<Button>();
        tutorial_Button_Spacecrafts.onClick.AddListener(delegate
        {
            set_Tutorial_Image_Source("Sprites/Tutorial_Images/Spacecrafts");
            this.un_highlight_Tutorial_Buttons();
            this.highlight_Tutorial_Button(tutorial_Button_Spacecrafts);
            this.change_tutorial_headline("Spacecrafts");
            this.change_tutorial_text("Spacecrafts are used as the players avatar. Spacecrafts are equipped with weapons, a protective shield and extra fuel. The avatar can be moved with the use of the movement actions: Forward, Backward and Rotation.");
        });

        tutorial_Button_Planets = GameObject.Find("Tutorial_Button_Planets").GetComponent<Button>();
        tutorial_Button_Planets.onClick.AddListener(delegate
        {
            set_Tutorial_Image_Source("Sprites/Tutorial_Images/PlanetGray");
            this.un_highlight_Tutorial_Buttons();
            this.highlight_Tutorial_Button(tutorial_Button_Planets);
            this.change_tutorial_headline("Planets");
            this.change_tutorial_text("The Planets with their gravity should be avoided at all cost. If a player crashes with a planet, the player will lose some of his health and respawn at the last claimed checkpoint.");
        });

        tutorial_Button_Movement = GameObject.Find("Tutorial_Button_Movement").GetComponent<Button>();
        tutorial_Button_Movement.onClick.AddListener(delegate
        {
            set_Tutorial_Image_Source("Sprites/Tutorial_Images/Movements");
            this.un_highlight_Tutorial_Buttons();
            this.highlight_Tutorial_Button(tutorial_Button_Movement);
            this.change_tutorial_headline("Movement");
            this.change_tutorial_text("The movement actions: Forward, Backward, Rotation, allow the spacecraft to move through the galaxy. Each action costs fuel and the cost depends on the selected action. Forward and Backward can cost up to 6 fuel, while the cost of Rotation remains at 1 Fuel. The intensity of the movements are shown over the cards and the fuel cost are shown under the card. The motion can be slowed down by using the opposite movement action.");
        });

        tutorial_Button_Weapons = GameObject.Find("Tutorial_Button_Weapons").GetComponent<Button>();
        tutorial_Button_Weapons.onClick.AddListener(delegate
        {
            set_Tutorial_Image_Source("Sprites/Tutorial_Images/Weapons");
            this.un_highlight_Tutorial_Buttons();
            this.highlight_Tutorial_Button(tutorial_Button_Weapons);
            this.change_tutorial_headline("Weapons");
            this.change_tutorial_text("Weapons as rockets and mines can be collected across the galaxy. Weapons are used to damage the opponent or push them around.");
        });

        tutorial_Button_Life = GameObject.Find("Tutorial_Button_Life").GetComponent<Button>();
        tutorial_Button_Life.onClick.AddListener(delegate
        {
            set_Tutorial_Image_Source("Sprites/Tutorial_Images/Life");
            this.un_highlight_Tutorial_Buttons();
            this.highlight_Tutorial_Button(tutorial_Button_Life);
            this.change_tutorial_headline("Health & Shield");
            this.change_tutorial_text("The health is shown at the bottom of the left corner and the shield is shown on the right corner. Health and shield decreases if you take damage and if the player loses all the health they'll lose the game.");
        });

        tutorial_Button_Boost = GameObject.Find("Tutorial_Button_Boost").GetComponent<Button>();
        tutorial_Button_Boost.onClick.AddListener(delegate
        {
            set_Tutorial_Image_Source("Sprites/Tutorial_Images/Items");
            this.un_highlight_Tutorial_Buttons();
            this.highlight_Tutorial_Button(tutorial_Button_Boost);
            this.change_tutorial_headline("Items");
            this.change_tutorial_text("These items can be collected through the galaxy: \r\nRepair: restores up to 3 health\r\nShield: restores up to 2 shield\r\nFuel: restores up to 5 fuel");
        });
    }

    void un_highlight_Tutorial_Buttons()
    {
        tutorial_Button_MainRules.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        tutorial_Button_Checkpoints.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        tutorial_Button_Spacecrafts.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        tutorial_Button_Planets.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        tutorial_Button_Movement.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        tutorial_Button_Weapons.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        tutorial_Button_Life.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        tutorial_Button_Boost.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    void highlight_Tutorial_Button(Button clickedButton)
    {
        clickedButton.transform.localScale += new Vector3(0.2f, 0.2f, 0.0f);
    }

    private void set_Tutorial_Image_Source(string path)
    {
        this.tutorial_Explaining_Image.sprite = Resources.Load<Sprite>(path);
        this.tutorial_Explaining_Image.preserveAspect = true;
        this.tutorial_Explaining_Image.color = new Color32(255, 255, 255, 255);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
