using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveFile : MonoBehaviour
{
    //naming save file
    const string FILE_NAME = "mySave.txt";
    private float currentHighScore;
    void Start()
    {

    }

    //call this streamwrite function in UIManager Script when both players complete the level
    public void SaveScore()
    {
        
        //write to file only if currentHighScore is 0 OR the New Score is smaller than the previous High Score
        if (currentHighScore == 0 || UtilitiesW2.totalTimeSpent < currentHighScore)
        {
            StreamWriter writer = new StreamWriter(FILE_NAME, false);
            currentHighScore = Mathf.Round(UtilitiesW2.totalTimeSpent*10f)/10f;
            writer.WriteLine(currentHighScore);
            writer.Close();
        }
    }
    // call this function in UIManager Script to set the score UI
    public string ReadScore()
    {
        string scoreString;
        StreamReader reader = new StreamReader(FILE_NAME);
        scoreString = reader.ReadLine();
        reader.Close();
        return scoreString;
    }
}
