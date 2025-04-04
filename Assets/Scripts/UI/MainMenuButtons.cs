using System.Threading.Tasks;
using DG.Tweening;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Developer.Michel.Scripts.UI
{
    public sealed class MainMenuButtons : MonoBehaviour
    {
        [SerializeField] private Transform _hudParent;
        
        [Header("Play game")]
        [SerializeField] private UIFader fader;
        
        [Header("Options")]
        [SerializeField] private Transform _optionsScreen;
        
        [Header("Credits")]
        [SerializeField] private Transform _creditsScreen;
        
        public void PlayGame()
        {
            this._playGame();
        }

        private async Task _playGame()
        {
            await fader.FadeOut(0.5f);
            SceneManager.LoadScene("CombinedLevels", LoadSceneMode.Single);
        }

        public void OpenOptions()
        {
            Vector3 pos = this._optionsScreen.transform.position;
            
            this._hudParent.DOMove(new Vector3(-pos.x, -pos.y, 0), 0.5f);
        }

        public void OpenCredits()
        {
            Vector3 pos = this._creditsScreen.transform.position;
            
            this._hudParent.DOMove(new Vector3(-pos.x, -pos.y, 0), 0.5f);
        }
        
        public void ReturnToMenu()
        {
            this._hudParent.transform.DOMove(new Vector3(0, 0, 0), 0.5f);
        }
        
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}