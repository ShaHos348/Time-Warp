using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class TimePause : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] GameObject enemy;

    private Rigidbody2D rb;
    private BoxCollider2D br;
    private Animator ani;

    private Animator anim;
    private Rigidbody2D prb;
    private bool stop;

    [SerializeField] private Text Score;
    [SerializeField] private AudioSource stopSound;
    [SerializeField] private Slider slider;

    private bool freeze = false;

    void Start()
    {
        slider.value = 1;
        rb = enemy.GetComponent<Rigidbody2D>();
        br = enemy.GetComponent<BoxCollider2D>();
        ani = enemy.GetComponent<Animator>();
        anim = GetComponent<Animator>();
        prb = GetComponent<Rigidbody2D>();
        stop = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && stop)
        {
            stop = false;
            StartCoroutine(subTime());
            stopSound.Play();
            impact();
        }
        if (PauseMenu.isGamePaused)
        {
            freeze = true;
        }
        else 
        { 
            freeze = false; 
        }
    }

    private void impact()
    {
        stopSound.Play();
        rb.bodyType = RigidbodyType2D.Static;
        br.enabled = false;
        ani.enabled = false;
        prb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("time");
        Invoke("part2", 4);
    }

    public void part2()
    {
        anim.SetTrigger("spawn");
        prb.bodyType = RigidbodyType2D.Dynamic;
        checkName();
        Invoke("part3", 10);
    }

    public void part3()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        br.enabled = true;
        ani.enabled = true;
    }

    IEnumerator subTime()
    {
        for(slider.value = 1; slider.value > 0; slider.value -= 0.25f)
        {
            if (freeze) { slider.value += 0.25f; }
            yield return new WaitForSeconds(1);
        }
        StartCoroutine(addTime());
    }

    IEnumerator addTime()
    {
        for (slider.value = 0; slider.value < 1; slider.value += 0.03125f)
        {
            if (freeze) { slider.value -= 0.03125f; }
            yield return new WaitForSeconds(1);
        }
        stop = true;
    }

    private void checkName()
    {
        if(enemy.name == "caveman")
        {
            gameManager.addPoints(10);
        }
        else if (enemy.name == "knight")
        {
            gameManager.addPoints(50);
        }
        else if (enemy.name == "mummy")
        {
            gameManager.addPoints(100);
        }
        else if (enemy.name == "sabertooth")
        {
            gameManager.addPoints(250);
        }
        else
        {
            gameManager.addPoints(500);
        }
    }
}
