using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    public GameObject pauseScreen;
    public string levelselect, mainmenu;
    public bool isPaused;

    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            PauseUnPause();
        }
    }
    public void PauseUnPause()
    {
        if (isPaused)
        {
            isPaused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;

        }
        else
        {
            isPaused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0;

        }
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene(levelselect);
        Time.timeScale = 1f;

    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainmenu);
        Time.timeScale = 1f;

    }

}
