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

    public CameraFollowObjectsState(CameraController camera, List<GameObject> gameObjects) : base(camera)
    {
        this.gameObjects = gameObjects;
    }

    public override void OnStateEnter()
    {
        CalcValues();
        camera.AnimateTo(GetNewPosition());
    }

    public override void OnStateExit() { }

    public override void Tick()
    {
        CalcValues();
        camera.AnimateTo(GetNewPosition());
    }

    private void CalcValues()
    {
        minX = float.MaxValue;
        maxX = float.MinValue;
        minY = float.MaxValue;
        maxX = float.MinValue;
        foreach (GameObject obj in gameObjects)
        {
            Vector3 pos = obj.transform.position;
            if (pos.x < minX)
            {
                minX = pos.x;
            }
            if (pos.x > maxX)
            {
                maxX = pos.x;
            }
            if (pos.y < minY)
            {
                minY = pos.y;
            }
            if (pos.y > maxY)
            {
                maxY = pos.y;
            }
        }
        float sizeX = maxX - minX;
        float sizeY = maxY - minY;
        centerX = minX + sizeX / 2;
        centerY = minY + sizeY / 2;
    }

    private Vector3 GetNewPosition()
    {
        float distance = (maxSize / 2) / Mathf.Tan(camera.GetComponent<Camera>().fieldOfView / 2);
        return new Vector3(centerX, centerY, -1000);
    }
}
