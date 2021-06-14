using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
    public class TitleScreen : MonoBehaviour
    {
        public void Play()
        {
            SceneManager.LoadScene("SampleScene");
        }

        public void Settings()
        {
            SceneManager.LoadScene("SettingsMenu");
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}