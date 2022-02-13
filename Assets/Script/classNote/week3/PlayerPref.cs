using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPref : MonoBehaviour
{
    const string SOUND_VOL_KEY = "soundVolKey";

    private int soundVolume;

    public int SoundVolume
    {
        //for if other scripts will need to see the soundVolume
        get
        {
            soundVolume = PlayerPrefs.GetInt(SOUND_VOL_KEY, 20);
            return soundVolume;
        }
        //for if other scripts will need to change the soundVolume
        set
        {
            soundVolume = value;
            PlayerPrefs.SetInt(SOUND_VOL_KEY, soundVolume);
        }
    }

    void Start()
    {
        PlayerPrefs.SetInt("testKey", 2);
        Debug.Log(PlayerPrefs.GetInt("testKey", 5));

        Debug.Log(PlayerPrefs.GetInt("anotherKeyGoesHere"));

        SoundVolume = 3;
        SoundVolume = PlayerPrefs.GetInt(SOUND_VOL_KEY, 20);
    }

    void Update()
    {
        
    }
}
