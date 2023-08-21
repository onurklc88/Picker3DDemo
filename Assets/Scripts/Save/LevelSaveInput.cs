using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSaveInput : SaveSystem
{
    //SAVE INPUTS
    public int LevelIndex;
   
    public LevelSaveInput()
    {
        //First value of inputs
        LevelIndex = 0;
    }
}
