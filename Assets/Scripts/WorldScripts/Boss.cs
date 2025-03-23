using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class Boss : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _hitPlayerSpawn;
    
    [SerializeField] private UIFader _fader;
    
    private float _currentHeight;

    private void Awake()
    {
        _currentHeight = transform.position.y;
        this.gameObject.SetActive(false);
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

    private async void OnCollisionEnter2D(Collision2D other)
    {
        try
        {
            if (!other.gameObject.CompareTag("Player"))
            {
                return;
            }

            await this._fader.FadeOut(0.5f);
        
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            GameObject.FindGameObjectWithTag("Player").transform.position = this._hitPlayerSpawn.position;
        }
        catch (Exception e)
        {
            // ignore
        }
    }
}