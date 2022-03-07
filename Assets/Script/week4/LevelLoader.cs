using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelLoader : MonoBehaviour
{
    //name of the file
    public string filename;

    //use a Vector2 for the offset
    public Vector2 offset;

    void Start()
    {
        //open file
        StreamReader reader = new StreamReader(filename);
        string contentOfFile = reader.ReadToEnd();//read the whole file
        reader.Close();//close file

        //Debug.Log(contentOfFile);
        char newLineChar = '\n' ; //check for line break char
        string[] level = contentOfFile.Split(newLineChar);  //split whenever there is a new line
        
        for (int i = 0; i < level.Length; i ++)
        {
            MakeRow(level[i], -i);
        }
    }
    void MakeRow(string rowString, float y)
    {
        //turn the row of string into array of chars
        char[] rowArray = rowString.ToCharArray();
        //loop based on how many chars in a row
        for (int x = 0; x < rowString.Length; x++)
        {
            print(x);
            //questions:
                //1. why it needs to times 2
                //2. the "as GameObject" is casting from Object to GameObject? if is casting whats the difference between Gameobject A = (GameObject) instantiate(xxx)
                //3. is there a way to simplify the long else if statement?
            //question end.

            //c as the current char
            char c = rowArray[x];
            if (c == '-')
            {
                GameObject white = Instantiate(Resources.Load("white")) as GameObject;
                // set pos
                white.transform.position = new Vector3(x * 2 * white.transform.localScale.x + offset.x , y * 2 * white.transform.localScale.y + offset.y, 0); ;
            }else if (c == 'O')
            {
                GameObject eye = Instantiate(Resources.Load("eye")) as GameObject;
                eye.transform.position = new Vector3(x * 2 * eye.transform.localScale.x + offset.x, y * 2 * eye.transform.localScale.y + offset.y, 0); ;
            }
            else if (c == 'L')
            {
                GameObject nose = Instantiate(Resources.Load("nose")) as GameObject;
                nose.transform.position = new Vector3(x * 2 * nose.transform.localScale.x + offset.x, y * 2 * nose.transform.localScale.y + offset.y, 0); ;
            }
            else if (c == '=')
            {
                GameObject mouth = Instantiate(Resources.Load("mouth")) as GameObject;
                mouth.transform.position = new Vector3(x * 2 * mouth.transform.localScale.x + offset.x, y * 2 * mouth.transform.localScale.y + offset.y, 0); ;
            }
            else if (c == 'M')
            {
                GameObject hair = Instantiate(Resources.Load("hair")) as GameObject;
                hair.transform.position = new Vector3(x * 2 * hair.transform.localScale.x + offset.x, y * 2 * hair.transform.localScale.y + offset.y, 0); ;
            }
            else if (c == '(')
            {
                GameObject leftEar = Instantiate(Resources.Load("leftEar")) as GameObject;
                leftEar.transform.position = new Vector3(x * 2 * leftEar.transform.localScale.x + offset.x, y * 2 * leftEar.transform.localScale.y + offset.y, 0); ;
            }
            else if (c == ')')
            {
                GameObject rightEar = Instantiate(Resources.Load("rightEar")) as GameObject;
                rightEar.transform.position = new Vector3(x * 2 * rightEar.transform.localScale.x + offset.x, y * 2 * rightEar.transform.localScale.y + offset.y, 0); ;
            }
            else if (c == '|')
            {
                GameObject edge = Instantiate(Resources.Load("edge")) as GameObject;
                edge.transform.position = new Vector3(x * 2 * edge.transform.localScale.x + offset.x, y * 2 * edge.transform.localScale.y + offset.y, 0); ;
            }
        }
    }
}
