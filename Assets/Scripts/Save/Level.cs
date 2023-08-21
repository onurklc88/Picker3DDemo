using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class LevelSave : LevelSaveInput
{
    public LevelSave()
    {
        base._value = this;
    }
}
