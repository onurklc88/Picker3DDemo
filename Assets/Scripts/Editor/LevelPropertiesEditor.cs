using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelProperties))]
public class LevelPropertiesEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
      
        var levelProperties = (LevelProperties)target;
        
        if (GUILayout.Button("Clean Level Values"))
        {
            levelProperties.CountOfExtraObjects = 0;
            
            for(int i = 0; i < levelProperties.LevelParts.Length; i++)
            {
                levelProperties.LevelParts[i].TotalObjectCount = 0;
                levelProperties.LevelParts[i].CollectibleShape = CollectibleType.CollectibleShape.Cube;
            }
        }
    }
}
