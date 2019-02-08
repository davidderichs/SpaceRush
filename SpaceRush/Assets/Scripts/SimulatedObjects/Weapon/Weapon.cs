using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : SimulatedObject
{
    protected Player owner;
    protected WeaponState currentState;
    protected bool paused;

    public void Awake()
    {
        paused = false;
    }

    public void SetOwner(Player owner)
    {
        this.owner = owner;
    }

    public void SetState(WeaponState state)
    {
        if (currentState != null)
        {
            currentState.OnStateExit();
        }
        currentState = state;
        if (currentState != null)
        {
            currentState.OnStateEnter();
        }
    }

    protected void Update()
    {
        if (currentState != null && !paused)
        {
            currentState.Tick();
        }
    }

    public override void Play()
    {
        paused = false;
        if (currentState != null)
        {
            currentState.Resume();
        }
    }

    public override void Pause()
    {
        paused = true;
        if (currentState != null)
        {
            currentState.Stop();
        }
    }
}
