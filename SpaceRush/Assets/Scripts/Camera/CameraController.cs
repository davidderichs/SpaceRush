using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private CameraState state;
    private float moveTime;
    private float easeOutFactor;
    private Animator animator;

    void Awake()
    {
        moveTime = 2f;
        easeOutFactor = 2;
        animator = new Animator();
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

    public void AnimateTo(Vector3 position)
    {
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
