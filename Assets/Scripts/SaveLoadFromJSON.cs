using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveLoadFromJSON 
{
    private static List<ObjectDataItem> _data = new List<ObjectDataItem>();
    public static void RemoveData()
    {
        _data.Clear();
    }
    public static void SaveObject(ObjectDataItem dataItem)
    {
        _data.Add(dataItem);
    }
    public static void SaveInJSON()
    {

        ObjectsSave objectsSave = new ObjectsSave { Objects = _data };
        string json = JsonUtility.ToJson(objectsSave);

        File.WriteAllText(Application.persistentDataPath + "/save.json", json);
        Debug.Log(Application.persistentDataPath);
    }
    public static List<ObjectDataItem> LoadObjectsFromJSON()
    {
        string path = Application.persistentDataPath + "/save.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            ObjectsSave data = JsonUtility.FromJson<ObjectsSave>(json);
            return data.Objects;
        }
        return new List<ObjectDataItem>() ;
    }

}
[System.Serializable]
public class ObjectDataItem 
{
    public float Alfa = 1f;
    public bool Active = true;
}
[System.Serializable]
public class ObjectsSave
{
    public List<ObjectDataItem> Objects = new List<ObjectDataItem>();
}


