using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W8CircleScript : MonoBehaviour, IClickable
{
    public string dialogLine;
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    public void OnClick()
    {
        print(dialogLine);
    }
}
