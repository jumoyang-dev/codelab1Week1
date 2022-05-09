using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveNew : MonoBehaviour
{
    public GameObject endText;

    public float mouseSens;
    public float clampAngle;
    float rotationX;
    float rotationY;

    void Start()
    {
        Cursor.visible = false;
        endText.SetActive(false);

        //turning location rotation into Euler and store in a Vector3
        Vector3 startRotation = transform.localRotation.eulerAngles;
        rotationX = startRotation.x;
        rotationY = startRotation.y;

    }

    void Update()
    {
        //draw a ray from the center of the camera
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        // to store information about the collision
        RaycastHit hitinfo = new RaycastHit();

        if (Physics.Raycast(ray, out hitinfo, 17))
        {
            //Debug.Log(hitinfo.collider.gameObject.name);

            //if hitting something, draw a red line
            Debug.DrawLine(ray.origin, hitinfo.point, Color.red);

            if (Input.GetMouseButtonDown(0) && hitinfo.collider.gameObject.tag == "teleport")
            {
                //teleport to the object location if the raycast hit
                transform.position = hitinfo.transform.position;
                //set the raycast object as parent
                transform.parent = hitinfo.transform;

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
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 15, Color.green);
        }

        MoveCamera();
    }

    void MoveCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotationX -= mouseY * mouseSens * Time.deltaTime;
        rotationY += mouseX * mouseSens * Time.deltaTime;

        //limit rotation in certain range
        rotationX = Mathf.Clamp(rotationX, -clampAngle, clampAngle);

        //turn back Euler to Quaternion
        Quaternion newRotation = Quaternion.Euler(rotationX, rotationY, 0);
        transform.rotation = newRotation;
        
    }
    
}
