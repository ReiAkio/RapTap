using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MiniBossClickable : MonoBehaviour
{
    public delegate void ClickAction();

    public static event ClickAction MouseDown;
    public static event ClickAction MouseUp;

    public Slider slider;
    

    public void SetMaxHype(int hype)
    {
        slider.maxValue = hype;
        slider.value = 0;
    }
    
    public void SetHype(int hype)
    {
        slider.value = hype;
    }

    
    public void OnPointerDown(PointerEventData eventData)
    {
        // Botão Abaixou

        if(MouseDown != null)
        {
            MouseDown();
        }

    }

    
    public void OnPointerUp(PointerEventData eventData)
    {
        // Botão levantou

        if (MouseUp != null)
        {
            MouseUp();
        }
     
    }
}
