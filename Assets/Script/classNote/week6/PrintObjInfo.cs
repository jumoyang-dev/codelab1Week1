using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintObjInfo : MonoBehaviour
{

    void Start()
    {
        //print(MakeInfoString());
    }

    void Update()
    {
        
    }

    public string MakeDebugString()
    {
        return MakeInfoString();
    }
    //protected = a protected function can be used by that class and the extended class
    //virtual = means an extended classes will use this function by default if you don't recreat its own
    //abstract = means an extended class HAS to have a new version of this function

    protected virtual string MakeInfoString()
    {
        string infoString;
        infoString = "Name: " + gameObject.name +
                     "Position: " + transform.position +
                     "Rotation: " + transform.rotation +
                     "Scale: " + transform.localScale;
        return infoString;
    }

}
