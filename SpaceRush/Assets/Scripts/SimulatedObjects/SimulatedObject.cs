using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SimulatedObject : MonoBehaviour
{
    void Awake()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().AddSimulatedObject(this);
    }
    public abstract void Play();
    public abstract void Pause();
}
