using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;

public class Options : MonoBehaviour {

    public Toggle fullscreenToggle;
    public TMP_Dropdown graphicsDropdown;
    public Resolution[] resolutions;
    public TMP_Dropdown resolutionsDropdown;
    public Slider volumeSlider;
    public AudioMixer audioMixer;
    public Button back;

    public void Start() {
        fullscreenToggle = GameObject.Find("FullscreenToggle").GetComponent<Toggle>();
        fullscreenToggle.onValueChanged.AddListener(SetFullscreen);
        fullscreenToggle.isOn = GameManager.isFullscreen;

        graphicsDropdown = GameObject.Find("GraphicsDropdown").GetComponent<TMP_Dropdown>();
        graphicsDropdown.ClearOptions();
        List<string> graphicsOptions = new List<string> {"Very Low", "Low", "Medium", "High", "Very High", "Ultra"};
        graphicsDropdown.AddOptions(graphicsOptions);
        SetQuality(GameManager.graphicsIndex);
        graphicsDropdown.value = GameManager.graphicsIndex;
        graphicsDropdown.onValueChanged.AddListener(SetQuality);

        resolutions = Screen.resolutions;
        resolutionsDropdown = GameObject.Find("ResolutionsDropdown").GetComponent<TMP_Dropdown>();
        resolutionsDropdown.ClearOptions();
        List<string> resolutionsOptions = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++) {
            resolutionsOptions.Add(resolutions[i].width + " x " + resolutions[i].height);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) {
                currentResolutionIndex = i;
            }
        }
        resolutionsDropdown.AddOptions(resolutionsOptions);
        resolutionsDropdown.value = GameManager.resolutionIndex == -1? currentResolutionIndex: GameManager.resolutionIndex;
        resolutionsDropdown.RefreshShownValue();
        resolutionsDropdown.onValueChanged.AddListener(SetResolution);

        volumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();
        volumeSlider.value = GameManager.volume;
        volumeSlider.onValueChanged.AddListener(SetVolume);

        back = GameObject.Find("BackButton").GetComponent<Button>();
        back.onClick.AddListener(Back);
    }
    public void SetFullscreen(bool isFullscreen) {
        GameManager.isFullscreen = isFullscreen;
        Screen.fullScreen = isFullscreen;
    }
    public void SetQuality(int index) {
        GameManager.graphicsIndex = index;
        QualitySettings.SetQualityLevel(index);
    }
    public void SetResolution(int index) {
        GameManager.resolutionIndex = index;
        Resolution resolution = resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetVolume(float volume) {
        GameManager.volume = volume;
        audioMixer.SetFloat("volume", volume);
    }
    public void Back() {
        SceneManager.LoadScene("Menu");
    }
}
