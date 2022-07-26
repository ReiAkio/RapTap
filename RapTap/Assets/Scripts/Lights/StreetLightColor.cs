using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class StreetLightColor : MonoBehaviour
{
    [SerializeField] private Light2D streetLightComp;
    private Color[] colors = {
        new Color32(192,137,240,255),
        new Color32(192, 137, 240,255),
        new Color32(118,204,253,255),
        new Color32(221,93,255,255),
        new Color32(212,243,98,255),
        new Color32(153,255,255,255),
        new Color32(255,255,153,255),
        new Color32(253,215,109,255),
        new Color32(255,90,144,255)};

    /*
    Color 0: C089F0 rgb(192,137,240)
    Color 1: FF86FF rgb(192,137,240)
    Color 2: 76CCFD rgb(118,204,253)
    Color 3: DD5DFF rgb(221,93,255)
    Color 4: D4F362 rgb(212,243,98)
    Color 5: 99FFFF rgb(153,255,255)
    Color 6: FFFF99 rgb(255,255,153)
    Color 7: FDD76D rgb(253,215,109)
    Color 8: FF5A90 rgb(255,90,144)
     */


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void Change_Color(int colNum)
    {
        streetLightComp.color = colors[colNum];
    }
}
