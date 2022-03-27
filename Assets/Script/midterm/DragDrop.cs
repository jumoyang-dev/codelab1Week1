using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    GameManagerMidterm myManager;

    public string spawnedObjectName;

    private bool isDragging;

    private GameObject spawnedObject;

    private GameObject head;

    Face Face;
    private void Start()
    {
        //get instance of gameManager
        myManager = GameManagerMidterm.GetInstance();
    }
    private void Update()
    {
        if (!isDragging) return;
        //get the mouse position and turn it into a Vector2
        var mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        //change its position to match the mouse movement
        spawnedObject.transform.position = mousePos;

    }
    private void OnMouseDown()
    {
        //spawned to related object
        spawnedObject = Instantiate(Resources.Load(spawnedObjectName)) as GameObject;
        //get the Face script of the spawned object to access its bool 
        Face = spawnedObject.GetComponent<Face>();

        head = myManager.spawnedObject[myManager.currentSpawnNum].transform.Find("root/chest/bone_head").gameObject;
    }
    private void OnMouseDrag()
    {
        isDragging = true;
    }
    private void OnMouseUp()
    {
        isDragging = false;
        //if isStaying bool is true, set the spawnedObject as a child to the bone_head gameObject
        if (Face.isStaying)
        {
            print("inside head");
            spawnedObject.transform.parent = head.transform;
        }
        //else, destory the spawnObject
        else
        {
            print("outside head");
            Destroy(spawnedObject);
        }
    }

}
