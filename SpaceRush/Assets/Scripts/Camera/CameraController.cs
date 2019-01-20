using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private CameraState state;
    public float smoothFac;
    public Vector3 offset;
    public float extraDist;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float minZ;
    public float maxZ;

    void Awake()
    { }

    void FixedUpdate()
    {
        if (state != null)
        {
            state.Tick();
        }
    }

    public void SetBoundaries(float minX, float minY, float minZ, float maxX, float maxY, float maxZ)
    {
        this.minX = minX;
        this.maxX = maxX;
        this.minY = minY;
        this.maxY = maxY;
        this.minZ = minZ;
        this.maxZ = maxZ;
    }

    public void AnimateTo(Vector3 desiredPosition)
    {
        if (desiredPosition.x > maxX)
        {
            desiredPosition.x = maxX;
        }
        if (desiredPosition.x < minX)
        {
            desiredPosition.x = minX;
        }
        if (desiredPosition.y > maxY)
        {
            desiredPosition.y = maxY;
        }
        if (desiredPosition.y < minY)
        {
            desiredPosition.y = minY;
        }
        if (desiredPosition.z > maxZ)
        {
            desiredPosition.z = maxZ;
        }
        if (desiredPosition.z < minZ)
        {
            desiredPosition.z = minZ;
        }
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPosition, smoothFac);
        transform.position = smoothedPos;
    }

    public void FollowObject(GameObject gameObject)
    {
        CameraState newState = new CameraFollowObjectState(this, gameObject);
        SetState(newState);
    }

    public void FollowObjects(List<GameObject> gameObjects)
    {
        CameraState newState = new CameraFollowObjectsState(this, gameObjects);
        SetState(newState);
    }

    public void FreeNavigation()
    {
        CameraState newState = new CameraNavigationState(this);
        SetState(newState);
    }

    public void SetFixedPosition(Vector3 position)
    {
        CameraState newState = new CameraFixedState(this, position);
        SetState(newState);
    }

    private void SetState(CameraState newState)
    {
        if (state != null)
        {
            state.OnStateExit();
        }
        state = newState;
        if (state != null)
        {
            state.OnStateEnter();
        }
    }

}
