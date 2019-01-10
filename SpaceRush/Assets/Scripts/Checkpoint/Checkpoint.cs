using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Light point;
    public int id;
    private GameManager game;

    // Use this for initialization
    void Start()
    {
        point = GetComponent<Light>();
        game = GameObject.Find("GameManager").GetComponent<GameManager>();;
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
