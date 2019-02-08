using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityExplosionState : WeaponState
{

    private float timer;
    private float growStep;
    private float finalSize;
    private GameObject forceField;
    private Material material;
    public GravityExplosionState(Weapon weapon) : base(weapon)
    {
        growStep = 1f;
        finalSize = 10;
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
            weapon.SetState(null);
        }
        forceField.transform.localScale = size;
        material.SetVector("Vector2_57E9AAA8", material.GetVector("Vector2_57E9AAA8") * 1.5f);
    }

    public override void OnStateEnter()
    {
        forceField = weapon.transform.Find("forceField").gameObject;
        material = forceField.GetComponent<Renderer>().material;
        material.SetColor("Color_E96EC4F", UnityEngine.Color.red);
        timer = 0;
    }

    public override void OnStateExit()
    {
        GameManager.GetInstance().RemoveSimulatedObject(weapon);
    }

    public override void Stop()
    {

    }

    public override void Resume()
    {

    }
}
