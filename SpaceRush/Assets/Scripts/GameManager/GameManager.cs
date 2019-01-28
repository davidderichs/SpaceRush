using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour, ISpacecraftCollisionListener, ITickable
{

    private StateMachine stateMachine;
    public int start_checkpoint;
    public Player player_1;

    public Player player_2;

    private Player acti_player;
    private TickTimer tickTimer;
    private List<Spacecraft> spacecrafts;
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

    private CameraController camera;

    private UnityAction player_selection_complete_listener;
    private UnityAction player_selection_incomplete_listener;

    // Use this for initialization

    private HUD hud;

    void Awake()
    {
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

        player_ready_listener = new UnityAction(propagate_Player_ready);
        EventManager.StartListening("HUD_Player_is_ready", player_ready_listener);

        player_1_reset = new UnityAction(propagate_Player_1_reset);
        EventManager.StartListening("Player_1_reset", player_1_reset);

        player_2_reset = new UnityAction(propagate_Player_2_reset);
        EventManager.StartListening("Player_2_reset", player_2_reset);

        player_1_loose = new UnityAction(propagate_player_1_loosing);
        EventManager.StartListening("Player_1_lost", player_1_loose);

        player_2_loose = new UnityAction(propagate_player_2_loosing);
        EventManager.StartListening("Player_1_lost", player_2_loose);

        Spacecraft.AddCollisionListener(this);

        tickTimer = gameObject.AddComponent<TickTimer>();
        tickTimer.SetProperties(this, 2, 5);

        spacecrafts = new List<Spacecraft>();
        spacecrafts.Add(GameObject.Find("Spacecraft").GetComponent<Spacecraft>());
        spacecrafts.Add(GameObject.Find("Spacecraft2").GetComponent<Spacecraft>());

        camera = GameObject.Find("Main Camera").GetComponent<CameraController>();
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
        player_1.space.gameObject.GetComponent<MeshRenderer>().material.color = player_1.playerColor;
        player_2.space.gameObject.GetComponent<MeshRenderer>().material.color = player_2.playerColor;
        Vector3 start = new Vector3(this.player_1.space.transform.position.x, this.player_1.space.transform.position.y, -400);
        this.camera.transform.position = start;
        propagate_Player_stack_change();
        StopSimulation();
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
    void Update()
    {
        // ONLY TESTING when simulation stopped -> reenable physics with klick on space
        /*if (Input.GetKeyDown("space"))
        {
            StartSimulation();
        } */
    }
    void propagate_Player_live_change()
    {
        this.hud.live.set_ActiveItemsColor(this.acti_player.lives);
    }
    void propagate_Player_main_fuel_change()
    {
        this.hud.main_fuel.set_ActiveItemsColor(this.acti_player.main_fuel);
    }
    void propagate_Player_add_fuel_change()
    {
        this.hud.add_fuel.set_ActiveItemsColor(this.acti_player.add_fuel);
    }
    void propagate_Player_shield_change()
    {
        this.hud.shield.set_ActiveItemsColor(this.acti_player.shields);
    }
    void propagate_Player_stack_change()
    {
        this.hud.card_stack.set_MoveCards(this.acti_player.card_Stack);
        this.hud.selected_cards.set_MoveCards(this.acti_player.card_Selection);
    }
    void propagate_Player_Selection_change()
    {
        this.hud.card_stack.set_MoveCards(this.acti_player.card_Stack);
        this.hud.selected_cards.set_MoveCards(this.acti_player.card_Selection);
    }

    void propagate_Player_change()
    {
        if (acti_player == player_1)
        {
            acti_player.m_number_of_cards = 0;
            acti_player = player_2;
            this.hud.card_stack.changePlayer(2);
            this.hud.selected_cards.changePlayer(2);
        }
        else
        {
            acti_player.m_number_of_cards = 0;
            acti_player = player_1;
            this.hud.card_stack.changePlayer(1);
            this.hud.selected_cards.changePlayer(1);

        }
        camera.AnimateTo(acti_player.space.transform.position);
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
        Debug.Log("Player 1 Lost");
    }
    private void propagate_player_2_loosing()
    {
        Debug.Log("Player 2 Lost");
    }


    public void resetPlayer(Player player)
    {
        string last = "Checkpoint" + player.getLastCheckpoint();
        player.space.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        player.space.GetComponent<Rigidbody2D>().angularVelocity = 0;
        player.space.transform.position = GameObject.Find(last).GetComponent<Checkpoint>().transform.position;
    }

    public void OnSpacecraftCollision(Spacecraft spacecraft, GameObject collider)
    {
        Debug.Log(spacecraft.name + " collided with " + collider.name);

        if (collider.name.Contains("planet"))
        {
            EventManager.TriggerEvent("spacecraft_planet_collision");
            spacecraft.player.looseLive(3);
            resetPlayer(spacecraft.player);
        }
        if (collider.name.Contains("moon"))
        {
            EventManager.TriggerEvent("spacecraft_planet_collision");
            spacecraft.player.looseLive(2);
            resetPlayer(spacecraft.player);
        }
        if (collider.name.Contains("Spacecraft"))
        {
            EventManager.TriggerEvent("spacecraft_planet_collision");
            spacecraft.player.looseLive(1);
            resetPlayer(spacecraft.player);
        }
    }

    public void Tick(bool done)
    {
        if (done)
        {
            //Debug.Log("DONE.");
            StopSimulation();
            foreach(Spacecraft spacecraft in spacecrafts){
                resetCards(spacecraft.player);
                spacecraft.player.resetFuel();
            }
            propagate_Player_stack_change();
            Debug.Log(acti_player.getWeapon(1));
        }
        else
        {
            //Debug.Log("Tick");
            foreach (Spacecraft spacecraft in spacecrafts)
            {
                spacecraft.StartNextAction();
                this.hud.card_stack.hide();
            }
        }
    }

    private void StartSimulation()
    {
        Debug.Log("Starting Simulation");
        foreach (Spacecraft spacecraft in spacecrafts)
        {
            spacecraft.StartPhysics();
        }
        camera.FollowObjects(new List<GameObject>() { spacecrafts[0].gameObject, spacecrafts[1].gameObject });
        tickTimer.StartTimer();
    }

    private void StopSimulation()
    {
        Debug.Log("Stopping Simulation");
        foreach (Spacecraft spacecraft in spacecrafts)
        {
            spacecraft.StopPhysics();
        }
        camera.FreeNavigation();
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
            MoveCards cards = spacecraft.player.card_Selection;
            for (int i = 0; i < cards.card_List.Count; i++)
            {
                SpacecraftAction action = CardParser.ParseCard(cards.get_MoveCard(i));
                spacecraft.AddAction(action);
            }
            spacecraft.player.card_Selection.card_List.Clear();
            this.hud.card_stack.hide();
        }
    }

    void setActivePlayer(Player player)
    {
        acti_player = player;
    }

    private void resetCards(Player currentPlayer){
        currentPlayer.card_Stack.card_List.Clear();
        currentPlayer.card_Stack.card_List.Add(MoveCardCreator.getForward());
        currentPlayer.card_Stack.card_List.Add(MoveCardCreator.getBackward());
        currentPlayer.card_Stack.card_List.Add(MoveCardCreator.getRotationLeft30());
        currentPlayer.card_Stack.card_List.Add(MoveCardCreator.getRotationRight30());
        currentPlayer.card_Stack.card_List.Add(MoveCardCreator.getRotationLeft60());
        currentPlayer.card_Stack.card_List.Add(MoveCardCreator.getRotationRight60());
        currentPlayer.card_Stack.card_List.Add(MoveCardCreator.getRotationLeft90());
        currentPlayer.card_Stack.card_List.Add(MoveCardCreator.getRotationRight90());
        if (currentPlayer.getWeapon(1) != "")
            currentPlayer.card_Stack.card_List.Add(MoveCardCreator.getWeapon(currentPlayer.getWeapon(1)));
        else
            currentPlayer.card_Stack.card_List.Add(MoveCardCreator.getForwardFast());
        if (currentPlayer.getWeapon(2) != "")
            currentPlayer.card_Stack.card_List.Add(MoveCardCreator.getWeapon(currentPlayer.getWeapon(2)));
        else
            currentPlayer.card_Stack.card_List.Add(MoveCardCreator.getBackwardFast());
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

}