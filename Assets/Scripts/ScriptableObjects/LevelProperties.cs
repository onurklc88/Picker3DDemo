using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[System.Serializable]

public struct LevelPartProperties
{
    public string Name;
    [Range(0, 50)]
    public int TotalObjectCount;
    public CollectibleType.CollectibleShape CollectibleShape;
    
}

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Levels", order = 1)]
public class LevelProperties : ScriptableObject
{
    [Range(0, 10)]
    public int CountOfExtraObjects;
    private const int _size = 3;
    public LevelPartProperties[] LevelParts = new LevelPartProperties[_size];
  
   



    private void OnValidate()
    {
        Array.Resize(ref LevelParts, _size);
    }

    public void GenerateRandomVariables()
    {
        for(int i = 0; i < _size; i++)
        {
            CountOfExtraObjects = UnityEngine.Random.Range(1, 10);
            LevelParts[i].TotalObjectCount = UnityEngine.Random.Range(20, 50);
            LevelParts[i].CollectibleShape = GetRandomEnum<CollectibleType.CollectibleShape>();
        }
    }

    public static T GetRandomEnum<T>()
    {
        System.Array A = System.Enum.GetValues(typeof(T));
        T V = (T)A.GetValue(UnityEngine.Random.Range(0, A.Length - 1));
        return V;
    }

   

}
