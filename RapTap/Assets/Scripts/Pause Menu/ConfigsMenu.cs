using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Experimental.Rendering.Universal;

public class ConfigsMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    public AudioMixer mainMixer;

    public Dropdown resolDropdown;
    public Dropdown qualityDropdown;

    Resolution[] resolutions;

    public VolumeProfile vProf;
    private ColorAdjustments colAdj;
    public Light2D globalLight;
    public Light2D lampPostLight;

    void Start()
    {
        if (vProf.TryGet<ColorAdjustments>(out colAdj) == false)
            Debug.Log("Color Adjustments fail");

        resolutions = Screen.resolutions;
        int currentResol = 0;

        resolDropdown.ClearOptions();

        List<string> options = new List<string>();

        for(int i=0; i<resolutions.Length; i++)
        {
            options.Add(resolutions[i].width + " x " + resolutions[i].height);

            if(resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResol = i;
            }
        }

        resolDropdown.AddOptions(options);
        resolDropdown.value = currentResol;
        resolDropdown.RefreshShownValue();

        qualityDropdown.value = (QualitySettings.GetQualityLevel() - 1)/2;
        qualityDropdown.RefreshShownValue();
    }

    public void SetSaturation (float saturationValue)
    {
        colAdj.saturation.value = saturationValue;
    }

    public void SetBrightness (float brightnessValue)
    {
        globalLight.intensity = brightnessValue;
        lampPostLight.intensity = brightnessValue;
    }

    public void SetContrast (float contrastValue)
    {
        colAdj.contrast.value = contrastValue;
    }

    public void SetMasterVolume(float volume)
    {
        mainMixer.SetFloat("masterVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        mainMixer.SetFloat("musicVolume", volume);
    }

    public void SetSFX_Volume(float volume)
    {
        mainMixer.SetFloat("sfxVolume", volume);
    }

    public void SetResolution(int resIndex)
    {
        Resolution res = resolutions[resIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex * 2 + 1);
    }

    public void Back_Button()
    {
        pauseMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
