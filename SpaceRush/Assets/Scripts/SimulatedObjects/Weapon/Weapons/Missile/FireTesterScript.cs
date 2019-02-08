using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTesterScript : MonoBehaviour
{

    float timer;
    bool fired;

    // Use this for initialization
    void Start()
    {
        timer = 0;
        fired = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3 && !fired)
        {
            GameObject missile = (GameObject)Instantiate(Resources.Load("Prefabs/weapons/weaponMissile"), transform.position, transform.rotation);
            missile.GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
            fired = true;
        }
    }
}
