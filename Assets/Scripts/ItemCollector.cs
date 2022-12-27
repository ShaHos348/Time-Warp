using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioSource itemCollectingSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            Destroy(collision.gameObject);
            gameManager.addPoints(1);
            itemCollectingSound.Play();
        }
        if (collision.gameObject.CompareTag("Artifact"))
        {
            Destroy(collision.gameObject);
            gameManager.addPoints(5);
            itemCollectingSound.Play();
        }
        if (collision.gameObject.CompareTag("Tusk"))
        {
            Destroy(collision.gameObject);
            gameManager.addPoints(20);
            itemCollectingSound.Play();
        }
        if (collision.gameObject.CompareTag("Amber"))
        {
            Destroy(collision.gameObject);
            gameManager.addPoints(25);
            itemCollectingSound.Play();
        }
        if (collision.gameObject.CompareTag("Sphinx"))
        {
            Destroy(collision.gameObject);
            gameManager.addPoints(15);
            itemCollectingSound.Play();
        }
    }
}
