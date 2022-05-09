using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PasswordInput : MonoBehaviour
{
    public TMP_InputField password;
    public GameObject imagePrefab;
    private GameObject image;

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnMouseDown()
    {
        if (password.text == "frogking")
        {
            if (image == null)
            {
                image = (GameObject)Instantiate(imagePrefab, Vector3.zero, Quaternion.identity);
            }
        }
    }

}
