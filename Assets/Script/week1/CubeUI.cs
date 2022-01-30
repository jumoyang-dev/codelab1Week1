using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeUI : MonoBehaviour
{
    public Slider cubeSlider;
   
    //to help set slider value 
    public void SetSlider(float time)
    {
        cubeSlider.value = time;
    }
    //to help set max time from CubeController script
    public void SetMaxTime (float time)
    {
        cubeSlider.maxValue = time;
        cubeSlider.value = time;
    }
}
