using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacecraftRotation : SpacecraftMovement
{
    public float angularSpeed;

    public SpacecraftRotation(Direction direction, float angularSpeed, float duration) : base(direction, duration)
    {
        this.angularSpeed = angularSpeed;
    }
}
