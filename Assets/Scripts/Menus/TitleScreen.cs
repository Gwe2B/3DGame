using Assets.Scripts.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
    public class TitleScreen : MonoBehaviour
    {
        public void Play()
        {
            SceneManager.LoadScene("SampleScene");
            AudioManager.instance.Play("LevelStart");
        }

        public void Settings()
        {
            SceneManager.LoadScene("SettingsMenu");
            AudioManager.instance.Play("ClickUI");
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}