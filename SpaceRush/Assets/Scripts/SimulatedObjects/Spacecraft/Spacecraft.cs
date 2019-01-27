using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spacecraft : MonoBehaviour, ISimulatedObject
{
    public Player player;
    private SpacecraftController controller;
    private List<SpacecraftAction> actions;
    private Rigidbody2D rb;
    private Attractor attractor;
    private Vector2 m_velocity;
    private float m_angularVelocity;
    private bool sleeping;

    // Zu Testzwecken von Instantiate
    public Transform weapon;

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
        actions = new List<SpacecraftAction>();
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

    public void AddAction(SpacecraftAction action)
    {
        actions.Add(action);
    }

    public void StartNextAction()
    {
        if (actions.Count > 0)
        {
            SpacecraftAction action = actions[0];
            if (action is SpacecraftBoost)
            {
                if (player.main_fuel > 0)
                {                                              //For Fuel usage
                    SpacecraftBoost boost = (SpacecraftBoost)action;
                    if (boost.direction == SpacecraftAction.Direction.None) return;
                    controller.Boost(boost.direction, boost.boostForce, boost.duration);
                    player.looseFuel(action.intensity);
                    actions.RemoveAt(0);
                }
            }
            else if (action is SpacecraftRotation)
            {
                if (player.main_fuel > 0)
                {
                    SpacecraftRotation rotation = (SpacecraftRotation)action;
                    if (rotation.direction == SpacecraftAction.Direction.None) return;
                    controller.Rotate(rotation.direction, rotation.angularSpeed, rotation.duration);
                    player.looseFuel(action.intensity);
                    actions.RemoveAt(0);
                }
            }
            if (action is SpacecraftWeaponAction)
            {
                if (player.main_fuel > 0)
                {
                    SpacecraftWeaponAction weaponAction = (SpacecraftWeaponAction)action;
                    Instantiate(weapon, this.transform.position, Quaternion.identity);
                    player.looseFuel(action.intensity);
                    actions.RemoveAt(0);
                }
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
