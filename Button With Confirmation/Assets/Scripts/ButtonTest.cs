using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour                          
{
    public GameObject button;
    public void HideButton()
    {                         
        button.SetActive(false);
    }
}
