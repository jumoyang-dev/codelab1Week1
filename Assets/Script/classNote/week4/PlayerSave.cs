using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerSave : MonoBehaviour
{
    public string fileName;
    const char delimiter = '|';
    void Start()
    {
        StreamReader reader = new StreamReader(fileName);
        string newPos = reader.ReadLine();
        reader.Close();
        Debug.Log(newPos);

        //QUESTION
        //why here needs to be an array 
        string[] pos = newPos.Split(new char[] { delimiter });
        transform.position = new Vector3(float.Parse(pos[0]), float.Parse(pos[1]), float.Parse(pos[2]));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StreamWriter writer = new StreamWriter(fileName);
            //QUESTION 
            //why it has "" at the beginning ?
            writer.Write("" + transform.position.x + delimiter + transform.position.y + delimiter + transform.position.z);
            writer.Close();
        }
    }
}
