using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class BlockHorizontalData
{
    [SerializeField] private int _minValue;
    public int MinValue { get => _minValue; }
    [SerializeField] private int _maxValue;
    public int MaxValue { get => _maxValue; }
}
public class BlockHorizontal : BaseBlock
{

    private BlockHorizontalData Data => GeneralSettings.Instance.BlockHorizontalData;

    private void Start()
    {
        HealthChanged(Random.Range(Data.MinValue, Data.MaxValue));
    }
    private int _progress;
    protected override void ChangeHealth(IHealth health)
    {
        _progress++;
        health.ChangeHealth(-1);
        HealthChanged(Health - _progress);
        if (_progress >= Health)
        {
            Destroy(gameObject);
        }
    }
}