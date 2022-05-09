using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleClick : MonoBehaviour
{
    public int clickTimes;
    public float resetTimer = 0.5f;
    public bool canDrag;
   
    void Update()
    {
        Clicking();
    }
    public virtual void OnMouseDown()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            clickTimes++;
            Debug.Log(clickTimes);
        }
    }
    //follow the mouse when dragging
    public virtual void OnMouseDrag()
    {
        if (!canDrag)
        {
            return;
        }
        transform.position = mousePos();
    }
    //reset the click Times after certain time if only a single click is received 
    public virtual void Clicking()
    {
        if (clickTimes == 1)
        {
            resetTimer -= Time.deltaTime;
        }
        if (resetTimer <= 0)
        {
            clickTimes = 0;
            resetTimer = 0.5f;
        }
        //Debug.Log(resetTimer);
    }
    //get the mouse position and set Z to 0
    public virtual Vector3 mousePos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
