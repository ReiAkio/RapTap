using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int score;
    public int click;



    public SaveData(Clickable clickData)
    {
        score = clickData.getScore();
        click = clickData.getClick();
    }
}
