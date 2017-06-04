using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSound : MonoBehaviour {

        void OnCollisionEnter2D(Collision2D other)
        {
            //Col·lisio el terra i so
            if (other.gameObject.tag == "Player")
            {
                AudioSource Slime = GetComponent<AudioSource>();
                Slime.Play();

            }
        }
    }