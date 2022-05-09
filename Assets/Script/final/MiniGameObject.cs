using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameObject : MonoBehaviour
{
    private SpriteRenderer grassSprite;

    public Sprite newGrass;
    public GameObject password;

    private float amplitude = 0.1f;
    private float frequency = 3f;
    private bool crushed;
    private Vector2 adjust;

    private void Start()
    {
        grassSprite = gameObject.GetComponent<SpriteRenderer>();

        //used for cos movement later
        adjust.x = transform.position.x;
        adjust.y = transform.position.y;
    }
    private void OnMouseOver()
    {
       
        if (Input.GetKeyDown(KeyCode.H))
        {
            //destory rock
            if (gameObject.tag == "ROCK")
            {
                Destroy(gameObject);
            }
            //change grass sprite
            if (gameObject.tag == "GRASS")
            {
                crushed = true;
                grassSprite.sprite = newGrass;
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        //if player reach pond
        if (triggerCollider.tag == "Player" && gameObject.tag == "POND")
        {
            Debug.Log("reach Pond");
            password.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "Player" && gameObject.tag == "GRASS" && !crushed)
        {
            cosMovement();
        }
    }
    void cosMovement()
    {
        float x = Mathf.Sin(Time.time * frequency) * amplitude + adjust.x;
        float y = transform.position.y;
        float z = transform.position.z;
        transform.position = new Vector3(x,y,z);
    }

}
