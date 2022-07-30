using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBtt : MonoBehaviour
{
    [SerializeField] private AudioManager audioScript;

    [SerializeField] private GameObject cfgMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject ClickArea;
    [SerializeField] private GameObject MarketArea;

    public void Play_pause(bool play)
    {
        if (play)
        {
            pauseMenu.SetActive(true);
        }
        else
        {
            cfgMenu.SetActive(false);
        }
        pauseMenuPanel.SetActive(!play);
    }

    public void Quit()
    {
        Application.Quit();
        // UnityEditor.EditorApplication.isPlaying = false; // (PROVIS�RIO) Para funcionar no editor
    }

    public void Open_Configs()
    {
        cfgMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }
}
