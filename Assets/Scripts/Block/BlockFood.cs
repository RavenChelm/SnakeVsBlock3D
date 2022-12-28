using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class BlockFoodData
{
    [SerializeField] private int _minValue;
    public int MinValue { get => _minValue; }
    [SerializeField] private int _maxValue;
    public int MaxValue { get => _maxValue; }
}
public class BlockFood : BaseBlock
{
    private BlockFoodData Data => GeneralSettings.Instance.BlockFoodData;

    private void Start()
    {
        HealthChanged(Random.Range(Data.MinValue, Data.MaxValue));
    }
    protected override void ChangeHealth(IHealth health)
    {
        health.ChangeHealth(Health);
        HealthChanged(0);
        Destroy(gameObject);
    }
}