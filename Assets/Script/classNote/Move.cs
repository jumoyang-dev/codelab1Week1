using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    float speed = 3;
    double twoDigits = 2.31;

    SpriteRenderer myRenderer;

    enum states {mainMenu, gameScreen, gameOver};

    private void Start()
    {
        Debug.Log(speed);
    }
    private void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 direction = input.normalized;
        Vector3 velocity = direction * speed * Time.deltaTime;
        transform.position += velocity;
    }

}
