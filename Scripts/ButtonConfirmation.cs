using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//This is the script used for buttons with confirmation timers that need to be held down. It's meant to be used alongside the Button Component, but the
//Event Handler of the Button Component should be left empty in favor of this one.
// IMPORTANT IF USING VRTK: The ProgressBar will not fill if the UIPointer component of the ControllerSciptAliases has Click Method set to "Click on Button Down." Keep it set to "Button Up." 
public class ButtonConfirmation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    public GameObject ProgressBar; //See CircularProgress prefab
    public Color Color1;
    public Color Color2;
    public float seconds;
    public UnityEvent myUnityEvent; //This event handler should be used for onClick() instead of the Button Component

    GameObject CurrentProgressBar;
    RadialProgress RadialProgressBar; //The RadialProgress.cs component of the instantiated ProgressBar

	public void OnPointerDown(PointerEventData eventData) //OnPointerDown and OnPointerUp check if the button is being pressed or released
    {
        if (GetComponent<Button>().interactable) //This prevents certain buttons from being pressed while deactivated 
        {
            if (GameObject.FindGameObjectWithTag("ProgressBarButton") == null)
            {
                CurrentProgressBar = Instantiate(ProgressBar, transform.position, transform.rotation, transform.parent);
                RadialProgressBar = CurrentProgressBar.GetComponent<RadialProgress>();
                RadialProgressBar.setEvent(myUnityEvent); //This takes the event, colors, and seconds params and gives it to the RadialProgress component of the ProgressBar
                RadialProgressBar.setColor1(Color1);
                RadialProgressBar.setColor2(Color2);
                RadialProgressBar.setSeconds(seconds);
            }69
            RadialProgressBar.isPressed = true; //Sets the button's status to pressed, see RadialProgress.cs
        }
    }

    public void OnPointerUp(PointerEventData eventData) //If button is released or pointer goes outside button, deplete ProgressBar
    {
        RadialProgressBar.isPressed = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        RadialProgressBar.isPressed = false;
    }
}
