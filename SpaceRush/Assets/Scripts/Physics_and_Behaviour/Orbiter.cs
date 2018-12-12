using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiter : MonoBehaviour
{

    public GameObject parent;
    public float minDistance;
    public float maxDistance;
    public float orbitTime;
    public float ellipseRotation;
    public float offsetX;
    public float offsetY;
    public bool clockwise;
    private float timePassed;

    void OnEnable()
    {
        timePassed = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timePassed += Time.deltaTime;
        if (timePassed > orbitTime)
        {
            timePassed -= orbitTime;
        }
        float timeQuotient = timePassed;
        if (clockwise)
        {
            timeQuotient = orbitTime - timeQuotient;
        }
        float value = timeQuotient / orbitTime * 2 * Mathf.PI;
        float newX = Mathf.Cos(value) * maxDistance;
        float newY = Mathf.Sin(value) * minDistance;
        Vector2 newPosition = Vector2Extensions.Rotate(new Vector2(newX, newY), (ellipseRotation * Mathf.Deg2Rad)) + new Vector2(offsetX, offsetY);
        transform.position = parent.transform.position + new Vector3(newPosition.x, newPosition.y, 0);
    }
}
