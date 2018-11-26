using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceCraftControl : MonoBehaviour
{
     public enum Booster { FORWARD, BACKWARD, LEFT, RIGHT };
   
    private Rigidbody2D rb;
    public float boostForwardForce = 10;
    public float boostBackwardForce = 10;
    public float boostSideForce = 8;
    // angular speed in radians
    public float angularSpeed = Mathf.PI / 4;
    public bool stabilzeTravelDirection = true;
    private ArrayList boostActions;

    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        boostActions = new ArrayList();
    }

    void Start()
    {

    }

    void Update()
    {
        for (int i = boostActions.Count - 1; i >= 0; i--)
        {
            BoostTimer bt = (BoostTimer)boostActions[i];
            switch (bt.booster)
            {
                case Booster.FORWARD:
                    rb.AddRelativeForce(new Vector2(boostForwardForce, 0));
                    break;
                case Booster.BACKWARD:
                    rb.AddRelativeForce(new Vector2(-boostBackwardForce, 0));
                    break;
                case Booster.LEFT:
                    rb.AddRelativeForce(new Vector2(0, boostSideForce));
                    break;
                case Booster.RIGHT:
                    rb.AddRelativeForce(new Vector2(0, -boostSideForce));
                    break;
                default: break;
            }
            bt.Update(Time.deltaTime);
        }

        if (stabilzeTravelDirection)
        {
            Vector3 vectorToTarget = (transform.position + new Vector3(rb.velocity.normalized.x, rb.velocity.normalized.y, 0)) - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * angularSpeed);
        }
    }

    public void AddBoost(Booster booster, float boostTime)
    {
        foreach (BoostTimer bt in boostActions)
        {
            if (bt.booster == booster)
            {
                return;
            }
        }
        boostActions.Add(new BoostTimer(booster, boostTime, boostActions));
    }
}

public class BoostTimer
{
    public SpaceCraftControl.Booster booster;
    public float time;
    private ArrayList parent;

    public BoostTimer(SpaceCraftControl.Booster booster, float time, ArrayList parent)
    {
        this.booster = booster;
        this.time = time;
        this.parent = parent;
    }

    public void Update(float deltaTime)
    {
        time -= deltaTime;
        if (time <= 0)
        {
            parent.Remove(this);
            return;
        }
    }
}

