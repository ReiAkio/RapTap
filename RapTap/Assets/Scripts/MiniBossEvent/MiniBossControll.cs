using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;

public class MiniBossControll : MonoBehaviour
{

    public int maxHype = 100;
    public int currentHype;

    public MiniBossClickable hypeBar;

    void Start()
    {
        currentHype = 0;
        hypeBar.SetMaxHype(maxHype);
    }

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GetHype(10);
        }
    }


    void GetHype(int hypepoints) 
    {
        currentHype += hypepoints;
        hypeBar.SetHype(currentHype);
    }
}




