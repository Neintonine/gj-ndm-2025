using System;
using UnityEngine;

public sealed class HealthReplenisher: MonoBehaviour
{
    [SerializeField] private float replenishRate;
    [SerializeField] private float timeout;
    
    private Health _health;
    private float _currentTimeout = 0f;

    private void Awake()
    {
        _health = GetComponent<Health>();
        this._health.OnDamage += HealthOnOnHealthChange;
    }

    private void HealthOnOnHealthChange()
    {
        _currentTimeout = this.timeout;
    }

    private void Update()
    {
        if (_currentTimeout > 0)
        {
            _currentTimeout -= Time.deltaTime;
            return;
        }
        
        int addHealth = Mathf.CeilToInt(replenishRate * Time.deltaTime);
        addHealth = Math.Clamp(addHealth, 0, this._health.InitialHealth - this._health.health);
        this._health.Takedamage(-addHealth);
    }
}