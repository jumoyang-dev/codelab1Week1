using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : MonoBehaviour
{
    public bool isStaying;
    private static Face instance;
    public static Face GetInstance()
    {
        return instance;
    }
    private void OnTriggerStay2D(Collider2D triggercollider)
    {
        //returns isStaying bool to true when enter the head's trigger collider
        if (triggercollider.tag == "head")
        {
            isStaying = true;
        }
    }
    private void OnTriggerExit2D(Collider2D triggercollider)
    {
        if (triggercollider.tag == "head")
        {
            isStaying = false;
        }
    }
}
