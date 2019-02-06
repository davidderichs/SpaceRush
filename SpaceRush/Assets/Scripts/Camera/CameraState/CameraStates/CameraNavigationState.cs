using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraNavigationState : CameraState
{
    private float zoomFactor;
    private float moveStep;
    private float padding;
    private Camera realCamera;
    public CameraNavigationState(CameraController camera) : base(camera) { }

    public override void OnStateEnter()
    {
        zoomFactor = 2;
        moveStep = 50;
        padding = .2f;
        realCamera = camera.gameObject.GetComponent<Camera>();
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
        
        Vector3 mousePos = realCamera.ScreenToViewportPoint(Input.mousePosition);
        if(mousePos.x > 0 && mousePos.x < padding) {
            float fac = (mousePos.x - padding) / padding;
            position.x += fac * moveStep;
        }
        if(mousePos.x > 1 - padding && mousePos.x < 1) {
            float fac = (mousePos.x - (1 - padding)) / padding;
            position.x += fac * moveStep;
        }
        if(mousePos.y > 0 && mousePos.y < padding) {
            float fac = (mousePos.y - padding) / padding;
            position.y += fac * moveStep;
        }
        if(mousePos.y > 1 - padding && mousePos.y < 1) {
            float fac = (mousePos.y - (1 - padding)) / padding;
            position.y += fac * moveStep;
        }
        
        

        camera.AnimateTo(position);
    }

}
