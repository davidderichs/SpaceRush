using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDSelectionGameState : GameState
{

    public HUDSelectionGameState(GameManager gm) : base(gm) { }

    public override void OnStateEnter()
    {
        /*move camera, show hud, show card stack, start selecting cards 
        gm.showHUD(); //???*/
    }

    public override void OnStateExit()
    {
        /*hide hud, hide card stack 
		gm.hideHud(); //???*/
    }
}
