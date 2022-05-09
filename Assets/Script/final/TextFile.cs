using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFile :  DoubleClick
{
    public GameObject TextPrefab;
    private GameObject openText;
    void Update()
    {
        Clicking();
    }
    //override OnMouseDown function from DoubleClick script
    public override void OnMouseDown()
    {
        base.OnMouseDown();
        if (clickTimes >= 2)
        {
            clickTimes = 0;
            Debug.Log("double clicked");
            //double click event 
            Debug.Log("clicked on text file");
            //instantiate the text prefab and cast it as a GameObject if the prefab hasn't been spawned yet
            if (openText == null)
            {
                openText = (GameObject)Instantiate(TextPrefab, Vector3.zero, Quaternion.identity);
            }
        }
    }

}
