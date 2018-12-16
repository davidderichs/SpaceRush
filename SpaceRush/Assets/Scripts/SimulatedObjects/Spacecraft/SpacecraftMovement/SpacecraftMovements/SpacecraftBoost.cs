using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacecraftBoost : SpacecraftMovement
{
    public float boostForce;

    public SpacecraftBoost(Direction direction, float boostForce, float duration) : base(direction, duration)
    {
        this.boostForce = boostForce;
    }
}
