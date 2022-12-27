using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titles : MonoBehaviour
{
    private Canvas title;

    public void Start()
    {
        title = GetComponent<Canvas>();
        title.enabled = true;
        Invoke("Vanish",3);
    }

    public void Vanish()
    {
        title.enabled = false;
    }
}
