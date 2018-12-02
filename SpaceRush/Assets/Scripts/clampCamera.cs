using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clampCamera : MonoBehaviour
{

    public GameObject clampObject;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(clampObject.transform.position.x, clampObject.transform.position.y, this.transform.position.z); ;
        //this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, clampObject.transform.eulerAngles.z);
    }
}
