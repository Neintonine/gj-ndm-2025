using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Developer.Michel.Scripts.UI
{
    public sealed class MainMenuButtons : MonoBehaviour
    {
        [Header("Play game")]
        [SerializeField] private SceneAsset playSceneAsset;
        
        public void PlayGame()
        {
            SceneManager.LoadScene(this.playSceneAsset.name, LoadSceneMode.Single);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}