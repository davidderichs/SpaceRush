using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SimulatedObject : MonoBehaviour
{
    public void Start()
    {
        GameManager.GetInstance().AddSimulatedObject(this);
        Debug.Log("Added SimulatedObject instance to GameManger");
    }
    public abstract void Play();
    public abstract void Pause();
}
