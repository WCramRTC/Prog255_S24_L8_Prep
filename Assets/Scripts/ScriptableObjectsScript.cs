using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScriptableObjectsScript : MonoBehaviour
{
    // Start is called before the first frame update
    TMP_Text display;

    void Start()
    {
        UIManager ui = FindFirstObjectByType<UIManager>();
        display = ui.scriptable;
        display.text = "Scriptable From File";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

/*

### 3. **Using ScriptableObjects**
ScriptableObjects are great for saving static data that doesn’t change during runtime. You can create and edit these objects in the Unity Editor.

```csharp
[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public int level;
    public int health;
}
```


 */