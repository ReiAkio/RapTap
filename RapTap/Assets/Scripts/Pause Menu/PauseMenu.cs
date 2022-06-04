using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject cfgMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject ClickArea;

    public void Resume()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        ClickArea.SetActive(true);
    }

    public void Quit()
    {
        //Application.Quit();   (CORRETO)
        UnityEditor.EditorApplication.isPlaying = false; // (PROVISÓRIO) Para funcionar no editor
    }

    public void Open_Configs()
    {
        cfgMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }
}
