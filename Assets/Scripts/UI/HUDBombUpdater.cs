using System;
using TMPro;
using UnityEngine;

public sealed class HUDBombUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private BombAttack _attackInstance;

    private void Awake()
    {
        this._attackInstance = GameObject.FindGameObjectWithTag("Player").GetComponent<BombAttack>();
        this._attackInstance.BombInventoryChanged += BombInventoryChanged;
    }

    private void BombInventoryChanged(int newAmount)
    {
        _text.text = newAmount.ToString();
    }
}