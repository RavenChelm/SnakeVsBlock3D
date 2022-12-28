using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class SnakeUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    private Snake _snake;
    private void Awake()
    {
        _snake = GetComponent<Snake>();
    }
    private void OnEnable()
    {
        _snake.onHealthChanged += OnHealthChanged;
    }
    private void OnHealthChanged(int value)
    {
        _text.text = value.ToString();
    }
    private void OnDisable()
    {
        _snake.onHealthChanged -= OnHealthChanged;
    }
}