using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGravityMine : Weapon
{
    public float gravitationalForce;

    void Start()
    {
        SetState(new GravityInitializationState(this));
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.transform.gameObject.name.Contains("Spacecraft"))
        {
            Vector3 direction = Vector3.Normalize(this.transform.position - other.transform.position);
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(direction.x, direction.y) * -gravitationalForce);
            SetState(new GravityExplosionState(this));
        }
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
