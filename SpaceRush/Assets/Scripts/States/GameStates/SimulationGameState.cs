using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationGameState : GameState
{

    public SimulationGameState(GameManager gm) : base(gm) { }

    public override void OnStateEnter()
    {
        /*move camera, enabled all rigid bodies (spacecrafts, space debris), start the execution of the cards */
    }

    public override void OnStateExit()
    {
        /*disable all rigid bodies, stop the execution of the cards */
    }
}
