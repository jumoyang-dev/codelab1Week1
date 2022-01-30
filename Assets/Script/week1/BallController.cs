using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    private Animator ballAni;
    public float BallSpeed;
    private Rigidbody2D ballRb;
    //point effector for explosion 
    private PointEffector2D ballPE2D;

    //max explosion time
    public int maxExplosionCount;
    private int currentExplodeLeft;

    public Text currentExplodeText;
    //refer game manager
    public GameManager GameManager;

    void Start()
    {
        //get animator
        ballAni = GetComponent<Animator>();
        //get rb component
        ballRb = GetComponent<Rigidbody2D>();
        //get point effector
        ballPE2D = GetComponent<PointEffector2D>();

        currentExplodeLeft = maxExplosionCount;
    }

    
    void Update()
    {
        Explode();
    }
    //fixedUpdate for rb movement
    private void FixedUpdate()
    {
        Movement();
    }

    //movement code here
    void Movement()
    {
        //for player Ball, use A & D to move left and right
        //use rb instead of transform.position here to emphasise the weight of the steel ball
        if (Input.GetKey(KeyCode.A))
        {
            ballRb.AddForce(new Vector2(-BallSpeed,0));
            //Debug.Log("holding A");
        }
        if (Input.GetKey(KeyCode.D))
        {
            ballRb.AddForce(new Vector2(BallSpeed,0));
        }
    }
    void Explode()
    {
        //enabled the explosion by keydown S key
        if (Input.GetKeyDown(KeyCode.S) && currentExplodeLeft > 0)
        {
            ballPE2D.enabled = true;
            currentExplodeLeft--;
            //display current explosion left in UI
            currentExplodeText.text = "Bomb Left: " + currentExplodeLeft.ToString();
        }
        else
            ballPE2D.enabled = false;

        //set animation when there's no explosion left
        if (currentExplodeLeft == 0)
        {
            ballAni.SetBool("Burned", true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //detect goal zone by tag
        if (collision.tag == "Goal")
        {
            GameManager.ballIn = true;
        }
    }
}
