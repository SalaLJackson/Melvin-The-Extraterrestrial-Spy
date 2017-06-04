using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MystMan : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D other) //Quan el gameobject que contingui aquest script detecti ->
    {
        

        if (other.gameObject.tag == ("Player")) //-> que un altre gameobject amb el tag "PLAYER" entri dins el seu trigger,
        {

            transform.Rotate(0, 180, 0);
            transform.Translate(-1, 0, 0);


            if(transform.position.x ==94)
            {
                Destroy(this);
            }

            AudioSource Scream = GetComponent<AudioSource>();
            Scream.Play();


        }
    }
}





