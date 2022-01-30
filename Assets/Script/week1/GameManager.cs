using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //display when both player arrive in zone
    public GameObject winText;
    //for player scripts to refer
    public bool cubeIn, ballIn;

    void Start()
    {
        winText.SetActive(false);
    }

    
    void Update()
    {
        //if both player got in, display win text
        if (ballIn && cubeIn)
        {
            winText.SetActive(true);
        }
        //reload the scene 
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
