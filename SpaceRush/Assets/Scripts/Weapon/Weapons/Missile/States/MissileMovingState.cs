using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovingState : WeaponState
{
    private Rigidbody2D rb;
    private float acceleration;

    public MissileMovingState(Weapon weapon) : base(weapon)
    { }

    public override void Tick()
    {
        rb.AddRelativeForce(new Vector2(acceleration, 0));
    }

    public override void OnStateEnter()
    {
        rb = weapon.GetComponent<Rigidbody2D>();
        acceleration = 10;
    }

    public override void OnStateExit()
    {

    }
}
