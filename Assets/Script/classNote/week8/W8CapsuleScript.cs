using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W8CapsuleScript : MonoBehaviour, IClickable
{
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void OnClick()
    {
        transform.localScale = new Vector3(2f, 2f, 0);
    }
}
