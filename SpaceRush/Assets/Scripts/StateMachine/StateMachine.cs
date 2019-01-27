using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private int state = 1;


    public void nextState()
    {
        if (state == 4)
        {
            state = 1;
        }
        else
        {
            state++;
        }
        //Debug.Log("State changed to " + state);
    }
    public int getState()
    {
        return state;
    }

    public void setState(int status)
    {
        state = status;
    }
}
