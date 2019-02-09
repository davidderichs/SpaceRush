using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovingState : WeaponState
{
    private Rigidbody2D rb;
    private ParticleSystem ps;
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
        ps = weapon.transform.Find("thruster").GetComponent<ParticleSystem>();
        acceleration = 10;
    }

    public override void OnStateExit()
    { }

    public override void Stop()
    {
        rb.simulated = false;
        ps.Pause();
    }

    public override void Resume()
    {
        rb.simulated = true;
        ps.Play();
    }
}
