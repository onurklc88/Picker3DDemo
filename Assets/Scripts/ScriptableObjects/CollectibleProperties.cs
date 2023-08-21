using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Collecitble", menuName = "ScriptableObjects/Collectibles", order = 1)]
public class CollectibleProperties : ScriptableObject
{
    public GameObject CollectiblePrefab;
    [Range(0, 0.4f)]
    public float _objectScale;
    public Vector3 _objectRotation;
}
