using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W5Manager : MonoBehaviour
{

    public int cardCount;
    public GameObject cardObj;

    public enum State
    {
        CreateCards,
        select,
        CardChosen,
        Resolve
    }
    //public for CardBehaviour to reference 
    public State currentState;

    private static W5Manager instance;
    public static W5Manager GetInstance() //this function is for other script to reference 
    {
        return instance;
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        TransitionStates(State.CreateCards);
    }
    private void Update()
    {

    }
    public void TransitionStates(State newState)
    {
        //currentState = newState need to be in front because the script won't continue to run after break
        currentState = newState;
        switch (newState)
        {
            case State.CreateCards:
                for (int i = 0; i < cardCount; i++)
                {
                    GameObject newCard = Instantiate(cardObj);
                    //gameObject.transform.position is the GameManager object's position
                    Vector3 newPos = new Vector3(gameObject.transform.position.x + (i * 3), gameObject.transform.position.y, 0); 
                    //setting position
                    newCard.transform.position = newPos;
                }
                //auto transition to select state
                TransitionStates(State.select);
                break;
            case State.select:
                break;
            case State.CardChosen:
                break;
            case State.Resolve:
                break;
            default:
                Debug.Log("this is the default state");
                break;
        }
    }
}
