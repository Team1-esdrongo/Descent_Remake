using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject settingsCanvas;

    [Header("---Main Menu---")]
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private Button playBTN;
    [SerializeField] private Button settingsBTN;
    [SerializeField] private Button quitBTN;

    /*
    [Header("---Settings---")]
    [SerializeField] private TextMeshProUGUI settings;
    [SerializeField] private TextMeshProUGUI subTitle_1;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private TextMeshProUGUI subTitle_2;
    [SerializeField] private Slider sensitivitySlider;
    [SerializeField] private Button backToMainMenu;
    */

    private void Awake()
    {
        SetMainMenu(true);
        SetSettings(false);
    }

    public void OnPlayButton()
    {
        title.gameObject.SetActive(false);
        playBTN.gameObject.SetActive(false);
        settingsBTN.gameObject.SetActive(false);
        quitBTN.gameObject.SetActive(false);
        SetSettings(false);
        SceneManager.LoadScene("SCN_Loading");
    }

    public void OnSettingsOpen()
    {
        SetMainMenu(false);
        SetSettings(true);
    }

    public void OnSettingsClosed()
    {
        SetMainMenu(true);
        SetSettings(false);
    }

    public void OnQuitButton()
    {
        Application.Quit();
        Debug.LogWarning("Game has been closed");
    }

    private void SetMainMenu(bool IsActive)
    {
        mainMenuCanvas.SetActive(IsActive);
        /*
        title.gameObject.SetActive(IsActive);
        playBTN.gameObject.SetActive(IsActive);
        settingsBTN.gameObject.SetActive(IsActive);
        quitBTN.gameObject.SetActive(IsActive);
        */
    }

    private void SetSettings(bool IsActive)
    {
        settingsCanvas.SetActive(IsActive);
        /*
        settings.gameObject.SetActive(IsActive);
        subTitle_1.gameObject.SetActive(IsActive);
        volumeSlider.gameObject.SetActive(IsActive);
        subTitle_2.gameObject.SetActive(IsActive);
        sensitivitySlider.gameObject.SetActive(IsActive);
        backToMainMenu.gameObject.SetActive(IsActive);
        */
    }
}
