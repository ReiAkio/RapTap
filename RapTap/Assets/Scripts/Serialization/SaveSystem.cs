using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public static class SaveSystem
{
    public static void SaveGame(Clickable clickData, InventorySerialization inv)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/savedata.save";
        FileStream stream = new FileStream(path, FileMode.Create);
        SaveData saveData = new SaveData(clickData, inv);
        formatter.Serialize(stream, saveData);
        stream.Close();
    }
    
    public static SaveData LoadGame()
    {
        string path = Application.persistentDataPath + "/savedata.save";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);
        SaveData savedata = formatter.Deserialize(stream) as SaveData;
        stream.Close();
        return savedata;
    }
}
