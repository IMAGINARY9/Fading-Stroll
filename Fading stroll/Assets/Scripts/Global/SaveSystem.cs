using System.Collections;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void SaveData(DataHolder data)
    {
        string path = Application.persistentDataPath + "/gamedata.fun";
        BinaryFormatter formatter = new();
        FileStream stream = new(path, FileMode.Create);

        ProgressData pdata = new(data);

        formatter.Serialize(stream, pdata);
        stream.Close();
    }

    public static ProgressData LoadData()
    {
        string path = Application.persistentDataPath + "/gamedata.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new();
            FileStream stream = new(path, FileMode.Open);
            if (stream.Length == 0)
            {
                stream.Close();
                return null;
            }
            ProgressData data = formatter.Deserialize(stream) as ProgressData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }

}
