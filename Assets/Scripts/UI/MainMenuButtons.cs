using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Developer.Michel.Scripts.UI
{
    public sealed class MainMenuButtons : MonoBehaviour
    {
        [Header("Play game")]
        [SerializeField] private SceneAsset playSceneAsset;
        
        [Header("Options")]
        [SerializeField] private Animation optionsAnimation;
        
        public void PlayGame()
        {
            SceneManager.LoadScene(this.playSceneAsset.name, LoadSceneMode.Single);
        }

        public void OpenOptions()
        {
            optionsAnimation.Play();
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}