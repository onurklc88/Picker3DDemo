using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;


public class CollectionStateManager : MonoBehaviour,ILevelFlow
{
    [HideInInspector] public int PlayerSuccessIndex;
    [SerializeField] private LevelEnums.LevelParts _levelPart;
    [SerializeField] private TextMeshProUGUI _collectedObjectText;
    [SerializeField] private GameObject _platform;
    [Inject]
    LevelManager _levelManager;
    private CollectionBaseState _currentState = null;
    private List<GameObject> _collectedObjects = new List<GameObject>();
     #region Getters & Setters
    public CollectionCalculateState CollectionCalculateState = new CollectionCalculateState();
    public CollectionFinishState CollectionFinishState = new CollectionFinishState();
    public TextMeshProUGUI CollectedObjectText => _collectedObjectText;
    public GameObject Platform => _platform;
    public List<GameObject> CollectedObjects => _collectedObjects;
    public LevelEnums.LevelParts CurrentLevelPart => _levelPart;
    public LevelManager LevelManager => _levelManager;
    #endregion
    public GameStates.GamePhase CurrentGamePhase { get; set; }
    

    private void OnEnable()
    {
       EventLibrary.OnLevelPhaseChange.AddListener(LevelOnPlay);
    }

    private void OnDisable()
    {
        EventLibrary.OnLevelPhaseChange.RemoveListener(LevelOnPlay);
    }
    public void LevelOnPlay(GameStates.GamePhase gamePhase)
    {
        gamePhase = CurrentGamePhase;

        switch (gamePhase)
        {
            case GameStates.GamePhase.LevelSetup:
                SwitchState(CollectionCalculateState);
                break;
          
        }
    }

    private void Start()
    {
        _currentState = CollectionCalculateState;
        _currentState.EnterState(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        _currentState.CollisionState(this, other);
    }
    public void SwitchState(CollectionBaseState newState)
    {
        _currentState = newState;
        _currentState.EnterState(this);
    }
}
