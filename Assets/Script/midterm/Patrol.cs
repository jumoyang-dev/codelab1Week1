using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    GameManagerMidterm myManager;

    public float speed;
    public float startWaitTime;

    private GameObject moveSpot;

    private float waitTime;
    private Animator animator;

    
    void Start()
    {
        //get instance of gameManager
        myManager = GameManagerMidterm.GetInstance();

        animator = GetComponent<Animator>();
        waitTime = startWaitTime;
        //instantiate a spot at random pos for the gameObject to move to
        moveSpot = Instantiate(Resources.Load("MoveSpot")) as GameObject;
        moveSpot.transform.position = new Vector2(Random.Range(myManager.minRange.x, myManager.maxRange.x), Random.Range(myManager.minRange.y, myManager.maxRange.y));
    }

    void Update()
    {
        //don't run the code below if we haven't click the spawn button
        if (!animator.GetBool("startIdle")) return;

        //move the object toward the movespot pos
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.transform.position, speed*Time.deltaTime);
        //if close enough to the movespot pos
        if (Vector2.Distance(transform.position, moveSpot.transform.position) < 0.2f)
        {
            //stop walking animation
            animator.SetBool("startWalk", false);
            //when waitTime is over, get another randomSpot location
            if (waitTime <= 0)
            {
                moveSpot.transform.position = new Vector2(Random.Range(myManager.minRange.x, myManager.maxRange.x), Random.Range(myManager.minRange.y, myManager.maxRange.y));
                //reset waittime
                waitTime = startWaitTime;
            }
            else
            {
                //decuct the time if the time is not zero
                waitTime -= Time.deltaTime;
            }
        }
        //else keep walking animation on
        else
        {
            animator.SetBool("startWalk", true);
        }

    }
}
