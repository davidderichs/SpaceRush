using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator
{

    private float animationTime;
    private float easeOutFactor;
    private Vector3 startPosition;
    private Vector3 desiredPosition;
    private float currentTime;
    private bool running;
    private Vector3 distanceVec;

    public Animator()
    {
        animationTime = 0;
        easeOutFactor = 1;
        startPosition = new Vector3();
        desiredPosition = new Vector3();
        distanceVec = new Vector3();
        currentTime = 0;
        running = false;
    }

    public void SetAnimation(Vector3 startPosition, Vector3 desiredPosition, float animationTime, float easeOutFactor)
    {
        this.animationTime = animationTime;
        this.easeOutFactor = easeOutFactor;
        this.startPosition = startPosition;
        this.desiredPosition = desiredPosition;
        currentTime = 0;
        running = true;
        distanceVec = desiredPosition - startPosition;
    }

    public bool IsRunning()
    {
        return running;
    }

    public Vector3 NextPosition(float deltaTime)
    {
        if (running)
        {
            currentTime += deltaTime;
            if (currentTime >= animationTime)
            {
                running = false;
                return desiredPosition;
            }
            float fac = currentTime / animationTime;
            fac = -Mathf.Pow(-fac + 1, easeOutFactor) + 1;
            return startPosition + distanceVec * fac;
        }
        return desiredPosition;
    }

    public void Reset()
    {
        animationTime = 0;
        easeOutFactor = 1;
        startPosition = new Vector3();
        desiredPosition = new Vector3();
        distanceVec = new Vector3();
        currentTime = 0;
        running = false;
    }
}
