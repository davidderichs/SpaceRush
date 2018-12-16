using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class CameraState
{
    protected CameraController camera;

    public CameraState(CameraController camera)
    {
        this.camera = camera;
    }
    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }
    public abstract void Tick();
}
