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
    [SerializeField] private float _repeat_time;
    public float Repeat_time { get => _repeat_time; }
    [SerializeField] private float _curr_time = 0;
    public float Curr_time { get => _curr_time; set => _curr_time = value; }
}
public class BlockHorizontal : BaseBlock
{
    private BlockHorizontalData Data => GeneralSettings.Instance.BlockHorizontalData;
    private Gradient _gradient;
    private GradientColorKey[] _colorKey;
    private GradientAlphaKey[] _alphaKey;
    private Renderer _renderer;
    [SerializeField] GameObject particle;
    private Renderer _renderer_particle;
    private void Start()
    {
        Health = Random.Range(Data.MinValue, Data.MaxValue);
        HealthChanged(Health);

        _renderer = gameObject.GetComponent<Renderer>();
        _renderer_particle = particle.GetComponent<Renderer>();


        _gradient = new Gradient();
        _colorKey = new GradientColorKey[2];
        _colorKey[0].color = Color.red;
        _colorKey[0].time = 0.0f;
        _colorKey[1].color = Color.blue;
        _colorKey[1].time = 1.0f;
        _alphaKey = new GradientAlphaKey[2];
        _alphaKey[0].alpha = 1.0f;
        _alphaKey[0].time = 0.0f;
        _alphaKey[1].alpha = 1.0f;
        _alphaKey[1].time = 1.0f;
        _gradient.SetKeys(_colorKey, _alphaKey);

        UpdateColor();
    }
    private int _progress;
    protected override void ChangeHealth(IHealth health)
    {
        Debug.Log(Data.Curr_time);
        Data.Curr_time -= 0.01f;
        if (Data.Curr_time <= 0)
        {
            particle.SetActive(true);
            _progress++;
            health.ChangeHealth(-1);
            HealthChanged(Health - _progress);
            UpdateColor();
            if (_progress >= Health)
            {
                Destroy(gameObject);
            }
            Data.Curr_time = Data.Repeat_time;
        }

    }

    private void UpdateColor()
    {
        float color = (Health - _progress) / (float)Data.MaxValue;
        _renderer.material.SetColor("_Color", _gradient.Evaluate(color));
        _renderer_particle.material = _renderer.sharedMaterial;
    }
    private void OnCollisionExit(Collision other)
    {
        particle.SetActive(false);
    }
}