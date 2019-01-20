using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowObjectState : CameraState
{
    private GameObject followObject;

    public CameraFollowObjectState(CameraController camera, GameObject followObject) : base(camera)
    {
        this.followObject = followObject;
    }

    public override void OnStateEnter()
    {
        camera.AnimateTo(followObject.transform.position + camera.offset);
    }

    public override void OnStateExit()
    {

    }

    public override void Tick()
    {
        camera.AnimateTo(followObject.transform.position + camera.offset);
    }
}
