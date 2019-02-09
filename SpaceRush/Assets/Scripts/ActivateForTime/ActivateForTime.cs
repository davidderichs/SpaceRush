using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateForTime : MonoBehaviour
{

    private float timer;
    private float duration;
    public GameObject controlledObject;

    // Use this for initialization
    void Start()
    {
        timer = 0;
        duration = 0;
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= duration)
        {
            controlledObject.SetActive(false);
            this.enabled = false;
        }
    }

    public void Play(float duration)
    {
        this.enabled = true;
        this.duration = duration;
        timer = 0;
        controlledObject.SetActive(true);
    }
}
