using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderFile : DoubleClick
{
    public GameObject folderPrefab;
    private GameObject openFolder;
    
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
            //double click event goes here
            Debug.Log("clicked on Folder file");
            //instantiate the folder prefab and cast it as a GameObject if the prefab hasn't been spawned yet
            if (openFolder == null)
            {
                openFolder = (GameObject)Instantiate(folderPrefab, Vector3.zero, Quaternion.identity);
            }       
        }
    }
}
