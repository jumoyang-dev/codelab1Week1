using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject endText;
    void Start()
    {
        endText.SetActive(false);
    }

    void Update()
    {
        //player position
        Vector3 eyePos = transform.position;
        //where the mouse is looking at
        Vector3 mousePos = Input.mousePosition;
        //prevent things outside the nearClipPlane to be clicked on
        mousePos.z = Camera.main.nearClipPlane;

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

        //get direction from camera to mouse
        Vector3 direction = mouseWorldPos - eyePos;
        direction.Normalize();

        // to store information about the collision
        RaycastHit hitinfo = new RaycastHit();

        if (Physics.Raycast(eyePos, direction, out hitinfo, 17))
        {
            //Debug.Log(hitinfo.collider.gameObject.name);

            //if hitting something, draw a red line
            Debug.DrawLine(eyePos, hitinfo.point, Color.red);

            if (Input.GetMouseButtonDown(0) && hitinfo.collider.gameObject.tag == "teleport")
            {
                //teleport to the object location if the raycast hit
                transform.position = hitinfo.transform.position;
            }//if reach the end point
            else if (Input.GetMouseButtonDown(0) && hitinfo.collider.gameObject.tag == "teleportEnd")
            {
                //teleport to the object location if the raycast hit
                transform.position = hitinfo.transform.position;
                endText.SetActive(true);
            }

        }
        else
        {
            //if not hitting anything, draw a green line
            Debug.DrawLine(eyePos, eyePos + direction * 15, Color.green);
        }

        //rotate camera
        CameraRotate(KeyCode.A, 0, 1);
        CameraRotate(KeyCode.D, 0, -1);
    }

    //rotate the camera with keypress
    void CameraRotate(KeyCode key, float speedX, float speedY)
    {
        if (Input.GetKey(key))
        {
            transform.Rotate(speedX, -speedY,0, Space.World);
        }
    }
}
