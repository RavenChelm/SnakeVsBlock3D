using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class BlockUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    private BaseBlock _block;
    private void Awake()
    {
        _block = GetComponent<BaseBlock>();
    }
    private void OnEnable()
    {
        _block.onHealthChanged += OnHealthChanged;
    }
    private void OnHealthChanged(int value)
    {
        _text.text = value.ToString();
    }
    private void OnDisable()
    {
        _block.onHealthChanged -= OnHealthChanged;
    }
}