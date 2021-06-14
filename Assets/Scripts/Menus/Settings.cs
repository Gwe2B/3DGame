using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using UnityEngine.InputSystem;

public class Settings : MonoBehaviour
{
    public Toggle FullScreenToggle;
    public Dropdown resolutionDropdown;
    public Transform screen;

    private Resolution[] resolutions;

    private void Start()
    {
        // FullScreen initialization
        FullScreenToggle.isOn = Screen.fullScreen;

        // Résolutions initialization
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].Equals(Screen.currentResolution)) { currentResolutionIndex = i; }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
    }

    public void SetResolution(int index)
    {
        Resolution res = resolutions[index];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    public void SetFullScreen(bool fullscreen) { Screen.fullScreen = fullscreen; }

    public void Return()
    {
        
        SceneManager.LoadScene("TitleMenu");
    }
}