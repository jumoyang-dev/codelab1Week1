using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerW2 : MonoBehaviour
{

    //static bool for player and UIscript to refer
    public static bool cubeIn, ballIn;

    //create a singleton by setting variable 
    private static GameManagerW2 instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            //destory this component
            Destroy(this);
        }else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Update()
    {
       
        //reload the scene by pressing R if is currently not in the menu scene 
        if (Input.GetKeyDown(KeyCode.R) && SceneManager.GetActiveScene() != SceneManager.GetSceneByName("week2_Menu"))
        {
            //reload scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //only if the player complete the level, reset the timer, otherwise continue counting
            if (ballIn && cubeIn)
            {
                UtilitiesW2.totalTimeSpent = 0;
            }
            //reset the static bool when restarting the scene
            ballIn = false;
            cubeIn = false;
        }
    }
    //for start button to refer in the menu scene 
    public void StartGame()
    {
        SceneManager.LoadScene("week2_Level1");
    }

}
