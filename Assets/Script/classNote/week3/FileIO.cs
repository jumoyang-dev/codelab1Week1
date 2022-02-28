using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileIO : MonoBehaviour
{
    const string FILE_NAME = "Week3Save.txt";
    string content;

    const char DELIMITER = '|';

    string playerName = "Jumo";
    int score = 10;
    string country = "US";

    const char COUNTRY_DELIMITER = '$';

    void Start()
    {
        StreamWriter writeToFile = new StreamWriter(FILE_NAME, false);
        writeToFile.Write(playerName + DELIMITER + score + COUNTRY_DELIMITER + country);
        writeToFile.Close();

        StreamReader readeFromFile = new StreamReader(FILE_NAME);
        content = readeFromFile.ReadLine();

        //QUESTION START
        char[] delimiterChars = {'|','$'};
        string[] scoreSplit = content.Split(delimiterChars);
        //QUESTION END

        //determine 单数是名字双数是分数
        for(int i = 0; i<scoreSplit.Length; i++)
        {
            // % is 余数
            if(i%2 == 0 )
            {
                Debug.Log("is a name");
            }else
            {
                Debug.Log("is a score");
            }
        }
        //calculate sum of highscore
        int highScore = int.Parse(scoreSplit[1]);
        int allHighScores = 100 + highScore;

        print(allHighScores);

        Debug.Log("name: " + scoreSplit[0]);
        Debug.Log("score: " + scoreSplit[1]);

        readeFromFile.Close();
    }


    void Update()
    {
        print(content);
    }
}
