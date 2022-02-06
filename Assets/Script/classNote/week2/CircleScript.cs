using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : MonoBehaviour
{

    void Start()
    {
        Debug.Log(W2SceneManager.score);
    }

    void Update()
    {
        transform.position = UtilScript.Vector3Modify(transform.position, W2SceneManager.circleSpeed, 0f, 0f);

        // W2SceneManager myManager = GameObject.Find("SceneManager").GetComponent<W2SceneManager>();
        W2SceneManager myManager = W2SceneManager.GetInstance();
        Debug.Log("High score: " + myManager.HighScore);
    }
}
