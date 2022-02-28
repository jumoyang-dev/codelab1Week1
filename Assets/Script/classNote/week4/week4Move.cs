using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class week4Move : MonoBehaviour
{
    public float moveSpeed;
    void Start()
    {
        
    }

    void Update()
    {
        Move(KeyCode.W, 0, moveSpeed);
        Move(KeyCode.S, 0, -moveSpeed);
        Move(KeyCode.A, -moveSpeed, 0);
        Move(KeyCode.D, moveSpeed, 0);
    }

    void Move(KeyCode key, float xMove, float yMove)
    {
        if (Input.GetKey(key))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(xMove, yMove, 0);
        }
    }
}
