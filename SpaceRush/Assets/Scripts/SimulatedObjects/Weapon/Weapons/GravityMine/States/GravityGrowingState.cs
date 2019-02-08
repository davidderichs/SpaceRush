using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGrowingScript : WeaponState
{
    private float timer;
    private GameObject forceField;
    private float growStep;
    private float finalSize;

    public GravityGrowingScript(Weapon weapon) : base(weapon)
    {
        growStep = 0.1f;
        finalSize = 2;
    }

    public override void Tick()
    {
        timer += Time.deltaTime;
        Vector3 size = forceField.transform.localScale;
        size.x += growStep;
        size.y += growStep;
        size.z += growStep;
        if (size.x >= finalSize)
        {
            size = new Vector3(finalSize, finalSize, finalSize);
            forceField.transform.localScale = size;
            weapon.SetState(new GravityActiveState(weapon));
        }
        forceField.transform.localScale = size;
    }

    public override void OnStateEnter()
    {
        forceField = weapon.transform.Find("forceField").gameObject;
        forceField.SetActive(true);
        timer = 0;
    }

    public override void OnStateExit()
    {

    }

    public override void Stop()
    {

    }

    public override void Resume()
    {

    }
}
