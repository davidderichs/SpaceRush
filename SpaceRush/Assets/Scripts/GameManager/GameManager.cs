using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour, ISpacecraftCollisionListener, ITickable{
    public Player player_1;
    //public Player pl2;
    public Checkpoint checkpoint1;
    public Checkpoint checkpoint2;
    public Checkpoint checkpoint3;
    public Checkpoint checkpoint4;

    private TickTimer tickTimer;
    private List<Spacecraft> spacecrafts;
    private UnityAction player_live_listener;
    private UnityAction player_main_fuel_listener;
    private UnityAction player_add_fuel_listener;
    private UnityAction player_shield_listener;
    private UnityAction player_card_stack_listener;
    private UnityAction player_card_selection_listener;
	private UnityAction player_ready_listener;

    private UnityAction player_selection_complete_listener;
    private UnityAction player_selection_incomplete_listener;

    public Startpoint start;
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

		player_ready_listener = new UnityAction (propagate_Player_ready);
		EventManager.StartListening("HUD_Player_is_ready", player_ready_listener);

        Spacecraft.AddCollisionListener(this);

        tickTimer = gameObject.AddComponent<TickTimer>();
        tickTimer.SetProperties(this, 2, 5);

        spacecrafts = new List<Spacecraft>();
        spacecrafts.Add(GameObject.Find("Spacecraft").GetComponent<Spacecraft>());
        //spacecrafts.Add(GameObject.Find("Spacecraft2").GetComponent<Spacecraft>());

    }

    void Start() {

        this.hud = GameObject.FindWithTag("HUD").GetComponent<HUD>();
        this.player_1 = GameObject.Find("Player").GetComponent<Player>();

		player_1.space.transform.position = start.position;
        StopSimulation();
	}

    void propagate_Player_Selection_complete() {
        this.hud.activate_Ready_Button();
    }
    void propagate_Player_Selection_incomplete() {
        this.hud.deactivate_Ready_Button();
    }

	void propagate_Player_ready(){
        Gameloop();
        StartSimulation();
        propagate_Player_Selection_incomplete();
	}

	public void checkpointTriggered(int id, Player player){
		player_1.addCheckpoint(id);
	}
	void Update(){
		if (player_1.check.Count == 4){
			Debug.Log("Player 1 Win");
		}

		// ONLY TESTING when simulation stopped -> reenable physics with klick on space
        if (Input.GetKeyDown("space"))
        {
            StartSimulation();
        }
	}
    void propagate_Player_live_change()
    {
        this.hud.live.set_ActiveItemsColor(this.player_1.lives);
    }
    void propagate_Player_main_fuel_change()
    {
        this.hud.main_fuel.set_ActiveItemsColor(this.player_1.main_fuel);
    }
    void propagate_Player_add_fuel_change()
    {
        this.hud.add_fuel.set_ActiveItemsColor(this.player_1.add_fuel);
    }
    void propagate_Player_shield_change()
    {
        this.hud.shield.set_ActiveItemsColor(this.player_1.shields);
    }
    void propagate_Player_stack_change()
    {
        this.hud.card_stack.set_MoveCards(this.player_1.card_Stack);
        this.hud.selected_cards.set_MoveCards(this.player_1.card_Selection);
    }
    void propagate_Player_Selection_change()
    {
        this.hud.card_stack.set_MoveCards(this.player_1.card_Stack);
        this.hud.selected_cards.set_MoveCards(this.player_1.card_Selection);
    }

    public void resetPlayer(Player player)
    {
        int number = player.check.Count;
        int lastDig = player.check[number - 1];
        Debug.Log(lastDig);
        if (lastDig == 1)
        {
            player.space.transform.position = checkpoint1.transform.position;
        }
        if (lastDig == 2)
        {
            player.space.transform.position = checkpoint2.transform.position;
        }
        if (lastDig == 3)
        {
            player.space.transform.position = checkpoint3.transform.position;
        }
        if (lastDig == 4)
        {
            player.space.transform.position = checkpoint4.transform.position;
        }
    }

    public void OnSpacecraftCollision(Spacecraft spacecraft, GameObject collider)
    {
        Debug.Log(spacecraft.name + " collided with " + collider.name);
        switch (collider.tag)
        {
            case "planet":
                EventManager.TriggerEvent("spacecraft_planet_collision");
                break;
            case "moon":
                EventManager.TriggerEvent("spacecraft_planet_collision");
                break;
            case "spacecraft":
                EventManager.TriggerEvent("spacecraft_spacecraft_collision");
                break;
        }
    }

    public void Tick(bool done)
    {
        if (done)
        {
            Debug.Log("DONE.");
            StopSimulation();
            propagate_Player_stack_change();
        }
        else
        {
            Debug.Log("Tick");
            foreach (Spacecraft spacecraft in spacecrafts)
            {
                spacecraft.StartNextMovement();
            }
        }
    }

    private void StartSimulation() {
        Debug.Log("Starting Simulation");
        tickTimer.StartTimer();
        foreach (Spacecraft spacecraft in spacecrafts)
        {
            spacecraft.StartPhysics();
        }
    }

	    private void StopSimulation()
    {
        Debug.Log("Stopping Simulation");
        foreach (Spacecraft spacecraft in spacecrafts)
        {
            spacecraft.StopPhysics();
        }
    }

        private void Gameloop(){
           foreach (Spacecraft spacecraft in spacecrafts)
            {
                MoveCards cards = spacecraft.player.card_Selection;
                for (int i=0; i < cards.card_List.Count; i++)
                {
                    SpacecraftMovement move = CardParser.ParseCard(cards.get_MoveCard(i));
                    spacecraft.AddMovement(move);
                    Debug.Log(move.duration);
                }
                spacecraft.player.card_Selection.card_List.Clear();
                MoveCards newCards = MoveCards.get_random_Movecards(5);
                for (int i = 0; i < newCards.size(); i++)
                spacecraft.player.card_Stack.card_List.Add(newCards.get_MoveCard(i));
                this.hud.card_stack.hide();
            }
        }
}