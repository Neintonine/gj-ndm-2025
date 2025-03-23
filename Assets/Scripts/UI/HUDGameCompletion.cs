using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class HUDGameCompletion : MonoBehaviour
{
    public void ShowModal()
    {
        this.transform.DOLocalMove(Vector3.zero, 0.5f);
    }

    public void ShowMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}   