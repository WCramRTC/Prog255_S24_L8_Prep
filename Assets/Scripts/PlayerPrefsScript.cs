using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PlayerPrefsScript : MonoBehaviour
{

    // Start is called before the first frame update
    UIManager uiManager;
    TMP_Text display;
    void Start()
    {

        uiManager = FindFirstObjectByType<UIManager>();

        // PlayerPrefs works with a key value pair
        // PlayerPrefs.SetType(key, value)
        // PlayerPrefs.GetType(key, default)

        if(uiManager != null) {
            Debug.Log("Manager Found");
            display = uiManager.playerPref;
            display.text = "PlayerPrefs in PlayerPrefsScript";
        }

        // PlayerPrefs.SetString("name", "Will");

        // display.text = PlayerPrefs.GetString("sam", "Unknown");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

/*

### 1. **PlayerPrefs**
For simple data like settings or high scores, Unity’s built-in `PlayerPrefs` is the easiest way to save and load data.

```csharp
// Save data
PlayerPrefs.SetInt("HighScore", 100);
PlayerPrefs.SetString("PlayerName", "John");

// Load data
int highScore = PlayerPrefs.GetInt("HighScore", 0);
string playerName = PlayerPrefs.GetString("PlayerName", "Unknown");
```

*/