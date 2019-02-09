using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMissile : Weapon
{

    private bool fired;

    void Start()
    {
        base.Start();
        SetState(new MissileMovingState(this));
        fired = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if ((fired && other.tag.Equals("planet")) || other.tag.Equals("boundary"))
        {
            SetState(new MissileExplosionState(this));
        }
        if (fired && other.tag.Equals("spacecraft"))
        {
            SetState(new MissileExplosionState(this));
            Player player = other.gameObject.GetComponent<Spacecraft>().player;
            GameManager.GetInstance().resetPlayer(player);
            player.looseLive(5);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        fired = true;
    }

    public void Initialize(Quaternion parentRotation, Vector2 parentVelocity)
    {
        transform.rotation = parentRotation;
        GetComponent<Rigidbody2D>().velocity = parentVelocity;
    }

    public override void Play()
    {
        base.Play();
    }

    public override void Pause()
    {
        base.Pause();
    }
}
