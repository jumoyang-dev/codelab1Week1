using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileIO : MonoBehaviour
{
    const string FILE_NAME = "Week3Save.txt";
    void Start()
    {
        StreamWriter writeToFile = new StreamWriter(FILE_NAME, false);
        writeToFile.Write("hello i just wrote to this text file yeah!");
        writeToFile.Close();

        StreamReader readeFromFile = new StreamReader(FILE_NAME);
        string cotent = readeFromFile.ReadLine();
        Debug.Log(cotent);
        readeFromFile.Close();
    }


    void Update()
    {
        
    }
}
