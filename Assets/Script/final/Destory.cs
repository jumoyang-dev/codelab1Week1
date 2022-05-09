using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory : MonoBehaviour
{
    private void OnMouseDown()
    {
        Destroy(transform.parent.gameObject);
    }
}
