using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintSphereInfo : PrintObjInfo
{

    void Start()
    {
        //Debug.Log(MakeInfoString());
    }

    void Update()
    {
        
    }

    protected override string MakeInfoString()
    {
        //return base.MakeInfoString();
        SphereCollider sc = GetComponent<SphereCollider>();
        string sphereInfo = base.MakeInfoString() +
                            "\nRadius: " + sc.radius +
                            "\nMaterial: " + sc.material +
                            "\nCenter: " + sc.center;
        return sphereInfo;

    }
}
