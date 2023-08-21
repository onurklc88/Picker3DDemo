using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;


public class CollectionFinishState : CollectionBaseState
{
    private Vector3 _platformStartPosition;
   
    public override void EnterState(CollectionStateManager collection)
    {
        _platformStartPosition = collection.Platform.transform.position;
       
        if(collection.PlayerSuccessIndex == 0)
        {
            EventLibrary.OnLevelPartCompleted.Invoke(collection.PlayerSuccessIndex);
            EventLibrary.OnLevelPhaseChange.Invoke(GameStates.GamePhase.LevelFinish);
            collection.SwitchState(collection.CollectionCalculateState);
        }
        else
        {
            Tween moveTween = collection.Platform.transform.DOMoveY(-0.718f, 1f);
            moveTween.OnComplete(() =>
            {
                ExitState(collection);
            });
        }

        collection.StartCoroutine(DelayState(collection));
    }

    public override void ExitState(CollectionStateManager collection)
    {
        collection.Platform.gameObject.layer = 9;
        EventLibrary.UpdateIndicator.Invoke(collection.CurrentLevelPart);
        EventLibrary.OnLevelPartCompleted.Invoke(collection.PlayerSuccessIndex);
        EventLibrary.OnLevelPhaseChange.Invoke(GameStates.GamePhase.LevelPlay);
        collection.SwitchState(collection.CollectionCalculateState);
        collection.StartCoroutine(DelayState(collection));
    }

    protected override IEnumerator DelayState(CollectionStateManager collection)
    {
        yield return new WaitForSeconds(4f);
        collection.Platform.transform.DOMoveY(_platformStartPosition.y, 1f);
        collection.Platform.gameObject.layer = 11;
       
      

    }

   
   


}
