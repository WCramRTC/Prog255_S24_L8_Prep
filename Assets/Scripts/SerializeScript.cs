using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;

public class SerializeScript : MonoBehaviour
{
    // Start is called before the first frame update
    TMP_Text display;

    void Start()
    {
        UIManager ui = FindFirstObjectByType<UIManager>();
        display = ui.serializable; 
        display.text = "Serial From File";

        PlayerData pd = new PlayerData() {
            name = "Raina", 
            health = 60, 
            status = PlayerData.STATUS.Sleepy};

        // Saving Data
        // SaveData(pd);
        PlayerData pdLoad = LoadData();
        if(pdLoad != null) {
            display.text = pdLoad.Display();
        }
        else {
            display.text = "File Not Found";
        }

        // Can you hear me? My computers been acting up recently


    }

    public void SaveData(PlayerData data) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/serializableData.bin";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public PlayerData LoadData() {
        string path = Application.persistentDataPath + "/serializableData.bin";

        if(File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;

        }

        return null;
    }
}

/*

### 4. **Binary Serialization**
For more complex data structures or when you need better performance and smaller file sizes, you can use binary serialization.

```csharp
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public int health;
}

public class SaveSystem : MonoBehaviour
{
    public void SaveData(PlayerData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerData.bin";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public PlayerData LoadData()
    {
        string path = Application.persistentDataPath + "/playerData.bin";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        return null;
    }
}
```

 */