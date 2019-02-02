using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacecraftRotation : SpacecraftAction
{
    public float angularSpeed;
    public float duration;
    public Direction direction;

    public SpacecraftRotation(Direction direction, float fuelCost, float angularSpeed, float duration)
    {
        this.duration = duration;
        this.fuelCost = fuelCost;
        this.direction = direction;
        this.angularSpeed = angularSpeed;
    }
}
