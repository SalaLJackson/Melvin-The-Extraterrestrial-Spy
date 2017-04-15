using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentMelvin : MonoBehaviour {

    public float moveSpeed=2.0f;
    Vector3 pos;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.A) && transform.position == pos)
        {        // Left
            pos += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D) && transform.position == pos)
        {        // Right
            pos += Vector3.right;
        }
        if (Input.GetKey(KeyCode.W) && transform.position == pos)
        {        // Up
            pos += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S) && transform.position == pos)
        {        // Down
            pos += Vector3.down;
        }
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * moveSpeed);    // Move there
    }
}

   


