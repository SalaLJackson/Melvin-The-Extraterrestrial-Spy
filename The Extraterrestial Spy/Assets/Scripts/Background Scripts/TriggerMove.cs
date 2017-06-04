using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMove : MonoBehaviour {

    public int fallDistance;

    public void OnTriggerEnter2D(Collider2D other) //Quan el gameobject que contingui aquest script detecti ->
    {
        if (other.CompareTag("Player")) //-> que un altre gameobject amb el tag "PLAYER" entri dins el seu trigger,
        {
            Debug.Log("TRIGGERED");
            AudioSource Breaking = GetComponent<AudioSource>();
            Breaking.Play();

            transform.Translate(0, fallDistance, 0);

        }
    }
}



