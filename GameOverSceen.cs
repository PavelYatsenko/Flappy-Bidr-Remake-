using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameOverSceen : Sceen
{
    [SerializeField] private Bird _bird;
    [SerializeField] private TMP_Text _textBestScore;
    [SerializeField] private TMP_Text _textScore;
    [SerializeField] private Image _imageMidal; 
    [SerializeField] private List<Sprite> _midals;

    private int _bestScore;



    public event UnityAction RestartButtonClick;

    private void Awake()
    {
        PlayerPrefs.SetInt("BestScore", 0);
        _bestScore = PlayerPrefs.GetInt("BestScore");
    }
    public override void Close()
    {
        CanvasGroup.alpha = 0;
        Button.interactable = false;
    }

    public override void Open()
    {
        if (_bird.Score >= 5)
            _imageMidal.sprite = _midals[0];
        if (_bird.Score >= 20)
            _imageMidal.sprite = _midals[1];
        if (_bird.Score >= 30)
            _imageMidal.sprite = _midals[2];
        if (_bird.Score >= 50)
            _imageMidal.sprite = _midals[3];


        if (_bird.Score > _bestScore)
            PlayerPrefs.SetInt("BestScore", _bird.Score);

        _textBestScore.text = _bestScore.ToString();
        _textScore.text = _bird.Score.ToString();


        CanvasGroup.alpha = 1;
        Button.interactable = true;
    }

    protected override void OnButtonClick()
    {
        RestartButtonClick?.Invoke();
    }
}
