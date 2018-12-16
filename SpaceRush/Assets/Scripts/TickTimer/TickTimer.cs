using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickTimer : MonoBehaviour
{

    private float tickTime;
    private float currentTickTime;
    private int ticks;
    private int currentTicks;
    private bool infinite;
    private ITickable tickable;


    void Awake()
    {
        this.enabled = false;
    }
    public void SetProperties(ITickable tickable, float tickTime, int ticks)
    {
        this.tickable = tickable;
        this.tickTime = tickTime;
        this.ticks = ticks;
        this.infinite = false;
        currentTickTime = 0;
    }

    public void SetProperties(ITickable tickable, float tickTime)
    {
        this.tickable = tickable;
        this.tickTime = tickTime;
        this.ticks = 0;
        this.infinite = true;
        currentTickTime = 0;
    }

    public void StartTimer()
    {
        if (tickTime <= 0)
        {
            return;
        }
        this.enabled = true;
        tickable.Tick(false);
        currentTicks++;
    }

    public void StopTimer()
    {
        this.enabled = false;
    }

    public void SetTicks(int ticks)
    {
        this.ticks = ticks;
    }

    public void SetTickTime(float tickTime)
    {
        if (tickTime <= 0)
        {
            return;
        }
        this.tickTime = tickTime;
    }

    public void setTickable(ITickable tickable)
    {
        this.tickable = tickable;
    }

    public void SetInfinite(bool infinite)
    {
        this.infinite = infinite;
    }

    public void Reset()
    {
        currentTicks = 0;
        currentTickTime = 0;
        StopTimer();
    }

    void Update()
    {
        if (tickable != null && tickTime > 0)
        {
            currentTickTime += Time.deltaTime;
            if (currentTickTime >= tickTime)
            {
                currentTickTime = 0;
                if (infinite)
                {
                    tickable.Tick(false);
                }
                else
                {
                    currentTicks++;
                    if (currentTicks > ticks)
                    {
                        Reset();
                        tickable.Tick(true);
                    }
                    else
                    {
                        tickable.Tick(false);
                    }
                }
            }
        }
    }

}
