using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotGameManager : MonoBehaviour
{
    //create int for water and sun level
    public static int waterLevel;
    public static int sunLevel;

    //number for the middle level and end level
    public const int MID_LEVEL = 5;
    public const int END_LEVEL = 10;

    //setup Singleton
    private static PotGameManager instance;

    public static PotGameManager GetInstance()
    {
        return instance;
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        
    }
    void Update()
    {
       //print("water: " + waterLevel);
       //print("sun: " + sunLevel);
    }

    //function for addinng water and sun when clicking the buttons
    public void AddWater()
    {
        waterLevel++;     
    }
    public void AddSun()
    {
        sunLevel++;
    }

}
