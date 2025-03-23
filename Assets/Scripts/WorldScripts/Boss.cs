using System;
using UnityEngine;

public sealed class Boss : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _speed;
    
    private float _currentHeight;

    private void Awake()
    {
        _currentHeight = transform.position.y;
    }

    private void Update()
    {
        if (this._currentHeight > _maxHeight)
        {
            return;
        }
        
        this._currentHeight += _speed * Time.deltaTime;
        this.transform.position = new Vector3(_playerTransform.position.x, this._currentHeight, _playerTransform.position.z);
    }
}