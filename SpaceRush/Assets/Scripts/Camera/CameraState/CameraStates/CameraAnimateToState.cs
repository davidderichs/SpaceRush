using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimateToState : CameraState
{
    private Vector3 desiredPosition;
    private Vector3 startPosition;
    private float lerpTime;
    private float startTime;
    private CameraState nextState;

    public CameraAnimateToState(CameraController camera, Vector3 position, float animationTime, CameraState nextState) : base(camera)
    {
        desiredPosition = camera.GetPointInBoundaries(position);
        lerpTime = animationTime;
        this.nextState = nextState;
    }

    public override void Tick()
    {
        float timeSinceStarted = Time.time - startTime;
        float completedPercentage = timeSinceStarted / lerpTime;
        camera.transform.position = Vector3.Lerp(startPosition, desiredPosition, completedPercentage);
        if (completedPercentage >= 1.0f)
        {
            camera.SetState(nextState);
        }
    }

    public override void OnStateEnter()
    {
        startTime = Time.time;
        startPosition = camera.gameObject.transform.position;
    }

    public override void OnStateExit()
    {
    }
}
