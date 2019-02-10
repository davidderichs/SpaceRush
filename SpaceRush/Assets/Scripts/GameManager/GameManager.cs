using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, ISpacecraftCollisionListener, ITickable
{

    private static GameManager instance;
    private StateMachine stateMachine;

    private bool gamePaused;
    public int start_checkpoint;
    public Player player_1;

    public Player player_2;

    private Player acti_player;
    private TickTimer tickTimer;
    private List<Spacecraft> spacecrafts;

    public GameObject Win_Loose_Screen;
    private UnityAction win_Loose_Screen_restart_listener;
    private UnityAction win_Loose_Screen_exit_to_Main_listener;
    private UnityAction win_Loose_Screen_exit_to_Windows_listener;
    public bool gameHasEnded;

    public GameObject Pause_Menu;

    private UnityAction pause_Menu_continue_listener;
    private UnityAction pause_Menu_restart_listener;
    private UnityAction pause_Menu_exit_to_Main_listener;
    private UnityAction pause_Menu_exit_to_Windows_listener;

    private UnityAction player_live_listener;
    private UnityAction player_main_fuel_listener;
    private UnityAction player_add_fuel_listener;
    private UnityAction player_shield_listener;
    private UnityAction player_card_stack_listener;
    private UnityAction player_card_selection_listener;
    private UnityAction player_ready_listener;

    private UnityAction player_1_reset;

    private UnityAction player_2_reset;

    private UnityAction player_1_loose;

    private UnityAction player_2_loose;

    private UnityAction player_Weapon_Listener;

    private UnityAction player_indicator;

    private CameraController camera;

    private UnityAction player_selection_complete_listener;
    private UnityAction player_selection_incomplete_listener;

    private HUD hud;


    // collection for simulated Objects
    private List<SimulatedObject> simulatedObjects;

    void Awake()
    {
        instance = this;
        
        player_live_listener = new UnityAction(propagate_Player_live_change);
        EventManager.StartListening("Player_Live_Has_Changed", player_live_listener);

        player_main_fuel_listener = new UnityAction(propagate_Player_main_fuel_change);
        EventManager.StartListening("Player_Main_Fuel_Has_Changed", player_main_fuel_listener);

        player_add_fuel_listener = new UnityAction(propagate_Player_add_fuel_change);
        EventManager.StartListening("Player_Add_Fuel_Has_Changed", player_add_fuel_listener);

        player_shield_listener = new UnityAction(propagate_Player_shield_change);
        EventManager.StartListening("Player_Shield_Has_Changed", player_shield_listener);

        player_card_stack_listener = new UnityAction(propagate_Player_stack_change);
        EventManager.StartListening("Player_Card_Stack_Changed", player_card_stack_listener);

        player_card_selection_listener = new UnityAction(propagate_Player_Selection_change);
        EventManager.StartListening("Player_Card_Selection_Changed", player_card_selection_listener);

        player_selection_complete_listener = new UnityAction(propagate_Player_Selection_complete);
        EventManager.StartListening("Player_Card_Selection_Complete", player_selection_complete_listener);

        player_selection_incomplete_listener = new UnityAction(propagate_Player_Selection_incomplete);
        EventManager.StartListening("Player_Card_Selection_Incomplete", player_selection_incomplete_listener);

        player_ready_listener = new UnityAction(propagate_Player_ready);
        EventManager.StartListening("HUD_Player_is_ready", player_ready_listener);

        player_1_reset = new UnityAction(propagate_Player_1_reset);
        EventManager.StartListening("Player_1_reset", player_1_reset);

        player_2_reset = new UnityAction(propagate_Player_2_reset);
        EventManager.StartListening("Player_2_reset", player_2_reset);

        player_1_loose = new UnityAction(propagate_player_1_loosing);
        EventManager.StartListening("Player_1_lost", player_1_loose);

        player_2_loose = new UnityAction(propagate_player_2_loosing);
        EventManager.StartListening("Player_2_lost", player_2_loose);

        player_indicator = new UnityAction(propagate_Indicator_change);
        EventManager.StartListening("Player_Indicator_Change", player_indicator);

        tickTimer = gameObject.AddComponent<TickTimer>();
        tickTimer.SetProperties(this, 2, 5);

        spacecrafts = new List<Spacecraft>();
        Spacecraft spacecraft1 = GameObject.Find("Spacecraft1").GetComponent<Spacecraft>();
        Spacecraft spacecraft2 = GameObject.Find("Spacecraft2").GetComponent<Spacecraft>();
        spacecraft1.AddCollisionListener(this);
        spacecraft2.AddCollisionListener(this);
        spacecrafts.Add(spacecraft1);
        spacecrafts.Add(spacecraft2);

        camera = GameObject.Find("Main Camera").GetComponent<CameraController>();

        gameHasEnded = false;

        Win_Loose_Screen = GameObject.Find("Win_Loose_Screen");
        Win_Loose_Screen.gameObject.SetActive(false);

        win_Loose_Screen_restart_listener = new UnityAction(restartScene);
        EventManager.StartListening("Win_Loose_Screen_Button_Restart_Clicked", win_Loose_Screen_restart_listener);

        win_Loose_Screen_exit_to_Main_listener = new UnityAction(exit_to_MainMenu);
        EventManager.StartListening("Win_Loose_Screen_Button_Exit_to_Main_Clicked", win_Loose_Screen_exit_to_Main_listener);

        win_Loose_Screen_exit_to_Windows_listener = new UnityAction(close_Application);
        EventManager.StartListening("Win_Loose_Screen_Button_Exit_to_Windows_Clicked", win_Loose_Screen_exit_to_Windows_listener);


        Pause_Menu = GameObject.Find("Pause_Menu");
        resume();

        pause_Menu_continue_listener = new UnityAction(resume);
        EventManager.StartListening("Pause_Menu_Button_Continue_Clicked", pause_Menu_continue_listener);

        pause_Menu_restart_listener = new UnityAction(restartScene);
        EventManager.StartListening("Pause_Menu_Button_Restart_Clicked", pause_Menu_restart_listener);

        pause_Menu_exit_to_Main_listener = new UnityAction(exit_to_MainMenu);
        EventManager.StartListening("Pause_Menu_Button_Exit_to_Main_Clicked", pause_Menu_exit_to_Main_listener);

        pause_Menu_exit_to_Windows_listener = new UnityAction(close_Application);
        EventManager.StartListening("Pause_Menu_Button_Exit_to_Windows_Clicked", pause_Menu_exit_to_Windows_listener);

        // initializing the list for all simulated objects
        simulatedObjects = new List<SimulatedObject>();

        foreach (SimulatedObject simulatedObject in spacecrafts)
        {
            AddSimulatedObject(simulatedObject);
        }
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    void pause()
    {
        Debug.Log("pausing game");
        Pause_Menu.gameObject.SetActive(true);
        gamePaused = true;
    }

    void resume()
    {
        Debug.Log("resuming game");
        Pause_Menu.gameObject.SetActive(false);
        gamePaused = false;
    }

    void restartScene()
    {
        SceneManager.LoadScene("FinalScene");
    }

    void exit_to_MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void close_Application()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (gamePaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    void Start()
    {
        if (this.stateMachine == null)
        {
            this.stateMachine = new StateMachine();
        }
        hud = GameObject.FindWithTag("HUD").GetComponent<HUD>();
        player_1 = GameObject.Find("Player1").GetComponent<Player>();
        player_2 = GameObject.Find("Player2").GetComponent<Player>();
        setActivePlayer(player_1);
        SelectStart();
        // player_1.space.gameObject.GetComponent<MeshRenderer>().material.color = player_1.playerColor;
        player_1.space.gameObject.GetComponentsInChildren<Light>()[0].color = player_1.playerColor;
        // player_2.space.gameObject.GetComponent<MeshRenderer>().material.color = player_2.playerColor;
        player_2.space.gameObject.GetComponentsInChildren<Light>()[0].color = player_2.playerColor;
        Vector3 start = new Vector3(this.player_1.space.transform.position.x, this.player_1.space.transform.position.y, -400);
        this.camera.transform.position = start;
        settingHUDIndicators();
        StopSimulation();
        hud.show();
    }

    void settingHUDIndicators()
    {
        propagate_Player_Selection_change();
        propagate_Player_add_fuel_change();
        propagate_Player_live_change();
        propagate_Player_main_fuel_change();
        propagate_Player_shield_change();
        propagate_Player_stack_change();
    }

    void propagate_Player_Selection_complete()
    {
        this.hud.activate_Ready_Button();
    }
    void propagate_Player_Selection_incomplete()
    {
        this.hud.deactivate_Ready_Button();
    }

    void propagate_Player_ready()
    {
        propagate_Player_Selection_incomplete();
        propagate_Player_change();
        StartStateMachine();
    }

    public void checkpointTriggered(int id, Player player)
    {
        player_1.addCheckpoint(id);
    }
    void propagate_Player_live_change()
    {
        this.hud.live.set_ActiveItemsColor(this.acti_player.lives);
    }
    void propagate_Player_main_fuel_change()
    {
        this.hud.main_fuel.set_ActiveItemsColor((int)this.acti_player.mainFuel);
    }
    void propagate_Player_add_fuel_change()
    {
        this.hud.add_fuel.set_ActiveItemsColor((int)this.acti_player.addFuel);
    }
    void propagate_Player_shield_change()
    {
        this.hud.shield.set_ActiveItemsColor(this.acti_player.shields);
    }
    void propagate_Player_stack_change()
    {
        this.hud.actionStack.SetActionCards(this.acti_player.actionStack);
        this.hud.selectedAction.SetActionCards(this.acti_player.actionSelection);
    }
    void propagate_Player_Selection_change()
    {
        this.hud.actionStack.SetActionCards(this.acti_player.actionStack);
        this.hud.selectedAction.SetActionCards(this.acti_player.actionSelection);
    }

    void propagate_Player_change()
    {
        if (acti_player == player_1)
        {
            setActivePlayer(player_2);  //change Player fehlt
            this.hud.actionStack.changePlayer(2);
            this.hud.selectedAction.changePlayer(2);
        }
        else
        {
            setActivePlayer(player_1);
            this.hud.actionStack.changePlayer(1);
            this.hud.selectedAction.changePlayer(1);
        }
        camera.SetState(new CameraAnimateToState(camera, acti_player.space.transform.position, 0.5f, new CameraNavigationState(camera)));
        propagate_Player_live_change();
        propagate_Player_shield_change();
        propagate_Player_main_fuel_change();
        propagate_Player_add_fuel_change();
        propagate_Player_Selection_change();
        propagate_Player_stack_change();
    }

    void propagate_Player_1_reset()
    {
        resetPlayer(player_1);
    }

    void propagate_Player_2_reset()
    {
        resetPlayer(player_2);
    }

    private void propagate_player_1_loosing()
    {
        Win_Loose_Screen.gameObject.SetActive(true);
        gameHasEnded = true;
        GameObject.Find("Win_Loose_Text").GetComponent<Text>().text = "Player 2 has won the game";
    }
    private void propagate_player_2_loosing()
    {
        Win_Loose_Screen.gameObject.SetActive(true);
        gameHasEnded = true;
        GameObject.Find("Win_Loose_Text").GetComponent<Text>().text = "Player 1 has won the game";
    }

    private void propagate_Indicator_change()
    {
        propagate_Player_stack_change();
        propagate_Player_add_fuel_change();
        propagate_Player_live_change();
        propagate_Player_main_fuel_change();
        propagate_Player_shield_change();
    }

    public void resetPlayer(Player player)
    {
        string last = "Checkpoint" + player.getLastCheckpoint();
        player.space.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        player.space.GetComponent<Rigidbody2D>().angularVelocity = 0;
        Checkpoint check = GameObject.Find(last).GetComponent<Checkpoint>();
        if (check.isFull == false)
            player.space.transform.position = check.transform.position;
        else
            player.space.transform.position = new Vector3(check.transform.position.x, check.transform.position.y + 30, check.transform.position.z);
    }

    public void OnSpacecraftCollision(Spacecraft spacecraft, GameObject collider)
    {
        // Debug.Log(spacecraft.name + " collided with " + collider.name);

        if (collider.tag.Equals("planet"))
        {
            EventManager.TriggerEvent("spacecraft_planet_collision");
            spacecraft.player.looseLive(3);
            resetPlayer(spacecraft.player);
        }
        if (collider.tag.Equals("spacecraft"))
        {
            EventManager.TriggerEvent("spacecraft_planet_collision");
            spacecraft.player.looseLive(1);
            //resetPlayer(spacecraft.player);
        }
    }

    public void PlayerWon(Player player)
    {
        if (player_1 == player)
            propagate_player_2_loosing();
        else 
            propagate_player_1_loosing();
    }

    public void Tick(bool done)
    {
        if (done)
        {
            //Debug.Log("DONE.");
            StopSimulation();
            foreach (Spacecraft spacecraft in spacecrafts)
            {
                spacecraft.player.resetFuel();
                spacecraft.player.actionSelection.actionList.Clear();
                spacecraft.player.ResetCounter();
            }
            propagate_Indicator_change();
        }
        else
        {
            //Debug.Log("Tick");
            foreach (Spacecraft spacecraft in spacecrafts)
            {
                spacecraft.StartNextAction();
            }
        }
    }

    private void StartSimulation()
    {
        Debug.Log("Starting Simulation");
        this.hud.hide();
        foreach (SimulatedObject simulatedObject in simulatedObjects)
        {
            simulatedObject.Play();
        }
        camera.FollowObjects(new List<GameObject>() { spacecrafts[0].gameObject, spacecrafts[1].gameObject });
        tickTimer.StartTimer();
    }

    private void StopSimulation()
    {
        Debug.Log("Stopping Simulation");
        foreach (SimulatedObject simulatedObject in simulatedObjects)
        {
            simulatedObject.Pause();
        }
        camera.SetState(new CameraAnimateToState(camera, acti_player.space.transform.position, 0.5f, new CameraNavigationState(camera))); ;
        this.hud.show();
    }

    private void SelectStart()
    {
        string start = "Checkpoint" + start_checkpoint;
        Vector3 starting = GameObject.Find(start).GetComponent<Checkpoint>().transform.position;
        Vector3 startin = new Vector3(starting.x, starting.y + 20, starting.z);
        starting = new Vector3(starting.x, starting.y - 20, starting.z);
        player_1.addCheckpoint(start_checkpoint);
        player_2.addCheckpoint(start_checkpoint);
        player_1.space.transform.position = starting;
        player_2.space.transform.position = startin;
    }

    private void Gameloop()
    {
        foreach (Spacecraft spacecraft in spacecrafts)
        {
            ActionStack cards = spacecraft.player.actionSelection;
            for (int i = 0; i < cards.actionList.Count; i++)
            {
                SpacecraftAction action = CardParser.ParseCard(cards.getActionCard(i));
                spacecraft.AddAction(action);
            }
        }
    }

    void setActivePlayer(Player player)
    {
        acti_player = player;
        hud.setHUDColor(player.playerColor);
    }

    private void StartStateMachine()
    {
        //Debug.Log(stateMachine.getState());
        if (stateMachine.getState() == 3)
        {
            Gameloop();
            StartSimulation();
            stateMachine.setState(1);
        }
        else
        {
            if (stateMachine.getState() != 4)
            {
                stateMachine.nextState();
                propagate_Player_stack_change();
                if (stateMachine.getState() == 3)
                {
                    StartStateMachine();
                }
            }
        }
    }

    public void AddSimulatedObject(SimulatedObject simulatedObject)
    {
        simulatedObjects.Add(simulatedObject);
    }

    public void RemoveSimulatedObject(SimulatedObject simulatedObject)
    {
        simulatedObjects.Remove(simulatedObject);
        Destroy(simulatedObject.gameObject);
    }

}