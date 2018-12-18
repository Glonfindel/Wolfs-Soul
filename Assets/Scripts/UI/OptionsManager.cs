using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour {

    public Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;
    public Dropdown qualityDropdown;
    public Dropdown aliasingDropdown;
    public Toggle vsyncToggle;
    public Dropdown textureQualityDropdown;
    public Slider musicSlider;
    public Slider soundSlider;

    Resolution[] resolutions;

    void Start()
    {
        Screen.fullScreen = PlayerPrefsX.GetBool("Fullscreen", Screen.fullScreen);
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality", QualitySettings.GetQualityLevel()));
        QualitySettings.antiAliasing = PlayerPrefs.GetInt("Aliasing", QualitySettings.antiAliasing);
        QualitySettings.vSyncCount = PlayerPrefsX.GetBool("Vsync", QualitySettings.vSyncCount != 0) ? 1 : 0;
        QualitySettings.masterTextureLimit = PlayerPrefs.GetInt("TextureQuality", QualitySettings.masterTextureLimit);
        qualityDropdown.value = PlayerPrefs.GetInt("Quality", QualitySettings.GetQualityLevel());
        qualityDropdown.RefreshShownValue();
        aliasingDropdown.value = PlayerPrefs.GetInt("Aliasing", QualitySettings.antiAliasing);
        aliasingDropdown.RefreshShownValue();
        fullscreenToggle.isOn = PlayerPrefsX.GetBool("Fullscreen", Screen.fullScreen);
        vsyncToggle.isOn = PlayerPrefsX.GetBool("Vsync", QualitySettings.vSyncCount != 0);
        textureQualityDropdown.value = PlayerPrefs.GetInt("TextureQuality", QualitySettings.masterTextureLimit);
        textureQualityDropdown.RefreshShownValue();
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = PlayerPrefs.GetInt("Resolution", currentResolutionIndex);
        Resolution resolution = resolutions[PlayerPrefs.GetInt("Resolution", currentResolutionIndex)];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        resolutionDropdown.RefreshShownValue();
        musicSlider.value = PlayerPrefs.GetFloat("Music", 0.5f);
        soundSlider.value = PlayerPrefs.GetFloat("Sound", 0.5f);
    }

    public void SetMusicVolume()
    {
        PlayerPrefs.SetFloat("Music", musicSlider.value);
    }

    public void SetSoundVolume()
    {
        PlayerPrefs.SetFloat("Sound", soundSlider.value);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("Resolution", resolutionIndex);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("Quality", qualityIndex);
    }

    public void SetTextureQuality(int textureQualityIndex)
    {
        QualitySettings.masterTextureLimit = textureQualityIndex;
        PlayerPrefs.SetInt("TextureQuality", textureQualityIndex);
    }

    public void SetAliasing(int aliasingIndex)
    {
        QualitySettings.antiAliasing = 1 << aliasingIndex;
        PlayerPrefs.SetInt("Aliasing", 1 << aliasingIndex);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefsX.SetBool("Fullscreen", isFullscreen);
    }

    public void SetVsync(bool isVsync)
    {
        QualitySettings.vSyncCount = isVsync ? 1 : 0;
        PlayerPrefsX.SetBool("Vsync", isVsync);
    }

}
