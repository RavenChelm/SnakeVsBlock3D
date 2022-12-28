using UnityEngine;
using System;

public interface IHealth
{
    void ChangeHealth(int value);
}

public abstract class BaseBlock : MonoBehaviour
{
    public event Action<int> onHealthChanged;
    [SerializeField] private int _health;
    public int Health => _health;
    protected virtual void ChangeHealth(IHealth health) { }
    // private void Start()
    // {
    //     HealthChanged(_health);
    // }
    protected void HealthChanged(int value)
    {
        onHealthChanged?.Invoke(value);
    }
    private void OnCollisionStay(Collision other)
    {
        var health = other.gameObject.GetComponent<IHealth>();
        if (health != null)
        {
            ChangeHealth(health);
        }
    }


}


