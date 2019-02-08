using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacecraftController : MonoBehaviour
{

    private float boostForce;
    private float angularSpeed;
    private Rigidbody2D rb;
    private float boostTimer;
    private float rotationTimer;
    private SpacecraftAction.Direction boostDirection;
    private SpacecraftAction.Direction rotationDirection;
    private ThrustersController thrustersController;

    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        boostTimer = 0;
        boostDirection = SpacecraftAction.Direction.None;
        rotationDirection = SpacecraftAction.Direction.None;
        rotationTimer = 0;
    }

    void Start()
    {
        thrustersController = GetComponent<ThrustersController>();
    }

    void Update()
    {
        if (rotationDirection != SpacecraftAction.Direction.None)
        {
            rotationTimer -= Time.deltaTime;
            float fac = Time.deltaTime;
            if (rotationTimer < 0)
            {
                fac += rotationTimer;
                rotationTimer = 0;
                rotationDirection = SpacecraftAction.Direction.None;
            }
            if (rotationDirection == SpacecraftAction.Direction.Left)
            {
                transform.Rotate(new Vector3(0, 0, angularSpeed * fac));
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, -angularSpeed * fac));
            }

            float dot = Vector2.Dot(transform.right.normalized, rb.velocity.normalized);
            if (dot >= 0)
            {
                rb.velocity = transform.right * rb.velocity.magnitude;
            }
            else
            {
                rb.velocity = transform.right * -rb.velocity.magnitude;
            }
        }

        if (boostDirection != SpacecraftAction.Direction.None)
        {
            boostTimer -= Time.deltaTime;
            float fac = Time.deltaTime;
            if (boostTimer < 0)
            {
                fac += boostTimer;
                boostTimer = 0;
                boostDirection = SpacecraftAction.Direction.None;
                EventManager.TriggerEvent("spacecraft_boost_stop");
                thrustersController.StopBoost();
            }
            if (boostDirection == SpacecraftAction.Direction.Forwards)
            {
                rb.AddRelativeForce(new Vector2(boostForce * fac, 0));
            }
            else if (boostDirection == SpacecraftAction.Direction.Backwards)
            {
                rb.AddRelativeForce(new Vector2(-boostForce * fac, 0));
            }
        }
    }

    public void Boost(SpacecraftAction.Direction direction, float force, float duration)
    {
        if (direction == SpacecraftAction.Direction.Forwards || direction == SpacecraftAction.Direction.Backwards)
        {
            thrustersController.Boost(direction);
            boostDirection = direction;
            boostForce = force;
            boostTimer = duration;

            EventManager.TriggerEvent("spacecraft_boost_start");
        }
        FireGravityMine();
    }

    public void Rotate(SpacecraftAction.Direction direction, float speed, float duration)
    {
        if (direction == SpacecraftAction.Direction.Left || direction == SpacecraftAction.Direction.Right)
        {
            rotationDirection = direction;
            angularSpeed = speed;
            rotationTimer = duration;
        }
    }

    public void FireGravityMine()
    {
        Instantiate(Resources.Load("Prefabs/weapons/weaponGravityMine"), transform.position, new Quaternion());
    }

    public void FireMissile()
    {

    }

    public void FireLaser()
    {

    }
}
