using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Libreria per gestionar les escenes

public class TriggerNextLevel : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D other) //Quan el gameobject que contingui aquest script detecti ->
    {
        if (other.CompareTag("Player")) //-> que un altre gameobject amb el tag "PLAYER" entri dins el seu trigger,
        {
            
            SceneManager.LoadScene(1);  // Carregarem el seguent nivell enumerat 1 dins l'ordre de build de nivells.

        }
    }
}


