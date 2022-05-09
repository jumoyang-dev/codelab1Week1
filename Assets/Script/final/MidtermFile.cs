using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MidtermFile : DoubleClick
{
    public string sceneName;
    void Update()
    {
        Clicking();
    }

    public override void OnMouseDown()
    {
        base.OnMouseDown();
        if (clickTimes >= 2)
        {
            clickTimes = 0;
            //double click event goes here
            //load midterm scene
            SceneManager.LoadScene(sceneName);

        }
    }
}
