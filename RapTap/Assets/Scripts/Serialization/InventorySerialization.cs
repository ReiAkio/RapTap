using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySerialization : MonoBehaviour
{
    public bool[] visualItems;
    public bool[] buffItems;
    public int activeVisual;

    public void SetActive(int id)
    {
        activeVisual = id;
    }
    public void OnBuyBuff(int id, bool isBought)
    {
        buffItems[id] = isBought;
    }
    public void OnBuyVisual(int id, bool isBought)
    {
        visualItems[id] = isBought;
    }
}