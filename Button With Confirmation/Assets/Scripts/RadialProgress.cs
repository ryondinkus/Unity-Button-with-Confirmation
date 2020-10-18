using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//This is for the Radial Progress Bar that appears on buttons with confirmation timers
public class RadialProgress : MonoBehaviour
{
    public Image LoadingBar; //The LoadingBar image which is a part of the CircularProgress prefab
    public bool isPressed = false;

    float timer = 0; //this timer counts frames
    float maxValue = 0; //maxValue and seconds are both counted as seconds
    float seconds = 0;
    float lerpTime = 0; //lerptime relates to the percentage blend when switching between two colors
    UnityEvent myUnityEvent; //This event handler should be used instead of the one in the Button Component.
    Color color1;
    Color color2;

	void Update()
    {
        
        if (isPressed) //isPressed is triggered by the ButtonConfirmation Component.
        {
            if (seconds < maxValue)
            {
                timer += Time.deltaTime;
                seconds = timer % (1.0f / Time.deltaTime); //converts frame count to seconds based on framerate
            }
            if (seconds >= maxValue)
            {
                isPressed = false;
                timer = 0;
                myUnityEvent.Invoke();
            }
        }
        else
        {
            if (seconds > 0)
            {
                timer -= Time.deltaTime * 4; //deplete timer at a faster rate if not being held
                seconds = timer % (1.0f / Time.deltaTime);
            }
            if (seconds <= 0)
            {
                Destroy(GameObject.FindGameObjectWithTag("ProgressBarButton")); //destroy CircularProgressBar if empty
            }
        }
        LoadingBar.fillAmount = seconds / maxValue;

        if (seconds >= maxValue * 0.75) //Color blend amount stuff
        {
            lerpTime += Time.deltaTime * (3/maxValue);
            LoadingBar.color = Color.Lerp(color1, color2, lerpTime);
        }
        else if (!isPressed)
        //Tried to make it so color is proportional to the fill amount, works pretty consistently, but the (3/maxValue) may need some adjusting depending on how long you want the fill time to be.
        //Feel free to mess with the values until you get a satisfactory result.
        {
            lerpTime -= Time.deltaTime * (3/maxValue);
            LoadingBar.color = Color.Lerp(color1, color2, lerpTime);
        }

    }
    //Getters and setters for various params to be accessed by ButtonConfirmation
    public UnityEvent getEvent()
    {
        return myUnityEvent;
    }

    public void setEvent(UnityEvent thisEvent)
    {
        myUnityEvent = thisEvent;
    }

    public Color getColor1()
    {
        return color1;
    }

    public void setColor1(Color clr)
    {
        color1 = clr;
        LoadingBar.color = color1;
    }
    public Color getColor2()
    {
        return color2;
    }

    public void setColor2(Color clr)
    {
        color2 = clr;
    }

    public float getSeconds()
    {
        return maxValue;
    }
    public void setSeconds(float sec)
    {
        maxValue = sec;
    }
}
