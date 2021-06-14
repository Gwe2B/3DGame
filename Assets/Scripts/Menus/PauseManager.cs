using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Managers
{
    public class PauseManager : MonoBehaviour
    {
        public static PauseManager PM = null;

        public GameObject PauseOverlay = null;

        private bool isPaused = false;

        private void Start()
        {
            if (PM == null) { PM = this; }
            else { Destroy(this); }
        }

        public void TogglePause()
        {
            if (isPaused) { Resume(); }
            else { Pause(); }
        }

        private void Pause()
        {
            isPaused = true;
            Time.timeScale = 0f;
            PauseOverlay.SetActive(true);
        }

        public void Resume()
        {
            isPaused = false;
            Time.timeScale = 1f;
            PauseOverlay.SetActive(false);
        }

        public void BackTitleScreen() { Resume(); SceneManager.LoadScene("TitleMenu"); }
    }
}