using System;
using UnityEngine;
using UnityEngine.UI;

public sealed class HUDBoostUpdater : MonoBehaviour
{
    private UbootBoost _boostInstance;
    [SerializeField] private Image _image;
    [SerializeField] private Sprite[] _boostSprites;

    private void Awake()
    {
        _boostInstance = GameObject.FindGameObjectWithTag("Player").GetComponent<UbootBoost>();
        this._boostInstance.BoostInventoryChanged += BoostInventoryChanged;
    }

    private void BoostInventoryChanged(int newValue)
    {
        int index = Math.Clamp(newValue, 0, this._boostSprites.Length - 1);
        this._image.sprite = _boostSprites[index];
    }
}