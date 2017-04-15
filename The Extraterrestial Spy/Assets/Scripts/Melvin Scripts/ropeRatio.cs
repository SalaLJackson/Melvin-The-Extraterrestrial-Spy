using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ropeRatio : MonoBehaviour
{
    public GameObject player;
    public Vector3 grabPosition;
    public float ratio;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float scaleX=Vector3.Distance(player.transform.position,grabPosition)/ratio;
        GetComponent<LineRenderer>().material.mainTextureScale = new Vector2(scaleX, 1f);
	}
}
