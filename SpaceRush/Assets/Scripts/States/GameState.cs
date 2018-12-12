using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState : MonoBehaviour
{
    protected GameManager gm;

    public GameState(GameManager gm)
    {
        this.gm = gm;
    }
    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }
}
