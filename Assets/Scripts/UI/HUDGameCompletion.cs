using System;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class HUDGameCompletion : MonoBehaviour
{
    [SerializeField] private UIFader _fader;
    public void ShowModal()
    {
        this.transform.DOLocalMove(Vector3.zero, 0.5f);
    }

    public void ShowMainMenu()
    {
        this.showMainMenu();
    }

    private async Task showMainMenu()
    {
        await this._fader.FadeOut(0.5f);
        SceneManager.LoadScene("MainMenu");
    }
}   