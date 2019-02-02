using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacecraftBoost : SpacecraftAction
{
    public float boostForce;
    public float duration;
    public Direction direction;

    public SpacecraftBoost(Direction direction, float fuelCost, float force, float duration)
    {
        this.duration = duration;
        this.fuelCost = fuelCost;
        this.direction = direction;
        boostForce = force;

    }
}
