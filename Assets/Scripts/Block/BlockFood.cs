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
    [SerializeField] private GameObject particle;
    private void Start()
    {
        Health = Random.Range(Data.MinValue, Data.MaxValue);
        HealthChanged(Health);
    }
    protected override void ChangeHealth(IHealth health)
    {
        particle.SetActive(true);
        health.ChangeHealth(Health);
        HealthChanged(0);
        StartCoroutine(Destroy());
    }
    IEnumerator Destroy()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}