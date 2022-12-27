using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Links : MonoBehaviour
{
    [SerializeField] public GameObject start;
    [SerializeField] public GameObject credits;
    private bool isCredits = false;
    public void loadCredits()
    {
        if (isCredits)
        {
            start.SetActive(true);
            credits.SetActive(false);
            isCredits = false;
        }
        else
        {
            start.SetActive(false);
            credits.SetActive(true);
            isCredits = true;
        }
    }
    public void Intro()
    {
        Application.OpenURL("https://www.free-stock-music.com/electronic-senses-fast-and-intense.html");
    }
    public void Stone()
    {
        Application.OpenURL("https://www.free-stock-music.com/punch-deck-civilization-fallen.html");
    }
    public void Medieval()
    {
        Application.OpenURL("https://www.free-stock-music.com/alexander-nakarada-medieval-loop-one.html");
    }
    public void Desert()
    {
        Application.OpenURL("https://www.free-stock-music.com/alexander-nakarada-the-desert.html");
    }
    public void Ice()
    {
        Application.OpenURL("https://www.free-stock-music.com/alexander-nakarada-cold-journey.html");
    }
    public void Dino()
    {
        Application.OpenURL("https://www.free-stock-music.com/glitch-jungle-journey.html");
    }
}
