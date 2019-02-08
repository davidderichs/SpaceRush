using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityInitializationState : WeaponState
{
    private float timer;
    private GameObject startModule;
    private float duration;

    public GravityInitializationState(Weapon weapon) : base(weapon)
    { }
    public override void Tick()
    {
        timer += Time.deltaTime;
        if (timer >= duration)
        {
            weapon.SetState(new GravityGrowingScript(weapon));
        }
    }

    public override void OnStateEnter()
    {
        timer = 0f;
        duration = 10f;
        startModule = weapon.transform.Find("startModule").gameObject;
    }

    public override void OnStateExit()
    {
        UnityEngine.Object.Destroy(startModule);
    }

    public override void Stop()
    {

    }

    public override void Resume()
    {

    }
}
