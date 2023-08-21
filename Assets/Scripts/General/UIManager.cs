using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour,ILevelFlow
{
    private Tween _scaleTween;
    [SerializeField] private TextMeshProUGUI _successUI;
    [SerializeField] private string[] _successTexts;
    [SerializeField] private GameObject[] _levelFinishUI;
    [SerializeField] private TextMeshProUGUI[] _indicatorText;
    [SerializeField] private Image[] _indicatorImage;
    private int _currentSuccessIndex;
    public GameStates.GamePhase CurrentGamePhase { get; set; }
    private void OnEnable()
    {
        EventLibrary.OnLevelPhaseChange.AddListener(LevelOnPlay);
        EventLibrary.OnLevelPartCompleted.AddListener(ShowPlayerSuccess);
        EventLibrary.UpdateIndicator.AddListener(UpdateIndicatorUI);
    }

    private void OnDisable()
    {
        EventLibrary.OnLevelPhaseChange.RemoveListener(LevelOnPlay);
        EventLibrary.OnLevelPartCompleted.RemoveListener(ShowPlayerSuccess);
        EventLibrary.UpdateIndicator.RemoveListener(UpdateIndicatorUI);
    }
    
    private void UpdateIndicatorUI(LevelEnums.LevelParts levelParts)
    {
        _indicatorImage[((int)levelParts)].color = Color.green;
    }
    private void Start()
    {
        SetIndicatorVariables();
    }
    public void LevelOnPlay(GameStates.GamePhase gamePhase)
    {
        switch (gamePhase)
        {
            case GameStates.GamePhase.LevelSetup:
                ResetUI();
                if (_currentSuccessIndex == 0) return;
                SetIndicatorVariables();
                _currentSuccessIndex = 0;
                break;
            case GameStates.GamePhase.LevelFinish:
                ShowLevelFinishUI(_currentSuccessIndex);
                break;
        }
    }

    private void ShowPlayerSuccess(int successIndex)
    {
        _currentSuccessIndex = successIndex;
        _successUI.text = _successTexts[successIndex];
        _successUI.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.Linear).OnComplete(() =>
        {
           StartCoroutine(HideSuccessUI());
        });


    }

    private void ShowLevelFinishUI(int successIndex)
    {
        _levelFinishUI[successIndex].SetActive(true);
    }
    private void SetIndicatorVariables()
    {
         int levelIndex = SaveInfo.LevelSave.LevelIndex;
        levelIndex += 1;
        _indicatorText[0].text = levelIndex.ToString();
        _indicatorText[1].text = (levelIndex + 1).ToString();
    }

    private void ResetUI()
    {
        _levelFinishUI[0].SetActive(false);
        _levelFinishUI[1].SetActive(false);
        for (int i = 0; i < _indicatorImage.Length; i++)
            _indicatorImage[i].color = Color.red;


    }


    private IEnumerator HideSuccessUI()
    {
        yield return new WaitForSeconds(1f);
        _successUI.transform.DOScale(Vector3.zero, 0.5f);
       
    }
}
