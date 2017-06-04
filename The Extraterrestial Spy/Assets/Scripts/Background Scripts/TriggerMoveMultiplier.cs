using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMoveMultiplier : MonoBehaviour {

    public float speedfall;

    public void OnCollisionStay2D(Collision2D other) //Quan el gameobject que contingui aquest script detecti ->
    {
        if (other.gameObject.tag ==("Player")) //-> que un altre gameobject amb el tag "PLAYER" entri dins el seu trigger,
        {
            
            AudioSource MoveCrunch = GetComponent<AudioSource>();
            MoveCrunch.Play();

            transform.Translate(speedfall, 0, 0);

        }
    }
}
