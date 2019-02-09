using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spacecraft : SimulatedObject
{
    public Player player;
    private SpacecraftController controller;
    private List<SpacecraftAction> actions;
    private Rigidbody2D rb;
    private Attractor attractor;
    private Vector2 m_velocity;
    private float m_angularVelocity;
    private bool sleeping;


    private List<ISpacecraftCollisionListener> listeners;

    public void AddCollisionListener(ISpacecraftCollisionListener listener)
    {
        if (listeners == null)
        {
            listeners = new List<ISpacecraftCollisionListener>();
        }
        listeners.Add(listener);
    }

    public void RemoveCollisionListener(ISpacecraftCollisionListener listener)
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
                SpacecraftBoost boost = (SpacecraftBoost)action;
                if (boost.direction == SpacecraftAction.Direction.None) return;
                controller.Boost(boost.direction, boost.boostForce, boost.duration);
                actions.RemoveAt(0);
            }
            else if (action is SpacecraftRotation)
            {
                SpacecraftRotation rotation = (SpacecraftRotation)action;
                if (rotation.direction == SpacecraftAction.Direction.None) return;
                controller.Rotate(rotation.direction, rotation.angularSpeed, rotation.duration);
                actions.RemoveAt(0);
            }
            if (action is SpacecraftWeaponAction)
            {
                Transform weapon = null;
                SpacecraftWeaponAction weaponAction = (SpacecraftWeaponAction)action;
                switch (weaponAction.type)
                {
                    case SpacecraftWeaponAction.WeaponType.GravityMine:
                        controller.FireGravityMine();
                        break;
                    case SpacecraftWeaponAction.WeaponType.Laser:
                        controller.FireLaser();
                        break;
                    case SpacecraftWeaponAction.WeaponType.Rocket:
                        controller.FireMissile();
                        break;
                    default:
                        weapon = null;
                        break;

                }
                if (weapon != null)
                {
                    actions.RemoveAt(0);
                }
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (listeners != null)
        {
            foreach (ISpacecraftCollisionListener listener in listeners)
            {
                listener.OnSpacecraftCollision(this, col.collider.gameObject);
            }
        }
    }


    public override void Play()
    {
        controller.enabled = true;
        attractor.enabled = true;
        rb.velocity = m_velocity;
        rb.angularVelocity = m_angularVelocity;
        sleeping = false;
    }

    public override void Pause()
    {
        controller.enabled = false;
        attractor.enabled = false;
        m_velocity = rb.velocity;
        m_angularVelocity = rb.angularVelocity;
        sleeping = true;
    }

}
