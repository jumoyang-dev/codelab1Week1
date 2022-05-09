using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshake : MonoBehaviour
{
    private float shakeDuration = 0f;
    private float shakeMagnitude = 0.7f;
    private float dampingSpeed = 1.5f;

    Vector3 initialPosition;

    public GameObject[] crack; 

    void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        //shake screen if Duration > 0
        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        //reset back to initial pos after finish
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }

        TriggerShake();
    }
    //if H key is pressed, shake the screen for 0.3s 
    public void TriggerShake()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            shakeDuration = 0.3f;

            //spawn a crack prefab on screen
            Instantiate(crack[Random.Range(0, crack.Length)], mousePos(), Quaternion.identity);
        }
        
    }
    private Vector3 mousePos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
