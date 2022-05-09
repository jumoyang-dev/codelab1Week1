using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager_final : MonoBehaviour
{
    //is using hammer or not
    public static bool isHammer;

    //singleton
    private static SceneManager_final instance;
    private GameObject[] cracks;
    public static SceneManager_final GetInstance()
    {
        return instance;
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("main");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void TotalReload()
    {
        SceneManager.LoadScene("main");
        cracks = GameObject.FindGameObjectsWithTag("Crack");
        foreach (GameObject crack in cracks)
        {
            GameObject.Destroy(crack);
        }
    }
}
