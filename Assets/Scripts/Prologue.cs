using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Prologue : MonoBehaviour
{
    private Animator anim;
    private AudioSource portalSound;
    [SerializeField] private GameObject bar;
    [SerializeField] private Image staff;
    private GameObject player;

    private void Start()
    {
        portalSound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        bar.SetActive(false);
        staff.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player = collision.gameObject;
            anim.SetTrigger("take");
            bar.SetActive(true);
            staff.enabled = true;
            Invoke("part2", 2);
        }
    }

    public void part2()
    {
        portalSound.Play();
        anim.SetTrigger("open");
        Invoke("part3", 2);
    }

    public void part3()
    {
        player.SetActive(false);
        Invoke("Skip", 1);
    } 

    public void Skip()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
