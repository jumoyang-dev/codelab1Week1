using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W5Manager : MonoBehaviour
{

    public int cardCount;
    public GameObject cardObj;

    public enum State
    {
        CreateCards,
        Deal,
        select,
        CardChosen,
        Resolve
    }

    public List<GameObject> deck = new List<GameObject>();

    public Vector3 handStartPos;

    public float enemyHealth;
    public Text enemyText;

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
        enemyText.text = enemyHealth.ToString();
        TransitionStates(State.CreateCards);

    }
    private void Update()
    {
        RunState();
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
                    Vector3 newPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0); 
                    //setting position
                    newCard.transform.position = newPos;
                    deck.Add(newCard);
                }
                //auto transition to select state
                TransitionStates(State.Deal);
                break;
            case State.Deal:
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

    void RunState()
    {
        switch (currentState)
        {
            case State.Deal:
                for(int i = 0; i < deck.Count; i ++)
                {
                    float step = 5.0f * Time.deltaTime;
                    Vector3 newPos = new Vector3(handStartPos.x + (i * 3), handStartPos.y, 0);
                    //use MoveTowards to move cards from spawn point to target pos 
                    deck[i].transform.position = Vector3.MoveTowards(deck[i].transform.position, newPos, step);
                    if (i == deck.Count - 1 && Vector3.Distance(deck[i].transform.position, newPos) < 0.1f)
                    {
                        TransitionStates(State.select);
                    }
                }

                break;
        }
    }

}
