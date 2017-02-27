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

    Animator anim;

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
        //Move(Vector3.up, upKey);
        //Move(Vector3.down, downKey);

        if (Input.GetKey(shiftKey))
        {
            Move(Vector3.left, leftKey, runSpeed, null);
            Move(Vector3.right, rightKey, runSpeed, null);
        }
        else
        {
            Move(Vector3.left, leftKey, walkSpeed, "isWalking");
            Move(Vector3.right, rightKey, walkSpeed, "isWalking");
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
        }

//		if(Input.GetKey(KeyCode.W)){
////			Debug.Log("This is working");
//			transform.Translate(Vector3.up * speed * Time.deltaTime);
//		}
//
//		if(Input.GetKey(KeyCode.S)){
//			transform.Translate(Vector3.down * speed * Time.deltaTime);
//		}
	}

	void Move(Vector3 dir, KeyCode key, float movementSpeed, string animation){
		if(Input.GetKey(key))
        {
			transform.Translate(dir * movementSpeed * Time.deltaTime);
            anim.SetBool(animation, true);
		}

	}
}
