using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour,ILevelFlow
{
  
    [SerializeField] private List<GameObject> _mapList;
    private int _activeMapIndex = 0;
    private int _playerSuccess;
   
     public GameStates.GamePhase CurrentGamePhase { get; set; }
    
    private void OnEnable()
    {
        EventLibrary.OnLevelPhaseChange.AddListener(LevelOnPlay);
        EventLibrary.OnLevelPartCompleted.AddListener(SetPlayerSuccess);
    }

    private void OnDisable()
    {
        EventLibrary.OnLevelPhaseChange.RemoveListener(LevelOnPlay);
        EventLibrary.OnLevelPartCompleted.RemoveListener(SetPlayerSuccess);
    }

    private void SetPlayerSuccess(int index)
    {
        _playerSuccess = index;
    }

    private void Start()
    {
        _activeMapIndex = 1;
        MovePreviewMap();
    }
    public void LevelOnPlay(GameStates.GamePhase gamePhase)
    {
        CurrentGamePhase = gamePhase;
     
        switch (gamePhase)
        {
            case GameStates.GamePhase.LevelSetup:
               _playerSuccess = 0;
               break;
            case GameStates.GamePhase.LevelFinish:
                if (_playerSuccess == 0) return;
                ShowNewMap();
                break;
               
        }
    }

   
    public Vector3 GetStartPositon()
    {
       return _mapList[_activeMapIndex].transform.GetChild(0).transform.position;
    }

    private void ShowNewMap()
    {
        _mapList[_activeMapIndex].SetActive(false);
        int lastIndex = _activeMapIndex;
        if (lastIndex == 2)
             _activeMapIndex = 1;
         else
             _activeMapIndex = 2;
        
        _mapList[_activeMapIndex].SetActive(true);
        _mapList[_activeMapIndex].transform.position = new Vector3(_mapList[lastIndex].transform.position.x, _mapList[lastIndex].transform.position.y, _mapList[lastIndex].transform.position.z + 170f);
        MovePreviewMap();
    }

    private void MovePreviewMap()
    {
        _mapList[0].transform.position = new Vector3(_mapList[0].transform.position.x, _mapList[0].transform.position.y, _mapList[0].transform.position.z + 175f);
    }
}
