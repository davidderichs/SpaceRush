using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Collider2D coll;
    private Light point;
    public int id;
    public GameManager game;

    // Use this for initialization
    void Start()
    {
        coll = GetComponent<Collider2D>();
        point = GetComponent<Light>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Spacecraft")
        {
            point.color = Color.green;
            game.checkpointTriggered(id, game.player_1);
        }
    }
}
