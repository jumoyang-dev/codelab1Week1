using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilitiesW2 : MonoBehaviour
{
   
    public static float totalTimeSpent;
     //track and display how long player spend playing this game
    public static float CountTotalTime ()
    {
        //time will count until until both player get to the right side
        if (!GameManagerW2.ballIn || !GameManagerW2.cubeIn)
        {
            totalTimeSpent += Time.deltaTime;
        }
        //round the number to 1 decimal place and return
        return Mathf.Round(totalTimeSpent*10f)/10f;
    }

}
