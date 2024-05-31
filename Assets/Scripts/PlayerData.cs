using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    
    public enum STATUS {Healthy, Sleepy, Poisoned}
    public string name;
    public int health;
    public STATUS status;


    public string Display() {
        return $"{name} -  {health} - {status.ToString()}";
    }
}
