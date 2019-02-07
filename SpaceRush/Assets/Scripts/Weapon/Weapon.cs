using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected Player owner;
    protected WeaponState currentState;

    public virtual void Fire() { }
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
        if (currentState != null)
        {
            currentState.Tick();
        }
    }

    protected void Destruct()
    {
        Destroy(gameObject);
    }
}
