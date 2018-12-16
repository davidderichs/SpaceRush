using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spacecraft : MonoBehaviour, ISimulatedObject
{
    public Player player;
    private SpacecraftController controller;
    private List<SpacecraftMovement> movements;
    private Rigidbody2D rb;
    private Attractor attractor;
    private Vector2 m_velocity;
    private float m_angularVelocity;
    private bool sleeping;

    private static List<ISpacecraftCollisionListener> listeners;

    public static void AddCollisionListener(ISpacecraftCollisionListener listener)
    {
        if (listeners == null)
        {
            listeners = new List<ISpacecraftCollisionListener>();
        }
        listeners.Add(listener);
    }

    public static void RemoveCollisionListener(ISpacecraftCollisionListener listener)
    {
        if (listener != null)
        {
            listeners.Remove(listener);
        }
    }

    void Awake()
    {
        controller = GetComponent<SpacecraftController>();
        movements = new List<SpacecraftMovement>();
        rb = GetComponent<Rigidbody2D>();
        attractor = GetComponent<Attractor>();
    }

    void Update()
    {
        if (sleeping)
        {
            rb.Sleep();
        }
    }

    public void AddMovement(SpacecraftMovement movement)
    {
        movements.Add(movement);
    }

    public void StartNextMovement()
    {
        if (movements.Count > 0)
        {
            SpacecraftMovement movement = movements[0];
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

    void OnCollisionEnter2D(Collision2D col)
    {
        if (listeners != null)
        {
            foreach (ISpacecraftCollisionListener listener in listeners)
            {
                listener.OnSpacecraftCollision(this, col.collider.gameObject);
            }
        }
    }


    public void StartPhysics()
    {
        controller.enabled = true;
        attractor.enabled = true;
        rb.velocity = m_velocity;
        rb.angularVelocity = m_angularVelocity;
        sleeping = false;
    }

    public void StopPhysics()
    {
        controller.enabled = false;
        attractor.enabled = false;
        m_velocity = rb.velocity;
        m_angularVelocity = rb.angularVelocity;
        sleeping = true;
    }
}
