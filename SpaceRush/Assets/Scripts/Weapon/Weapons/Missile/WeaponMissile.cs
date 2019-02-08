using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMissile : Weapon
{

    void Start()
    {
        SetState(new MissileMovingState(this));
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.gameObject.name.Contains("Spacecraft"))
        {
            // kill
        }
        SetState(new MissileExplosionState(this));
    }

    public void Initialize(Quaternion parentRotation, Vector2 parentVelocity)
    {
        transform.rotation = parentRotation;
        GetComponent<Rigidbody2D>().velocity = parentVelocity;
    }
}
