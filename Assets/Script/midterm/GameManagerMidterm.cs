using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerMidterm : MonoBehaviour
{
    //create a list to hold Character GameObject that we are going to spawn
    public List<GameObject> spawnedObject = new List<GameObject>();
    public int currentSpawnNum;

    //setting the boundary for the patrol 
    public Vector2 minRange, maxRange;

    //singleton goes here
    private static GameManagerMidterm instance;
    public static GameManagerMidterm GetInstance()
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
        void Start()
    {
        //when the game start, instantiate a Character Prefab on the right screen pos

        //add to the list
        spawnedObject.Add(Instantiate(Resources.Load("character")) as GameObject);
        spawnedObject[0].transform.position = new Vector3(100f, 100f, 0);
        currentSpawnNum = 0;
    }

    public void SpawnPotato()
    {
        //use for the buttom click
        //teleport the potato from the right to the left screen pos
        spawnedObject[currentSpawnNum].transform.position = new Vector3(0, 0, 0);
        //enable startIdle animator bool
        Animator objAnimator = spawnedObject[currentSpawnNum].GetComponent<Animator>();
        objAnimator.SetBool("startIdle", true);
        //instantiate a new spawnedObject on the right screen pos
        spawnedObject.Add(Instantiate(Resources.Load("character")) as GameObject);
        spawnedObject[currentSpawnNum + 1].transform.position = new Vector3(100f, 100f, 0);
        //increase spawn number by 1
        currentSpawnNum++;
    }
}
