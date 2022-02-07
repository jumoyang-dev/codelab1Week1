using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerW2 : MonoBehaviour
{
    //display slider for the cube
    public Slider cubeSlider;
    //display when both player arrive in zone
    public Text winText;
    //displayer timer
    public Text timer;
    //to help set slider value 
    void Start()
    {
        winText.enabled = false;
    }
    private void Update()
    {
        //start the timer when the scene loaded
        timer.text = "Time Spend: " + UtilitiesW2.CountTotalTime();

        //get the public static bool from GameManager
        //if both player got in, display win text
        if (GameManagerW2.ballIn && GameManagerW2.cubeIn)
        {
            winText.enabled = true;
        }
    }
    public void SetSlider(float time)
    {
        cubeSlider.value = time;
    }
    //to help set max time from CubeController script
    public void SetMaxTime(float time)
    {
        cubeSlider.maxValue = time;
        cubeSlider.value = time;
    }
}
