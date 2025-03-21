using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider sensitivitySlider;

    public static float MouseSensitivity { get; private set; } = 1f;

    private void Start()
    {
        // Load settings
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);
        sensitivitySlider.value = PlayerPrefs.GetFloat("Sensitivity", 1f);

        // Set methods to sliders event
        volumeSlider.onValueChanged.AddListener(SetVolume);
        sensitivitySlider.onValueChanged.AddListener(SetSensitivity);
    }

    public void SetVolume(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat("Volume", value);
        PlayerPrefs.Save();
    }

    public void SetSensitivity(float value)
    {
        MouseSensitivity = value;
        PlayerPrefs.SetFloat("Sensitivity", value);
        PlayerPrefs.Save();
    }
}
