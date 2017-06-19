﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour {

    public float moveSpeed = 0.0f;

    Animator anim;
    Rigidbody2D RB;
    public static bool playerContact = false;
    enemyDamage enemyDMG;

    // Use this for initialization
    void Start () {
        anim = gameObject.GetComponent<Animator>();
        RB = gameObject.GetComponent<Rigidbody2D>();

        enemyDMG = gameObject.GetComponent<enemyDamage>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "Monster")
        {
            if (enemyDMG.contact)
            {
                playerContact = true;
                anim.SetInteger("State", 0);
            }
            else
                anim.SetInteger("State", 1);

        }
        if(playerContact&& gameObject.tag == "Player")
            anim.SetInteger("State", 0);
        else
            anim.SetInteger("State", 1);

    }
    void FixedUpdate () {
        if (gameObject.tag == "Player")
        {
            if(!playerContact)
            {
                RB.velocity = new Vector2(moveSpeed, RB.velocity.y);
            }
        }
        else if (gameObject.tag == "Monster")
        {
            if (!enemyDMG.contact)
            {
                RB.velocity = new Vector2(-moveSpeed, RB.velocity.y);

            }
        }
    }


}