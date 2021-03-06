﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileExplosionState : WeaponState
{
    private float timer;
    private float explosionTime;
    private float removalTime;
    private ParticleSystem explosion;
    private bool remove;
    private Rigidbody2D rb;

    public MissileExplosionState(Weapon weapon) : base(weapon)
    { }

    public override void Tick()
    {
        timer += Time.deltaTime;
        if (remove && timer >= removalTime)
        {
            weapon.SetState(null);
        }
        if (!remove && timer >= explosionTime)
        {
            explosion.Stop();
            remove = true;
            timer = 0;
        }
    }

    public override void OnStateEnter()
    {
        timer = 0f;
        explosionTime = 1f;
        removalTime = 0.3f;
        remove = false;
        weapon.GetComponent<CircleCollider2D>().enabled = false;
        explosion = (ParticleSystem)weapon.transform.Find("explosion").GetComponent<ParticleSystem>();
        explosion.gameObject.SetActive(true);
        explosion.Play();
        GameObject missile = weapon.transform.Find("missile").gameObject;
        UnityEngine.Object.Destroy(missile);
        GameObject thruster = weapon.transform.Find("thruster").gameObject;
        UnityEngine.Object.Destroy(thruster);
        EventManager.TriggerEvent("missile_explosion");
        rb = weapon.GetComponent<Rigidbody2D>();
    }

    public override void OnStateExit()
    {
        GameManager.GetInstance().RemoveSimulatedObject(weapon);
    }

    public override void Stop()
    {
        rb.simulated = false;
        explosion.Pause();
    }

    public override void Resume()
    {
        rb.simulated = true;
        explosion.Play();
    }
}
