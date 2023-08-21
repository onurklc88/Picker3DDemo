using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
using DG.Tweening;

public class PickerController : MonoBehaviour, ILevelFlow
{
    
    public GameStates.GamePhase CurrentGamePhase { get; set; }
    [Inject]
    PickerCollisions _pickerCollision;
    [Inject]
    MapManager _mapManager;
   
    private TouchInputs _touchInputs;
    private Vector2 _playerInput;
    private float _minX = -90f; 
    private float _maxX = 90f;
    
    private Rigidbody _rigidbody;
    private bool _levelfinish = false;

    private void OnEnable()
    {
        EventLibrary.OnLevelPhaseChange.AddListener(LevelOnPlay);
    }

    private void OnDisable()
    {
        EventLibrary.OnLevelPhaseChange.RemoveListener(LevelOnPlay);
    }
    private void Awake()
    {
       
        _touchInputs = new TouchInputs();
        _touchInputs.Enable();
        _touchInputs.PlayerActions.TouchPress.started += GetPlayerInput;
        _rigidbody = GetComponent<Rigidbody>();
    }
  
    public void LevelOnPlay(GameStates.GamePhase gamePhase)
    {
       
        CurrentGamePhase = gamePhase;
        switch (gamePhase)
        {
            case GameStates.GamePhase.LevelSetup:
                _levelfinish = false;
                /*
                transform.DOMove(_mapManager.GetStartPositon(), 1f).OnUpdate(() =>
                {
                    gameObject.layer = 11;
                }); ;
                */
                transform.position = _mapManager.GetStartPositon();
                break;
        }


    }
    
    private void GetPlayerInput(InputAction.CallbackContext context)
    {
       if (CurrentGamePhase == GameStates.GamePhase.LevelSetup)
            CurrentGamePhase = GameStates.GamePhase.LevelPlay;
        gameObject.layer = 10;
    }

    private void Update()
    {
        _playerInput = InputSystem.GetDevice<Touchscreen>().primaryTouch.delta.ReadValue();
        if (_levelfinish) return;

        if (_pickerCollision.CheckLevelFinishLayer())
        {    _levelfinish = true;
            EventLibrary.OnLevelPartCompleted.Invoke(1);
            EventLibrary.OnLevelPhaseChange.Invoke(GameStates.GamePhase.LevelFinish);
        }
      
        
    }

    private void FixedUpdate()
    {
        MoveMagnet();
        AddConstantMovement();
    }

    private void MoveMagnet()
    {
       Vector3 movement = new Vector3(ClampedPlayerInput(), 0, 0);
        _rigidbody.velocity = (movement * 8f  * Time.fixedDeltaTime);
    }

    private void AddConstantMovement()
    {
       if (CurrentGamePhase == GameStates.GamePhase.LevelStop || CurrentGamePhase == GameStates.GamePhase.LevelSetup) return;
        
        _pickerCollision.CheckGroundLayer();
        transform.Translate(transform.forward * 4f * Time.fixedDeltaTime);
    }
   
    private float ClampedPlayerInput()
    {
         return Mathf.Clamp(_playerInput.x, _minX, _maxX);
    }

   

}
