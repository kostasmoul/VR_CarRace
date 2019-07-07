using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphere : MonoBehaviour {

    // Use this for initialization
    private bool moveLeft, moveRight;

	void Start () {
        moveLeft = true;
        moveRight = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(moveLeft)
        {
            if(transform.position.z > -15.0f)
            {
                transform.Translate(Vector3.back * Time.deltaTime * 5.5f);
            }
            else
            {
                moveLeft = false;
                moveRight = true;
            }
            

        }

        if(moveRight)
        {
            if(transform.position.z  < -4.0f)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * 5.5f);
            }
            else
            {
                moveLeft = true;
                moveRight = false;
            }
        }
        
    }
}
