using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[System.Serializable]
public class UIData
{
    [SerializeField] private int _score = 0;
    public int Score { get => _score; set => _score = value; }
    [SerializeField] private int _bestScore = 0;
    public int BestScore { get => _bestScore; set => _bestScore = value; }
}
public class GameUI : MonoBehaviour
{
    //Game
    [SerializeField] private TMP_Text Score;
    [SerializeField] private TMP_Text LevelNumber;
    //Start
    [SerializeField] private TMP_Text BestScoreStart;
    //reStart
    [SerializeField] private TMP_Text BestScoreReStart;
    [SerializeField] private TMP_Text ScoreReStart;
    //Victory
    [SerializeField] private TMP_Text ScoreVictory;
    private SnakeData DataSnake => GeneralSettings.Instance.SnakeData;
    private UIData DataUI => GeneralSettings.Instance.UIData;
    private GameData DataGame => GeneralSettings.Instance.GameData;

    private Snake _snake;

    private void Awake()
    {

        _snake = GetComponent<Snake>();
    }
    private void OnEnable()
    {
        _snake.onHealthPlus += ScoreUp;
        _snake.onHealthMinus += ScoreUp;
        DataUI.Score = 0;

        LevelNumber.SetText("Level: " + (DataGame.CurrentLevel + 1).ToString());
        ScoreUp(0);
    }
    private void ScoreUp(int value)
    {

        DataUI.Score += value;
        Score.SetText(DataUI.Score.ToString());
        ScoreReStart.SetText(DataUI.Score.ToString());
        ScoreVictory.SetText(DataUI.Score.ToString());
        if (DataUI.Score >= DataUI.BestScore)
        {
            DataUI.BestScore = DataUI.Score;
        }
        BestScoreStart.SetText("Best:" + DataUI.BestScore.ToString());
        BestScoreReStart.SetText("Best:" + DataUI.BestScore.ToString());
    }
    private void OnDisable()
    {
        _snake.onHealthPlus -= ScoreUp;
        _snake.onHealthMinus -= ScoreUp;

    }
}
