using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlScript : MonoBehaviour {

	public float walkSpeed = 5;
    public float runSpeed = 10;

	public KeyCode upKey = KeyCode.W;
	public KeyCode downKey = KeyCode.S;
	public KeyCode leftKey = KeyCode.A;
	public KeyCode rightKey = KeyCode.D;
    public KeyCode shiftKey = KeyCode.RightShift;

    public GameObject[] rocks;

    Animator anim;

    public bool isReallyDead = false;
    GameObject rock;
    HideScript hidescript;

    public bool isHiding;

    // Use this for initialization
    void Start () {

        rocks = GameObject.FindGameObjectsWithTag("rock");

        anim = GetComponent<Animator>();

        rock = GameObject.FindGameObjectWithTag("rock");

        hidescript = rock.GetComponent<HideScript>();
	}
	
	// Update is called once per frame
	void Update () {
        //Move(Vector3.up, upKey);
        //Move(Vector3.down, downKey);

        if (Input.GetKey(shiftKey))
        {
            Move(Vector3.left, leftKey, runSpeed, "isRunning");
            Move(Vector3.right, rightKey, runSpeed, "isRunning");
        }
        else
        {
            Move(Vector3.left, leftKey, walkSpeed, "isWalking");
            Move(Vector3.right, rightKey, walkSpeed, "isWalking");
            anim.SetBool("isRunning", false);
        }

        Debug.Log("isHiding" + isHiding);

        if (Input.GetKey(downKey) && hidescript.isTouchingRock == true)
        {
            isHiding = true;
        }
        else
        {
            isHiding = false;
        }

        if (Input.GetKey(leftKey))
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(Input.GetKey(rightKey))
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
        }

        if (isReallyDead == true)
        {
            anim.SetBool("isDead", false);
            anim.SetBool("isReallyDead", true);
        }

	}

	void Move(Vector3 dir, KeyCode key, float movementSpeed, string animation){
		if(Input.GetKey(key))
        {
			transform.Translate(dir * movementSpeed * Time.deltaTime);
            anim.SetBool(animation, true);
		}

	}
}
