using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMissile : Weapon
{

    private bool leftSpacecraft;

    void Start()
    {
        SetState(new MissileMovingState(this));
        leftSpacecraft = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (leftSpacecraft)
        {
            if (other.transform.gameObject.name.Contains("Spacecraft"))
            {
                // kill
            }
            SetState(new MissileExplosionState(this));
        }
    }

    public void OnTriggerExit2d(Collider2D other)
    {
        leftSpacecraft = true;
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
