using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPole : MonoBehaviour
{
    public GameObject flag;
    public TimelineController timelineController;
    public ScoreManager scoreManager;

    //Mario and flag "slidding" down activation 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().Play();

            collision.collider.GetComponent<PlayerController>().LvlFinished(); //Telling player object about finished level
            scoreManager.SetFinishTime(); //Fixating time when Mario jumps on the pole

            flag.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    //When flag hits the ground, cutscene is played
    public void FlagCollided()
    {
        flag.GetComponent<BoxCollider2D>().enabled = false;
        flag.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;

        timelineController.PlayCutscene();

        //Waiting for cutscene to playout before calling the next one
        timelineController.Invoke("PlayFireworks", 5.9f);               
    } 
}
