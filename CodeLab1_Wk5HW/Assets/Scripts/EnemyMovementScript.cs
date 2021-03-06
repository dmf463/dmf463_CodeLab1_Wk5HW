﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{

    public float speed;

    GameObject deer;

    PlayerControlScript playerControlScript;

    Animator anim;

    bool deerIsDead = false;

 

    // Use this for initialization
    void Start()
    {
        deer = GameObject.Find("Player");
        playerControlScript = deer.GetComponent<PlayerControlScript>();
        anim = deer.GetComponent<Animator>();
    }

    void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.tag == "Beginning" || other.gameObject.tag == "End")
        {
            speed *= -1;
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        hunterMove(Vector3.left, speed);

        //Debug.Log("Distance between Hunter and Deer = " + Vector3.Distance(transform.position, deer.transform.position));

        if (Vector3.Distance(transform.position, deer.transform.position) < 5 && deerIsDead == false && playerControlScript.isHiding == false)
        {
            Debug.Log("I SEE YOU");
            speed = 0;
            playerControlScript.walkSpeed = 0;
            playerControlScript.runSpeed = 0;
            deerIsDead = true;
            Debug.Log("deerIsDead = " + deerIsDead);
            anim.SetBool("isDead", true);
        }
    }

    void hunterMove(Vector3 dir, float movementSpeed)
    {
        transform.Translate(dir * movementSpeed * Time.deltaTime);
    }


}
