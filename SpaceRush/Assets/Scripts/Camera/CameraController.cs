using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private CameraState state;
    private float moveTime;
    private float easeOutFactor;
    private Animator animator;
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;
    private float minZ;
    private float maxZ;

    void Awake()
    {
        moveTime = 2f;
        easeOutFactor = 2;
        animator = new Animator();

        minX = float.MinValue;
        maxX = float.MaxValue;
        minY = float.MinValue;
        maxY = float.MaxValue;
        minZ = float.MinValue;
        maxZ = 0;
    }

    void Update()
    {
        if (state != null)
        {
            state.Tick();
        }
        if (animator.IsRunning())
        {
            gameObject.transform.position = animator.NextPosition(Time.deltaTime);
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

    public void AnimateTo(Vector3 position)
    {
        if (position.x > maxX)
        {
            position.x = maxX;
        }
        if (position.x < minX)
        {
            position.x = minX;
        }
        if (position.y > maxY)
        {
            position.y = maxY;
        }
        if (position.y < minY)
        {
            position.y = minY;
        }
        if (position.z > maxZ)
        {
            position.z = maxZ;
        }
        if (position.z < minZ)
        {
            position.z = minZ;
        }
        animator.SetAnimation(gameObject.transform.position, position, moveTime, easeOutFactor);
    }

    public void StopAnimating()
    {
        animator.Reset();
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
