using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProperties
{
    LevelProperties LevelProperties { get; set; }
    void GetCurrentLevelProperties(LevelProperties levelProperties);
}
