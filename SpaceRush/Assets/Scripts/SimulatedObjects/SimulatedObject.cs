using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SimulatedObject : MonoBehaviour
{
    void Awake()
    {
        GameManager.GetInstance().AddSimulatedObject(this);
    }
    public abstract void Play();
    public abstract void Pause();
}
