using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideScript : MonoBehaviour {

    public bool isTouchingRock;

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTouchingRock = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTouchingRock = false;
        }
    }
	
	// Update is called once per frame
	void Update () {

        Debug.Log("isTouchingRock " + isTouchingRock);


		
	}
}
