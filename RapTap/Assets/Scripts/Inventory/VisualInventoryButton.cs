using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualInventoryButton : MonoBehaviour
{
    public VisualItem visualItem;
    public GameObject redPanda;
    

    public void ChangeVisualItem()
    {
        redPanda.gameObject.GetComponent<Image>().sprite = visualItem.image;
    } 
}
