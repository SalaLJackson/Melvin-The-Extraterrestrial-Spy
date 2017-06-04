using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletSound : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D other) //Quan el gameobject que contingui aquest script detecti ->
    {
        if (other.CompareTag("Player")) //-> que un altre gameobject amb el tag "PLAYER" entri dins el seu trigger,
        {

            AudioSource ToiletFlush= GetComponent<AudioSource>();
            ToiletFlush.Play();

        }
    }
}
