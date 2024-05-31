using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;


[System.Serializable]
public class PlayerJSONData {
    public string name;
    public int health;

    public string DisplayData() {
        return $"{name} - {health}";
    }
}

public class SaveToFileScript : MonoBehaviour
{
    // Start is called before the first frame update
    TMP_Text display;

    void Start()
    {
        UIManager ui = FindFirstObjectByType<UIManager>();
        display = ui.jsonObject;
        display.text = "Loaded from file";
        
        // PlayerJSONData pjd = new PlayerJSONData() { name = "Will", health = 125 };
        // SaveData(pjd);
        PlayerJSONData pjd = LoadData();
        display.text = pjd.DisplayData();
    }

    public void SaveData(PlayerJSONData pjd) {
        string json = JsonUtility.ToJson(pjd);
        string applicationPath = Application.persistentDataPath;
        string filePath = "/playerDataJson.json";
        File.WriteAllText(applicationPath + filePath, json);
        Debug.Log(applicationPath + filePath);
    }

    public PlayerJSONData LoadData() {
        string applicationPath = Application.persistentDataPath;
        string filePath = "/playerDataJson.json";
        string path = applicationPath + filePath;
        if(File.Exists(path)) {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<PlayerJSONData>(json);
        }

        return null;
    }
}

/* 
### 2. **Saving to a File**
For more complex data, you can save to a file using `System.IO`. You can serialize your data into JSON, XML, or a binary format.

#### JSON Example:
```csharp
using System.IO;
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
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/playerData.json", json);
    }

    public PlayerData LoadData()
    {
        string path = Application.persistentDataPath + "/playerData.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<PlayerData>(json);
        }
        return null;
    }
}
```

*/