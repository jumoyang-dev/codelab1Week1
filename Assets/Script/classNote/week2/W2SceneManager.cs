using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class W2SceneManager : MonoBehaviour
{
    public static float score;
    //const can't be changed 
    public const float Gravity = 1.6f;

    private int highScore;

    public int HighScore
    {
        get
        {
            return highScore;
        }
        set
        {
            highScore = value;
        }
    }

    public static float circleSpeed = -0.5f;

    private static W2SceneManager instance;
    public static W2SceneManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            //if instance is not nothing --> have we already set what gamemanager is?
            Destroy(this);
        }else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        //DontDestroyOnLoad(gameObject);
        HighScore = 10;
        Debug.Log(highScore);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Week2_Class");
        }
    }
}
