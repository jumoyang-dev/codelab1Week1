using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInput : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject[] gameObjs = GameObject.FindObjectsOfType<GameObject>();
           //for every gameobjects found in array of gameObjs
           //foreach loop for dynanic range of array
           //for loop for known length of array
            foreach(GameObject obj in gameObjs)
            {
                PrintObjInfo infoPrinter = obj.GetComponent<PrintObjInfo>();
                if (infoPrinter != null)
                {
                    //for class that are not inherite from the PrintObjInfo, to use MakeInfoString function
                    Debug.Log(infoPrinter.MakeDebugString());
                }
            }
        }
    }
}
