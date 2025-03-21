using System;
using UnityEngine;

public sealed class HUDHealthUpdater : MonoBehaviour
{
    private Health _playerHealth;

    [SerializeField]
    private UIColorModulator _colorModulator;
    
    [SerializeField] private Gradient _gradient;
    private void Awake()
    {
        this._playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        this._playerHealth.OnHealthChange += PlayerHealthOnOnHealthChange;
    }

    private void PlayerHealthOnOnHealthChange(int newHealth)
    {
        int clampedHealth = Mathf.Clamp(newHealth, 0, this._playerHealth.InitialHealth);
        float normalisedHealth = (float)clampedHealth / this._playerHealth.InitialHealth;

        this._colorModulator.Color = this._gradient.Evaluate(normalisedHealth);
    }
}