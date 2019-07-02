using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPole : MonoBehaviour
{
    public GameObject flag;
    private AudioSource audioSource;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();

            collision.collider.GetComponent <PlayerController>().FinishLevel();
            
            flag.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
