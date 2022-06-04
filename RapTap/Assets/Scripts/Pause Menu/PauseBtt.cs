using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBtt : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject ClickArea;

    public void Enable_pause_menu()
    {
        Time.timeScale = 0f;
        ClickArea.SetActive(false);
        pauseMenuPanel.SetActive(true);

    }
}
