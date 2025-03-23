using System;
using DG.Tweening;
using UnityEngine;

public class DivingBell : MonoBehaviour

{

    private bool isAttached = false;
    private bool isAtUboot = false;

    public GameObject chainPrefab;
    private GameObject ChainTop;
    private GameObject ChainDown;
    [SerializeField] private Boss boss;
    [SerializeField] private GameObject turtle;
    
    [SerializeField] private AudioSource _backgroundMusicCalm;
    [SerializeField] private AudioSource _backgroundMusicAction;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isAttached)
        {
            other.gameObject.GetComponent<UbootController>().PickupDivingBell(this);
            this.FreeWay();
            this.StartBossFight();
        }
    }

    private void StartBossFight()
    {
        this.boss.gameObject.SetActive(true);
        this.boss.enabled = true;
        
        this._backgroundMusicCalm.DOFade(0, 2f);
        this._backgroundMusicAction.DOFade(0.005f, 2f);
    }

    private void FreeWay()
    {
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("wall"))
        {
            o.SetActive(false);
        }
        
        this.turtle.gameObject.SetActive(false);
    }
}










