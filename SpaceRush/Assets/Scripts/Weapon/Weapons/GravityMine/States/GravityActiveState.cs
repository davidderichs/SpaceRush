using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityActiveState : WeaponState
{

    public GravityActiveState(Weapon weapon) : base(weapon)
    { }

    public override void Tick()
    {

    }

    public override void OnStateEnter()
    {
        weapon.GetComponent<CircleCollider2D>().enabled = true;
    }

    public override void OnStateExit()
    {

    }
}
