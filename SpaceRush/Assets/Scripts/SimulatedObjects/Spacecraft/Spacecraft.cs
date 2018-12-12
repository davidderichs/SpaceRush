using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spacecraft : MonoBehaviour, ISimulatedObject
{
    public Player player;
    private SpacecraftController controller;
    private ArrayList movements;
    private Rigidbody2D rb;
    private Vector2 velocity_b;
    private float angularVelocity_b;



    void Awake()
    {
        controller = GetComponent<SpacecraftController>();
        movements = new ArrayList();
    }

    public void AddMovement(SpacecraftMovement movement)
    {
        movements.Add(movement);
    }

    public void StartNextMovement()
    {
        if (movements.Count > 0)
        {
            object movement = movements[0];
            if (movement is SpacecraftBoost)
            {
                SpacecraftBoost boost = (SpacecraftBoost)movement;
                controller.Boost(boost.direction, boost.boostForce, boost.duration);
                movements.RemoveAt(0);
            }
            else if (movement is SpacecraftRotation)
            {
                SpacecraftRotation rotation = (SpacecraftRotation)movement;
                controller.Rotate(rotation.direction, rotation.angularSpeed, rotation.duration);
                movements.RemoveAt(0);
            }
        }
    }


    public void StartPhysics()
    {
        controller.enabled = true;
        rb.WakeUp();
        rb.velocity = velocity_b;
        rb.angularVelocity = angularVelocity_b;
    }

    public void StopPhysics()
    {
        controller.enabled = false;
        velocity_b = rb.velocity;
        angularVelocity_b = rb.angularVelocity;
        rb.Sleep();
    }
}
