using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteRotation : SimulatedObject
{

    public float fullRotationTime;
    private bool active;
    void Start()
    {
        active = true;
    }

    void Update()
    {
        if (active)
        {
            transform.RotateAround(transform.position, transform.up, 360 * Time.deltaTime / fullRotationTime);
        }
    }

    public override void Play()
    {
        active = true;
    }

    public override void Pause()
    {
        active = false;
    }
}
