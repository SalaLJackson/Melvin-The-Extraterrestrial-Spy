using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalZone : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")) 
        {
            Debug.Log("METAL");

            
                AudioSource MetlaZone = GetComponent<AudioSource>();
                MetlaZone.Play();
            


        }
    }
}

