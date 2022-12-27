using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] public Text Score;
    [SerializeField] public Text HighScore;
    void Start()
    {
        Score.text = PlayerPrefs.GetInt("Score", 0).ToString("D6");
        HighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString("D6");
    }

    public void addPoints(int points)
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + points);
        Score.text = PlayerPrefs.GetInt("Score", 0).ToString("D6");
    }

    public void updateHighScore()
    {
        if(PlayerPrefs.GetInt("Score")> PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
            HighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString("D6");
            Score.text = PlayerPrefs.GetInt("Score", 0).ToString("D6");
        }
    }
    public void resetScore()
    {
        PlayerPrefs.SetInt("Score", 0);
        Score.text = PlayerPrefs.GetInt("Score").ToString("D6");
    }
    public void reset()
    {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("HighScore", 0);
        Score.text = PlayerPrefs.GetInt("Score").ToString("D6");
        HighScore.text = PlayerPrefs.GetInt("HighScore").ToString("D6");
    }
}
