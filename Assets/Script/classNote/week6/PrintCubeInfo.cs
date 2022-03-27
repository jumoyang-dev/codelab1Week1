using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//inherite from PrintObjInfo Script instead of MonoBehaviour
//PrintCubeInfo exteneded from PrintObjInfo
public class PrintCubeInfo : PrintObjInfo
{
    void Start()
    {
        //Debug.Log(MakeInfoString());
    }

    void Update()
    {
        
    }

    //override = rewrites OR adds to MakeInfoString
    protected override string MakeInfoString()
    {
        BoxCollider bc = GetComponent<BoxCollider>();
        string cubeInfo = base.MakeInfoString() +
                          "\nSize: " + bc.size +
                          "\nMaterials: " + bc.material +
                          "\nCenter: " + bc.center;
        return cubeInfo;
        //return base.MakeInfoString();
    }

}
