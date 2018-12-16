using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraFixedState : CameraState
{
    private Vector3 position;
    public CameraFixedState(CameraController camera, Vector3 position) : base(camera)
    {
        this.position = position;
    }

    public override void OnStateEnter()
    {
        camera.AnimateTo(position);
    }

    public override void OnStateExit() { }

    public override void Tick() { }
}
