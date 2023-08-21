using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLook : MonoBehaviour
{
    public LevelSave LevelSave;

    private void Start()
    {
        LevelSave = SaveInfo.LevelSave;
    }
}
