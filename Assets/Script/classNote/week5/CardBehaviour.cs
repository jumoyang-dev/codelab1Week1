using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBehaviour : MonoBehaviour
{
    public SpriteRenderer myRenderer;
    public Color faceColor;
    public Color backColor;

    W5Manager myManager;

    public enum State //making my own data type called state 
    {
        FaceUp,
        FaceDown
    }

    State currentState;

    void Start()
    {
        myManager = W5Manager.GetInstance();
        TransitionState(State.FaceDown);
    }

    void Update()
    {
        /*
        switch (currentState)        //cleaner than using if/else statement but functionally doing the same 
        {
            case State.FaceDown:
                myRenderer.color = backColor;
                break;
            case State.FaceUp:
                myRenderer.color = faceColor;
                break;
        }
        */
    }
    
    private void OnMouseDown()
    {
        print(myManager.currentState);

        if (myManager.currentState == W5Manager.State.select)
        {
            if (currentState == State.FaceDown)
            {
                //currentState = State.FaceUp;
                TransitionState(State.FaceUp);
                myManager.TransitionStates(W5Manager.State.CardChosen);
            }
            else if (currentState == State.FaceUp)
            {
                //currentState = State.FaceDown;
                TransitionState(State.FaceDown);
            }
        }
        
    }
    void TransitionState(State newState)
    {
        currentState = newState;
        switch (newState)
        {
            case State.FaceDown:
                myRenderer.color = backColor;
                break;
            case State.FaceUp:
                myRenderer.color = faceColor;
                break;
            default: //if state isn't faceUp or faceDown, it's default into default
                Debug.Log("no transition for this state");
                break;
        }
    }
}
