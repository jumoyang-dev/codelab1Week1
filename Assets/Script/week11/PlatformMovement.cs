using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float amplitude;
    public float frequency;

    float zAdjust;
    float xAdjust;

    //if want the object to move in x or z direction
    public bool xdir;
    public bool zdir;

    private void Start()
    {
        xAdjust = transform.position.x;
        zAdjust = transform.position.z;
    }
    void Update()
    {
        if (xdir)
        {
            XMove();
        }
        if(zdir)
        {
            ZMove();
        }

    }

    void XMove()
    {
        float x = Mathf.Cos(Time.time * frequency) * amplitude + xAdjust;
        float y = transform.position.y;
        float z = transform.position.z;

        transform.position = new Vector3(x, y, z);
    }
    void ZMove()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = Mathf.Sin(Time.time * frequency) * amplitude + zAdjust;

        transform.position = new Vector3(x, y, z);
    }

}
