using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MoveCard
{


    public string direction;
    public int intensity;
    public bool useSprite;
    public string spritePath;
    public Color color;
    public string kind_Of_Movement;
    public float duration;
    public float forceOrVelocity;

    public MoveCard(string direction, int intensity, Color color, bool useSprite, string spritePath, string kind_Of_Movement, float duration, float forceOrVelocity)
    {
        this.direction = direction;
        this.intensity = intensity;
        this.color = color;
        this.useSprite = true;
        this.spritePath = spritePath;
        this.kind_Of_Movement = kind_Of_Movement;
        this.duration = duration;
        this.forceOrVelocity = forceOrVelocity;
    }

    public MoveCard(string direction, int intensity, Color color, string kind_Of_Movement, float duration, float forceOrVelocity)
    {
        this.direction = direction;
        this.intensity = intensity;
        this.color = color;
        this.useSprite = false;
        this.spritePath = "";
        this.kind_Of_Movement = kind_Of_Movement;
        this.duration = duration;
        this.forceOrVelocity = forceOrVelocity;
    }

    // Use this for initialization

    void Awake()
    {

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
