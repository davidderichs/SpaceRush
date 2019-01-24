using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGravityMine : Weapon
{
    private CircleCollider2D collider2D;
    private Light light;
    public float force;
    public float torqueForce;
    public float activationTime;
    private float counter;

    public void Start()
    {
        collider2D = GetComponent<CircleCollider2D>();
        light = GetComponent<Light>();
        counter = 0;
    }

    public void Update()
    {
        if (!active)
        {
            counter += Time.deltaTime;
            if (counter >= activationTime)
            {
                Activate();
            }
        }
    }

    public override void Fire()
    {
        this.transform.position = this.owner.transform.position;
    }

    private void Activate()
    {
        light.range = 150;
        light.color = Color.green;
        active = true;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (active)
        {
            if (other.transform.gameObject.name.Contains("Spacecraft"))
            {
                Debug.Log("triggerd");
                Vector3 direction = Vector3.Normalize(this.transform.position - other.transform.position);
                Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
                rb.AddForce(new Vector2(direction.x, direction.y) * -force);
                rb.AddTorque(torqueForce);
                light.range = 500;
                light.color = Color.red;
            }
        }
    }
}
