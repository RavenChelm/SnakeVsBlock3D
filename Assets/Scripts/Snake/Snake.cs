using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
[System.Serializable]
public class SnakeData
{
    [SerializeField] private int _health = 4;
    public int Health { get => _health; set => _health = value; }
    [SerializeField] private int _maxHealth = 4;
    public int MaxHealth { get => _maxHealth; set => _maxHealth = value; }
}
public class Snake : MonoBehaviour, IHealth
{
    private SnakeData Data => GeneralSettings.Instance.SnakeData;
    public event Action<int> onHealthChanged;
    private void Start()
    {
        Data.Health = Data.MaxHealth;
        onHealthChanged?.Invoke(Data.Health);
    }
    public void ChangeHealth(int value)
    {
        Data.Health += value;
        onHealthChanged?.Invoke(Data.Health);
    }
}
