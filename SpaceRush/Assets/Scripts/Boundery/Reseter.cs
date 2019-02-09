using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reseter : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.gameObject.name == "Spacecraft1")
        {
            EventManager.TriggerEvent("Player_1_reset");
        }
        if (other.transform.gameObject.name == "Spacecraft2")
        {
            EventManager.TriggerEvent("Player_2_reset");
        }
    }

}