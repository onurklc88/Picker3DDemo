using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DepencyInstaller : MonoInstaller
{
    [SerializeField] private PickerCollisions _pickerCollisions;
    [SerializeField] private MapManager _mapManager;
    [SerializeField] private LevelManager _levelManager;
    public override void InstallBindings()
    {
        Container.Bind<PickerCollisions>().FromComponentInHierarchy(_pickerCollisions).AsSingle();
        Container.Bind<MapManager>().FromComponentInHierarchy(_mapManager).AsSingle();
        Container.Bind<LevelManager>().FromComponentInHierarchy(_levelManager).AsSingle();
    }
}
