using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject enemy;

    private Rigidbody2D ene;

    private AudioSource finishSound;

    private bool levelCompleted = false;

    private Animator anim;

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        ene = enemy.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            ene.bodyType = RigidbodyType2D.Static;
            finishSound.Play();
            anim.SetTrigger("warp");
            levelCompleted = true;
            Invoke("CompleteLevel", 3f);
        }
    }

    private void CompleteLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 3)
        {
            gameManager.updateHighScore();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
