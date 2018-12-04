using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    private SpacecraftController spacecraft;


    // Use this for initialization
    void OnEnable()
    {
        spacecraft = GetComponent<SpacecraftController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            spacecraft.BoostForwards(1);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            spacecraft.BoostBackwards(1);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            spacecraft.Rotate(1, SpacecraftController.Direction.Left);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            spacecraft.Rotate(1, SpacecraftController.Direction.Right);
        }
    }

}
