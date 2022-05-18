using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public static class SaveSystem
{
    public static void SaveGame(Clickable clickData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/savedata.save";
        FileStream stream = new FileStream(path, FileMode.Create);
        SaveData saveData = new SaveData(clickData);
        formatter.Serialize(stream, saveData);
        stream.Close();
    }
    
    public static SaveData LoadGame()
    {
        string path = Application.persistentDataPath + "/savedata.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SaveData savedata = formatter.Deserialize(stream) as SaveData;
            stream.Close();
            return savedata;
        }
        else
        {
            Debug.LogError("Save nao encontrado em " + path);
            return null;
        }
    }
}