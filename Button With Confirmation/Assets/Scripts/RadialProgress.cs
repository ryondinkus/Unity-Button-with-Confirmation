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
    public Image LoadingBar;
    public bool isPressed = false;

    float timer = 0;
    float maxValue = 0;
    float seconds = 0;
    float lerpTime = 0;
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
                seconds = timer % 60;
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
                timer -= Time.deltaTime * 4;
                seconds = timer % 60;
            }
            if (seconds <= 0)
            {
                Destroy(GameObject.FindGameObjectWithTag("ProgressBarButton"));
            }
        }
        LoadingBar.fillAmount = seconds / maxValue;

        if (seconds >= maxValue * 0.75)
        {
            lerpTime += Time.deltaTime * (3/maxValue);
            LoadingBar.color = Color.Lerp(color1, color2, lerpTime);
        }
        else if (!isPressed)
        {
            lerpTime -= Time.deltaTime * (3/maxValue);
            LoadingBar.color = Color.Lerp(color1, color2, lerpTime);
        }

    }

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
