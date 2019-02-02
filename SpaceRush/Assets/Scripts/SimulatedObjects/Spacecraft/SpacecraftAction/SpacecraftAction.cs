using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpacecraftAction : MonoBehaviour
{
    public enum Direction { Left, Right, Forwards, Backwards, None }
    public float fuelCost;
}
