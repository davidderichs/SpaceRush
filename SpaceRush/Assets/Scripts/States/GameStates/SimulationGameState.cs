using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationGameState : GameState
{

    public SimulationGameState(GameManager gm) : base(gm) { }

    public override void OnStateEnter()
    {
        /*move camera, enabled all rigid bodies (spacecrafts, space debris), start the execution of the cards 
        foreach (ISimulatedObject sc in gm.GetSpacecrafts())
        {
            sc.StopPhysics();
        }
        foreach (ISimulatedObject sc in gm.GetSpaceDebris())
        {
            sc.StopPhysics();
		}*/
    }

    public override void OnStateExit()
    {
        /*disable all rigid bodies, stop the execution of the cards 
        foreach (ISimulatedObject sc in gm.GetSpacecrafts())
        {
            sc.StartPhysics();
        }
        foreach (ISimulatedObject sc in gm.GetSpaceDebris())
        {
            sc.StartPhysics();
        }
		*/
    }
}
