using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ASCIILevelLoader : MonoBehaviour
{

    public string fileName;
    public float xOffset, yOffset;


    void Start()
    {
        StreamReader reader = new StreamReader(fileName);
        string contenOfFile = reader.ReadToEnd(); // read the whole entire thing
        reader.Close();

        //print(contenOfFile);

        char[] newLineChar = { '\n' };//line break
        //split whenever there is a new line 
        string[] level = contenOfFile.Split(newLineChar);

        for (int i = 0; i < level.Length; i++)
        {
            MakeRow(level[i], -i);
        }

    }
    void Update()
    {
        
    }

    void MakeRow(string rowString, float y)
    {
        //char c = contenOfFile[i];

        //if (c == 'X')
        //{
        //string can be treated as array 
        char[] rowArray = rowString.ToCharArray();
        for (int x = 0; x < rowString.Length; x++)
        {
            char c = rowArray[x];
            if (c == 'X')
            {
                Debug.Log("make a cube");
                GameObject brick = Instantiate(Resources.Load("Brick")) as GameObject;
                brick.transform.position = new Vector3
                    (
                        x * brick.transform.localScale.x + xOffset,
                        y * brick.transform.localScale.y + yOffset,
                        0
                    );
            }
            else if (c == 'C')
            {
                GameObject tube = Instantiate(Resources.Load("Tube")) as GameObject;
                tube.transform.position = new Vector3
                (
                    x * tube.transform.localScale.x + xOffset,
                    y * tube.transform.localScale.y + yOffset,
                    0
                );
            }else if (c == '0')
            {
                GameObject npc = Instantiate(Resources.Load("NPC")) as GameObject;
                npc.transform.position = new Vector3
                (
                    x*npc.transform.localScale.x + xOffset,
                    y*npc.transform.localScale.y +yOffset,
                    0
                );
            }
        }
        //}
    }
}
