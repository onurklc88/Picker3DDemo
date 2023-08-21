using System;
using System.Collections.Generic;
using UnityEngine;
public static class EventLibrary
{
    //LevelEvents
    public static readonly GameEvent<GameStates.GamePhase> OnLevelPhaseChange = new GameEvent<GameStates.GamePhase>();
    public static readonly GameEvent<LevelProperties> SendLevelProperties = new GameEvent<LevelProperties>();
    public static readonly GameEvent<List<GameObject>> SendCurrentLevelParts = new GameEvent<List<GameObject>>();
    public static readonly GameEvent<LevelEnums.LevelParts> UpdateIndicator = new GameEvent<LevelEnums.LevelParts>();

    //Collectible Events
    public static readonly GameEvent OnCollectionAreaReached = new GameEvent();

    //UI events
    public static readonly GameEvent<int> OnLevelPartCompleted = new GameEvent<int>();
}
