using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float zoomSpeed, panSpeed;
    Camera myCam;

    void Start()
    {
        //get camera component
        myCam = gameObject.GetComponent<Camera>();
    }
    void Update()
    {
        CameraPan(KeyCode.A, -panSpeed, 0);
        CameraPan(KeyCode.D, panSpeed, 0);
        CameraPan(KeyCode.W, 0, panSpeed);
        CameraPan(KeyCode.S, 0, -panSpeed);
        CameraZoom(KeyCode.Q, -zoomSpeed);
        CameraZoom(KeyCode.E, zoomSpeed);
    }
    //function to pan the camera
    void CameraPan(KeyCode key, float xSpeed, float ySpeed)
    {
        if (Input.GetKey(key))
        {
            gameObject.transform.Translate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, 0);
        }
    }
    //function to zoom the camera
    void CameraZoom(KeyCode key, float zoomSpeed)
    {
        if (Input.GetKey(key))
        {
            myCam.orthographicSize += zoomSpeed * Time.deltaTime;
        }
    }
}
