using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;

    [SerializeField] public GameObject pauseMenuUI;
    [SerializeField] public Transform enemy;
    [SerializeField] public Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        isGamePaused = false;
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        System.Console.WriteLine("Quitting Application");
        System.Console.ReadLine();
        Application.Quit();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        enemy.transform.position = player.transform.position;
    }
}
