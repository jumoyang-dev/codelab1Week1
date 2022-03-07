using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotState : MonoBehaviour
{
    private Text potText;

    PotGameManager myManager;

    public enum State
    {
        Start,
        //when water or sun is > 2 
        GrowStart,
        //when water and sun both = 5
        BalanceMid,
        //when water and sun both = 10
        BalanceEnd,
        //when water >= 5 < 10 and sun is <5
        WaterMid,
        //when water >= 10 and sun is <10
        WaterEnd,
        //when sun >= 5 < 10 and water is <5
        SunMid,
        //when sun >= 10 and water is <10
        SunEnd
    }

    State currentState;

    

    void Start()
    {
        //get a refernece to the text component and set the initial description
        potText = gameObject.GetComponent<Text>();
        potText.text = "Nothing is coming out of the soil yet.";
        //get instance of gameManager
        myManager = PotGameManager.GetInstance();
    }

    void Update()
    {
        //print(currentState);

        //set local variable the same as the Static variable to avoid too much words
        int potSun = PotGameManager.sunLevel;
        int potWater = PotGameManager.waterLevel;
        int midNum = PotGameManager.MID_LEVEL;
        int endNum = PotGameManager.END_LEVEL;

        //switch to growStart
        if (potSun >= 1 && potSun < midNum && potWater >= 1 && potWater < midNum)
        {
            TransitionState(State.GrowStart);
        }
        //switch to balance mid
        else if (potSun == midNum && potWater == midNum)
        {
            TransitionState(State.BalanceMid);
        }
        //switch to balance end
        else if (potSun == endNum && potWater == endNum)
        {
            TransitionState(State.BalanceEnd);
        }
        //switch to sunmid
        else if (potSun > midNum && potSun < endNum && potWater < midNum)
        {
            TransitionState(State.SunMid);
        }
        //switch to sunEnd
        else if (potSun > endNum && potWater < endNum)
        {
            TransitionState(State.SunEnd);
        }
        //switch to waterMid
        else if (potWater > midNum && potWater < endNum && potSun < midNum)
        {
            TransitionState(State.WaterMid);
        }
        //switch to waterEnd
        else if (potWater > endNum && potSun < endNum)
        {
            TransitionState(State.WaterEnd);
        }


    }
    // change the text in different state
    void TransitionState (State newState )
    {
        currentState = newState;
        switch(newState)
        {
            case State.Start:
                potText.text = "Nothing is coming out of the soil yet.";
                break;
            case State.GrowStart:
                potText.text = "Awesome, you see something sprouting out! Something...green, no matter, It's a plant!";
                break;
            case State.BalanceMid:
                potText.text = "Good job to you! your plant is growing in a perfect balanced environment, It squeezes out a tiny sound 'Thank you~'. Thank you indeed!";
                break;
            case State.BalanceEnd:
                potText.text = "The growth is completed. Your plant walks out of the pot, shrugs off the dirt. It almost reaches the ceiling, it gives you a bow, and walks away with its roots.(END)";
                break;
            case State.WaterMid:
                potText.text = "Your plant absorbs all the water, a deep rippling voice says 'water me more.'";
                break;
            case State.WaterEnd:
                potText.text = "You keep watering your plant, even the floor is flooded, it always wants more water, you are always bringing more water. You can hear its voice everywhere, rippling in the room 'Water Me More'. Yes you will (END)";
                break;
            case State.SunMid:
                potText.text = "A little Too much sun, but it's fine, your plant loves sun. It grows into a sunflower...looking thing! Each of its seed is saying 'Thank you~', but they sound a asynchronous.";
                break;
            case State.SunEnd:
                potText.text = "It gets warmer and warmer, giving out its own light. You have your little sun now! The pot is becoming light too; the floor is becoming light too; you are becoming light too. (END)";
                break;
        }
    }
}
