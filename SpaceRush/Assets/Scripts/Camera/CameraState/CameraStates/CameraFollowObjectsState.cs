using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowObjectsState : CameraState
{
    private List<GameObject> gameObjects;
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;
    private float centerX;
    private float centerY;
    private float maxSize;
    private float aspectRation;
    private float tanFOV;

    public CameraFollowObjectsState(CameraController camera, List<GameObject> gameObjects) : base(camera)
    {
        this.gameObjects = gameObjects;
    }

    public override void OnStateEnter()
    {
        aspectRation = Screen.width / Screen.height;
        tanFOV = Mathf.Tan(Mathf.Deg2Rad * Camera.main.fieldOfView / 2f);
    }

    public override void OnStateExit() { }

    public override void Tick()
    {
        Vector3 camPos = camera.transform.position;
        Vector3 vecBetweenObjs = gameObjects[1].transform.position - gameObjects[0].transform.position;
        float distance = vecBetweenObjs.magnitude;
        Vector3 middle = gameObjects[0].transform.position + 0.5f * vecBetweenObjs;
        float camDist = (distance / 2.0f / aspectRation) / tanFOV;
        camPos.x = middle.x;
        camPos.y = middle.y;
        camPos.z = middle.z - camDist - camera.extraDist;
        camera.AnimateTo(camPos);
    }
}
