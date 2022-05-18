using System.IO;
using System.Collections;
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
        StartCoroutine(TimedSave());
    }

    //public void OnClick()
    //{
    //    SaveSystem.SaveGame(click);
    //}

    public IEnumerator TimedSave()
    {
        SaveSystem.SaveGame(click);
        yield return new WaitForSeconds(10f);
        StartCoroutine(TimedSave());
    }
}
