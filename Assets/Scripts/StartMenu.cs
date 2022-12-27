using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    public void StartGame()
    {
        gameManager.resetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void RestartGame()
    {
        gameManager.resetScore();
        SceneManager.LoadScene(0);
    }

    public void resetHighScore()
    {
        gameManager.reset();
    }

    public void Quit()
    {
        System.Console.WriteLine("Quitting Application");
        System.Console.ReadLine();
        Application.Quit();
    }
}
