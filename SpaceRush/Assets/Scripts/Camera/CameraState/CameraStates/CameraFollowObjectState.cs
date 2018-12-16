using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowObjectState : CameraState
{
    private GameObject followObject;
    private float distance;

    public CameraFollowObjectState(CameraController camera, GameObject followObject) : base(camera)
    {
        this.followObject = followObject;
        distance = 400;
    }

    public void SetDistance(float distance)
    {
        this.distance = distance;
    }

    public override void OnStateEnter()
    {
        camera.AnimateTo(new Vector3(followObject.transform.position.x, followObject.transform.position.y, distance));
    }

    public override void OnStateExit()
    {

    }

    public override void Tick()
    {
        camera.AnimateTo(followObject.transform.position - new Vector3(0, 0, distance));
    }
}
