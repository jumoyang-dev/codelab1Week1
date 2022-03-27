using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W8SquareScript : MonoBehaviour, IClickable
{
    public SpriteRenderer myRenderer;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnClick ()
    {
        myRenderer.color = new Color(0,0,0,0);
    }
}
