using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float CubeSpeed;
    private Rigidbody2D cubeRb;
    //point effctor for attracting the ball
    private PointEffector2D cubePE2D;
    //setting a limit for the sticking time
    public float maxStickingTime;
    private float currentTime;
    //reference to the CubeUI code to access the slider
    public CubeUI CubeUI;

    //game manager 
    public GameManager GameManager;
    void Start()
    {
        //we are also using rb to move the cube
        cubeRb = GetComponent<Rigidbody2D>();

        cubePE2D = GetComponent<PointEffector2D>();
        cubePE2D.enabled = false;

        currentTime = maxStickingTime;

        //set the max sticking time for the UI slider
        CubeUI.SetMaxTime(maxStickingTime);
    }

    void Update()
    {
        Sticking();
    }
    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.J))
        {
            //z rotation positive is going left 
            //add torque to add angular drag, which is more 
            //fitting for the cube movement
            cubeRb.AddTorque(CubeSpeed);
        }
        if (Input.GetKey(KeyCode.L))
        {
            //z rotation negative is going right
            cubeRb.AddTorque(-CubeSpeed);
        }
    }

    void Sticking()
    {
        if (currentTime > 0)
        {
            //enable the attraction by pressing K key
            if (Input.GetKey(KeyCode.K))
            {
                cubePE2D.enabled = true;
                //print("isSticking");
                //decrease sticking time when trying to stick the ball
                currentTime -= Time.deltaTime;
                //setting UI slider
                CubeUI.SetSlider(currentTime);
            }
            else
                cubePE2D.enabled = false;

        }
        if (currentTime <= 0)
        {
            cubePE2D.enabled = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //detect goal zone by tag
        if (collision.tag == "Goal")
        {
            GameManager.cubeIn = true;
        }
    }
}
