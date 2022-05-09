using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageFile : DoubleClick
{

    public GameObject imagePrefab;
    private GameObject openImage;
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
            //double click event 
            Debug.Log("clicked on Image file");
            if (openImage == null)
            {
                openImage = (GameObject)Instantiate(imagePrefab, Vector3.zero, Quaternion.identity);
            }
        }
    }
}
