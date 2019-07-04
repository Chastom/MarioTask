﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "Tiles")
        {
            transform.parent.GetComponent<GoalPole>().FlagCollided();
        }
    }
}
