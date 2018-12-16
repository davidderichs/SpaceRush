using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpacecraftMovement : MonoBehaviour
{
    public enum Direction { Forwards, Backwards, Left, Right, None }
    public Direction direction;
    public float duration;

    public SpacecraftMovement(Direction direction, float duration)
    {
        this.direction = direction;
        this.duration = duration;
    }
}
