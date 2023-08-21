using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<LevelProperties> _levelList;
    private int _currentLevelIndex;


    private void Awake()
    {
        SaveInfo.Init();
    }

    private void Start()
    {
        StartNextLevel();
    }
   

    public void GetNextLevel()
    {
        SaveInfo.LevelSave.LevelIndex++;
        SaveInfo.LevelSave.Save();
        StartNextLevel();
    }


    private void GenerateRandomLevel()
    {
        _levelList[0].GenerateRandomVariables();
        EventLibrary.SendLevelProperties.Invoke(_levelList[0]);
        _currentLevelIndex = 0;
        EventLibrary.OnLevelPhaseChange.Invoke(GameStates.GamePhase.LevelSetup);
    }

    private void StartNextLevel()
    {
        if (SaveInfo.LevelSave.LevelIndex < _levelList.Count)
        {
            _currentLevelIndex = SaveInfo.LevelSave.LevelIndex;
            EventLibrary.SendLevelProperties.Invoke(_levelList[SaveInfo.LevelSave.LevelIndex]);
            EventLibrary.OnLevelPhaseChange.Invoke(GameStates.GamePhase.LevelSetup);
        }
        else
        {
            GenerateRandomLevel();
        }
    }

    public void RestartLevel()
    {
        EventLibrary.OnLevelPhaseChange.Invoke(GameStates.GamePhase.LevelSetup);
    }

    public LevelProperties GetCurrentLevelProperties()
    {
        return _levelList[_currentLevelIndex];
    }
}
