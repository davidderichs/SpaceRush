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

    public GameObject gameObject;
    public Transform transform;

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

    public static int StringToHash(string value){
     int result = 0;
     for (int i = 0; i < value.Length; i++)
     {
         char letter = value[i];
         result = 10 * result + (letter - 48);
     }
     return result;
    }

    public void SetBool(int hash, bool value){
        // Kein Plan, was hier passieren muss.
    }

    public bool GetBool(int value){
        if (value <= 0 ) return false;
        if (value > 0) return true;
        return false;
    }

    public bool IsInTransition(int value){
        return true;
    }

    public AnimatorTransitionInfo GetCurrentAnimatorStateInfo(int value){
        return new AnimatorTransitionInfo();
    }
}
