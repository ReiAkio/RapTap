using System.IO;
using UnityEngine;

public class SaveButtonScript : MonoBehaviour
{
    public Clickable click;
    public void Awake()
    {
        if (File.Exists(Application.persistentDataPath + "/savedata.save"))
        {
            SaveData saveData = SaveSystem.LoadGame();
            click.setClick(saveData.click);
            click.setScore(saveData.score);
        }
    }

    public void OnClick()
    {
        SaveSystem.SaveGame(click);
    }
}
