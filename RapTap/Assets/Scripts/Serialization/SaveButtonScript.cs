using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButtonScript : MonoBehaviour
{
    public Clickable click;
    public void SaveFile()
    {
        SaveSystem.SaveGame(click);
    }

    public void LoadFile()
    {
        SaveData saveData = SaveSystem.LoadGame();

        click.setClick(saveData.click);
        click.setScore(saveData.score);
    }
}
