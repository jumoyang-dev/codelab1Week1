using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigUtil : MonoBehaviour
{
    public float amplitude;
    public float frequency;
    void Start()
    {
        
    }

    void Update()
    {

        float x = Mathf.Cos(Time.time * frequency) * amplitude;
        float y = Mathf.Sin(Time.time * frequency) * amplitude;
        float z = transform.position.z;

        transform.position = new Vector3(x, y, z);

    }
}
