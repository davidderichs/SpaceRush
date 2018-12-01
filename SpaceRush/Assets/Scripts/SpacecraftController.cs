using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacecraftController : MonoBehaviour
{
    public enum Direction { Forwards, Backwards, Left, Right, None }

    public float boostForwardsForce;
    public float boostBackwardsForce;
    public float angularSpeed;
    private Rigidbody2D rb;
    private float boostTimer;
    private float rotationTimer;
    private Direction boostDirection;
    private Direction rotationDirection;

    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        boostTimer = 0;
        boostDirection = Direction.None;
        rotationDirection = Direction.None;
        rotationTimer = 0;
    }

    void Update()
    {
        if (rotationDirection != Direction.None)
        {
            rotationTimer -= Time.deltaTime;
            float fac = Time.deltaTime;
            if (rotationTimer < 0)
            {
                fac += rotationTimer;
                rotationTimer = 0;
                rotationDirection = Direction.None;
            }
            if (rotationDirection == Direction.Left)
            {
                transform.Rotate(new Vector3(0, 0, angularSpeed * fac));
                rb.velocity = transform.right * rb.velocity.magnitude;
            }
            else if (rotationDirection == Direction.Right)
            {
                transform.Rotate(new Vector3(0, 0, -angularSpeed * fac));
                rb.velocity = transform.right * rb.velocity.magnitude;
            }
        }

        if (boostDirection != Direction.None)
        {
            boostTimer -= Time.deltaTime;
            float fac = Time.deltaTime;
            if (boostTimer < 0)
            {
                fac += boostTimer;
                boostTimer = 0;
                boostDirection = Direction.None;
            }
            if (boostDirection == Direction.Forwards)
            {
                rb.AddRelativeForce(new Vector2(boostForwardsForce * fac, 0));
            }
            else if (boostDirection == Direction.Backwards)
            {
                rb.AddRelativeForce(new Vector2(-boostBackwardsForce * fac, 0));
            }
        }
    }

    public void BoostForwards(float time)
    {
        boostDirection = Direction.Forwards;
        boostTimer = time;
    }

    public void BoostBackwards(float time)
    {
        boostDirection = Direction.Backwards;
        boostTimer = time;
    }

    public void Rotate(float time, Direction direction)
    {
        if (direction == Direction.Left || direction == Direction.Right)
        {
            rotationTimer = time;
            rotationDirection = direction;
        }
    }
}
