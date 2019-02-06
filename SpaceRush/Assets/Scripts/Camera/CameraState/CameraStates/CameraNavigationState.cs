using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraNavigationState : CameraState
{
    private float zoomFactor;
    private float moveStep;
    private int padding;
    public CameraNavigationState(CameraController camera) : base(camera) { }

    public override void OnStateEnter()
    {
        zoomFactor = 2;
        moveStep = 50;
        padding = 100;
    }

    public override void OnStateExit() { }

    public override void Tick()
    {
        Vector3 position = camera.gameObject.transform.position;
        if (Input.GetKey(KeyCode.Plus))
        {
            position.z /= zoomFactor;
        }
        if (Input.GetKey(KeyCode.Minus))
        {
            position.z *= zoomFactor;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            position.y += moveStep;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            position.y -= moveStep;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            position.x -= moveStep;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            position.x += moveStep;
        }
        if (Input.mouseScrollDelta.y > 0)
        {
            position.z /= zoomFactor;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            position.z *= zoomFactor;
        }
        
        Vector3 mousePosition = Input.mousePosition;
        

        camera.AnimateTo(position);
    }

}
