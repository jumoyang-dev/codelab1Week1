using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsKey : MonoBehaviour
{
    public GameObject windowsPage;
    private void OnMouseDown()
    {
        if (!windowsPage.activeSelf)
        {
            windowsPage.SetActive(true);
        }else
        {
            windowsPage.SetActive(false);
        }
        
    }
}
