using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector2Extensions : MonoBehaviour
{
    public static Vector2 Rotate(Vector2 vec, float angle)
    {
        float newX = (vec.x * Mathf.Cos(angle)) - (vec.y * Mathf.Sin(angle));
        float newY = (vec.x * Mathf.Sin(angle)) + (vec.y * Mathf.Cos(angle));
        return new Vector2(newX, newY);
    }
}
