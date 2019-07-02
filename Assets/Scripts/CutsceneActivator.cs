using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneActivator : MonoBehaviour
{
    public PlayableDirector playableDirector;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //When flag hits the ground, cutscene is played
        if (collision.gameObject.tag == "Tiles")
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            playableDirector.Play();
        }
    }
}
