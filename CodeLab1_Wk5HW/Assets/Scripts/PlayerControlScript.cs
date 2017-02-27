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

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        //Move(Vector3.up, upKey);
        //Move(Vector3.down, downKey);

        if (Input.GetKey(shiftKey))
        {
            Move(Vector3.left, leftKey, runSpeed);
            Move(Vector3.right, rightKey, runSpeed);
        }
        else
        {
            Move(Vector3.left, leftKey, walkSpeed);
            Move(Vector3.right, rightKey, walkSpeed);
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

	void Move(Vector3 dir, KeyCode key, float movementSpeed){
		if(Input.GetKey(key)){
			transform.Translate(dir * movementSpeed * Time.deltaTime);
		}

	}
}
