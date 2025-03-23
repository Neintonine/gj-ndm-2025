using System;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public sealed class UIFader : MonoBehaviour
{
    private RawImage _image;
    
    private async void Awake()
    {
        try
        {
            this._image = this.GetComponent<RawImage>();

            await this.FadeIn(0.5f);
        }
        catch (Exception e)
        {
            // Ignore
        }
    }

    public async Task FadeIn(float duration)
    {
        this._image.color = Color.black;
        await this._image.DOColor(Color.clear, duration).AsyncWaitForCompletion();
    }

    public async Task FadeOut(float duration)
    {
        this._image.color = Color.clear;
        await this._image.DOColor(Color.black, duration).AsyncWaitForCompletion();
    }
}