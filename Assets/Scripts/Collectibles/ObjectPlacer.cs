using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPlacer : MonoBehaviour, ILevelFlow, IProperties
{
    [SerializeField] private LevelEnums.LevelParts _levelPart;
    [SerializeField] private List<GameObject> _spawnSets;
    [SerializeField] private List<GameObject> _spawnPoints;
    private LevelProperties _levelProperties;
    private List<GameObject> _placedObjects = new List<GameObject>();
    private List<int> _randomIndex = new List<int>();
    public LevelProperties LevelProperties { get; set; }
    public GameStates.GamePhase CurrentGamePhase { get; set; }

    private void OnEnable()
    {
        EventLibrary.SendLevelProperties.AddListener(GetCurrentLevelProperties);
        EventLibrary.OnLevelPhaseChange.AddListener(LevelOnPlay);
    }

    private void OnDisable()
    {
        EventLibrary.SendLevelProperties.RemoveListener(GetCurrentLevelProperties);
        EventLibrary.OnLevelPhaseChange.RemoveListener(LevelOnPlay);
    }


    public void LevelOnPlay(GameStates.GamePhase tempPhase)
    {
        switch (tempPhase)
        {
            case GameStates.GamePhase.LevelSetup:
                for (int i = 1; i < _spawnPoints.Count; i++)
                      _randomIndex.Add(i);
                
                PlaceSpawnedObjects(((int)_levelProperties.LevelParts[((int)_levelPart)].CollectibleShape));
                break;
            case GameStates.GamePhase.LevelFinish:
                _randomIndex.Clear();
                ResetPlacedObject();
                break;
        }
    }
    public void GetCurrentLevelProperties(LevelProperties levelProperties)
    {
        _levelProperties = levelProperties;
    }

    private void PlaceSpawnedObjects(int objectType)
    {
        int randomValue = UnityEngine.Random.Range(0, 3);
        int tempObjectCounter = _levelProperties.LevelParts[((int)_levelPart)].TotalObjectCount + _levelProperties.CountOfExtraObjects;
        int loopCounter = GetLoopCounter(tempObjectCounter);
        for (int i = 0; i < loopCounter; i++)
        {
            Transform[] childPositions = _spawnSets[randomValue].GetComponentsInChildren<Transform>();
            _spawnSets[randomValue].transform.position = _spawnPoints[GetRandomSpawnPosition()].transform.position;
            for (int j = 1; j < childPositions.Length; j++)
            {
                GameObject collectible = ObjectPool.GetPooledObject(objectType);
                _placedObjects.Add(collectible);
                collectible.SetActive(true);
                collectible.transform.position = childPositions[j].transform.position;
                tempObjectCounter--;
                if (tempObjectCounter <= 0) return;
            }

        }
    }

   
    private int GetLoopCounter(int totalObjectCount)
    {
        int tempCounter = totalObjectCount / 10;
        int remainder = totalObjectCount % 10;
        if (remainder != 0)
            return tempCounter += 1;
        else
            return tempCounter;
    }

    private int GetRandomSpawnPosition()
    {
        int randomIndex = Random.Range(0, _randomIndex.Count);
        int randomValue = _randomIndex[randomIndex];
        _randomIndex.RemoveAt(randomIndex);

        return randomValue;
    }

    private void ResetPlacedObject()
    {
        for(int i = 0; i < _placedObjects.Count; i++)
        {
            _placedObjects[i].transform.position = Vector3.zero;
            _placedObjects[i].transform.rotation = Quaternion.identity;
            _placedObjects[i].layer = 8;
            _placedObjects[i].SetActive(false);
        }
    }

}
