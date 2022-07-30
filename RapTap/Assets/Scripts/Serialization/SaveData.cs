using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int score;
    public int click;
    public int activeVisual;
    public bool[] visualItems;
    public bool[] buffItems;
    public int countEventAlreadyHappen;



    public SaveData(Clickable clickData, InventorySerialization inv, MiniBossEvent.MainLl mainLl)
    {
        countEventAlreadyHappen = mainLl.countEventAlreadyHappen;
        score = clickData.getScore();
        click = clickData.getClick();
        activeVisual = inv.activeVisual;
        visualItems = inv.visualItems;
        buffItems = inv.buffItems;
    }
}