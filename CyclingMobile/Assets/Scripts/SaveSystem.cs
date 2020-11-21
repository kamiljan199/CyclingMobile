using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem
{
    public static void SavePlayer(Player bc)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "s1.eo");

        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            PlayerData data = new PlayerData(bc);

            formatter.Serialize(stream, data);
        }
    }

    public static PlayerData LoadPlayer()
    {
        string path = Path.Combine(Application.persistentDataPath, "s1.eo");

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                PlayerData data = formatter.Deserialize(stream) as PlayerData;
                return data;
            }

        } else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }

}
