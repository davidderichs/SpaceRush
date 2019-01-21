using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected Player owner;
    protected bool active;

    public void OnEnable()
    {
        active = false;
    }

    public virtual void Fire() { }
    public void SetOwner(Player owner)
    {
        this.owner = owner;
    }
}
