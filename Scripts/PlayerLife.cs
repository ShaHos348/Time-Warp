using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] AudioSource deathSoundEffect;

    [SerializeField] Transform player;
    [SerializeField] Transform playerSpawn;

    [SerializeField] Image life1;
    [SerializeField] Image life2;
    [SerializeField] Image life3;
    private int lifes = 3;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        deathSoundEffect.Play();
        if(lifes == 3)
        {
            lifes--;
            life3.enabled = false;
            anim.SetTrigger("death");
        }else if (lifes == 2)
        {
            lifes--;
            life2.enabled = false;
            anim.SetTrigger("death");
        }
        else if(lifes == 1)
        {
            lifes--;
            life1.enabled = false;
            anim.SetTrigger("death");
        }
        else
        {
            GameOver();
        }
    }
    private void Respawn()
    {
        player.transform.position = playerSpawn.transform.position;
        rb.bodyType = RigidbodyType2D.Dynamic;
        anim.SetTrigger("spawn");

    }
    private void GameOver()
    {
        gameManager.updateHighScore();
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings-1);
    }
}
