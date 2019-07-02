using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GoalPole : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public GameObject flag;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playableDirector.Play();
            collision.collider.GetComponent <PlayerController>().FinishLevel();
            //flag.GetComponent<Rigidbody2D>().velocity = 0;
            flag.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

            //collision.gameObject.GetComponent<Rigidbody2D>().constraints =
            //    RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

            //PlayerController controller = collision.gameObject.GetComponent<PlayerController>();
            //controller.takeAwayControll = false;
            //controller.maxVerticalSpeed = 6;
            //playerAnimator.SetBool("turning", true);
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
