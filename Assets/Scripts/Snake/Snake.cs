using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
[System.Serializable]
public class SnakeData
{
    private int _health = 4;
    public int Health { get => _health; set => _health = value; }
    [SerializeField] private int _startHealth = 4;
    public int StartHealth { get => _startHealth; set => _startHealth = value; }
}
public class Snake : MonoBehaviour, IHealth
{
    private SnakeData Data => GeneralSettings.Instance.SnakeData;
    public event Action<int> onHealthChanged;
    public event Action<int> onHealthMinus;
    public event Action<int> onHealthPlus;
    private SnakeBody _snakeBody;
    [SerializeField] private GameObject _menuController;
    private void Awake()
    {
        _snakeBody = GetComponent<SnakeBody>();

    }
    private void OnEnable()
    {
        onHealthMinus += _snakeBody.RemovePart;
        onHealthPlus += _snakeBody.AddPart;

        Data.Health = Data.StartHealth;
        onHealthChanged?.Invoke(Data.Health);
    }
    public void ChangeHealth(int value)
    {
        Data.Health += value;
        onHealthChanged?.Invoke(Data.Health);

        if (value > 0) onHealthPlus?.Invoke(value);
        else onHealthMinus?.Invoke(obj: value);
        if (Data.Health <= 0) _menuController.SendMessage("GameOverMenu");
    }
    private void OnDisable()
    {
        onHealthMinus -= _snakeBody.RemovePart;
        onHealthPlus -= _snakeBody.AddPart;
    }
}
