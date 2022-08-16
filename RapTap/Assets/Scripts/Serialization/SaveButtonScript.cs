using System.IO;
using System.Collections;
using UnityEngine;

public class SaveButtonScript : MonoBehaviour
{
    public Clickable click;
    public InventorySerialization inv;
    public MiniBossEvent.MainLl mainLl;
    public Tutorial tutorial;
    public void Awake()
    {
        if (File.Exists(Application.persistentDataPath + "/savedata.save"))
        {
            SaveData saveData = SaveSystem.LoadGame();
            tutorial.tutorialIsDone = saveData.tutorialIsDone;
            if (saveData.tutorialIsDone)
            {
                click.setClick(saveData.click);
                click.setScore(saveData.score);
                int i = 0;
                inv.activeVisual = saveData.activeVisual;
                foreach (bool item in saveData.visualItems)
                {
                    inv.visualItems[i] = item;
                    i++;
                }
                i = 0;
                foreach (bool item in saveData.buffItems)
                {
                    inv.buffItems[i] = item;
                    i++;
                }
                mainLl.countEventAlreadyHappen = saveData.countEventAlreadyHappen;
            }
        }
    }

    public void OnClick()
    {
        SaveSystem.SaveGame(click, inv, mainLl, tutorial);
    }
}