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
    private SpacecraftMovement.Direction boostDirection;
    private SpacecraftMovement.Direction rotationDirection;

    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        boostTimer = 0;
        boostDirection = SpacecraftMovement.Direction.None;
        rotationDirection = SpacecraftMovement.Direction.None;
        rotationTimer = 0;
    }

    void Update()
    {
        if (rotationDirection != SpacecraftMovement.Direction.None)
        {
            rotationTimer -= Time.deltaTime;
            float fac = Time.deltaTime;
            if (rotationTimer < 0)
            {
                fac += rotationTimer;
                rotationTimer = 0;
                rotationDirection = SpacecraftMovement.Direction.None;
            }
            if (rotationDirection == SpacecraftMovement.Direction.Left)
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

        if (boostDirection != SpacecraftMovement.Direction.None)
        {
            boostTimer -= Time.deltaTime;
            float fac = Time.deltaTime;
            if (boostTimer < 0)
            {
                fac += boostTimer;
                boostTimer = 0;
                boostDirection = SpacecraftMovement.Direction.None;
            }
            if (boostDirection == SpacecraftMovement.Direction.Forwards)
            {
                rb.AddRelativeForce(new Vector2(boostForce * fac, 0));
            }
            else if (boostDirection == SpacecraftMovement.Direction.Backwards)
            {
                rb.AddRelativeForce(new Vector2(-boostForce * fac, 0));
            }
        }
    }

    public void Boost(SpacecraftMovement.Direction direction, float force, float duration)
    {
        if (direction == SpacecraftMovement.Direction.Forwards || direction == SpacecraftMovement.Direction.Backwards)
        {
            boostDirection = direction;
            boostForce = force;
            boostTimer = duration;
        }
    }

    public void Rotate(SpacecraftMovement.Direction direction, float speed, float duration)
    {
        if (direction == SpacecraftMovement.Direction.Left || direction == SpacecraftMovement.Direction.Right)
        {
            rotationDirection = direction;
            angularSpeed = speed;
            rotationTimer = duration;
        }
    }
}
