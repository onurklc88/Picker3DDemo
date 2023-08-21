using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionCalculateState : CollectionBaseState
{
    private int _collectedObjectCount;
    private int _totalObjectCount;
    public override void EnterState(CollectionStateManager collection)
    {
        _collectedObjectCount = 0;
        _totalObjectCount = collection.LevelManager.GetCurrentLevelProperties().LevelParts[((int)collection.CurrentLevelPart)].TotalObjectCount;
        collection.CollectedObjectText.text = _collectedObjectCount + " / " + _totalObjectCount;
    }

    public override void ExitState(CollectionStateManager collection)
    {
        CalculatePlayerSuccess(collection);
        _collectedObjectCount = 0;
    }
    public override void CollisionState(CollectionStateManager collection, Collider collectedObject)
    {
        if(_collectedObjectCount < 1)
            collection.StartCoroutine(DelayState(collection));


        if (collectedObject.gameObject.layer == 8)
        {
            collectedObject.gameObject.layer = 0;
            _collectedObjectCount++;
            collection.CollectedObjectText.text = _collectedObjectCount + " / " + _totalObjectCount;
        }
    }

    protected override IEnumerator DelayState(CollectionStateManager collection)
    {
        yield return new WaitForSeconds(2f);
        ExitState(collection);
    }

    private void CalculatePlayerSuccess(CollectionStateManager collection)
    {
        if(_collectedObjectCount < _totalObjectCount)
        {
            collection.PlayerSuccessIndex = 0;
        }
        else if(_collectedObjectCount == _totalObjectCount)
        {
            collection.PlayerSuccessIndex = 1;
        }
        else
        {
            collection.PlayerSuccessIndex = 2;
        }
        
        collection.SwitchState(collection.CollectionFinishState);
    }
}
