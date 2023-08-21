using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollectionBaseState
{
    public abstract void EnterState(CollectionStateManager collection);
    public abstract void ExitState(CollectionStateManager collection);
    public virtual void CollisionState(CollectionStateManager collection, Collider collectedObject) { }

    protected virtual IEnumerator DelayState(CollectionStateManager collection)
    {
        yield return null;
    }
}
