using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Libreria per gestionar les escenes


public class TriggerEvent : MonoBehaviour
{

   

    public void OnTriggerEnter2D(Collider2D other) //Quan es detecta una entrada contra un trigger 2D per part de l'objecte al que se li assigna el collider:
    {
        if (other.CompareTag("Player")) // Si el tag que entra dins el trigger es "PLAYER":
        {
            Debug.Log(" EXTRATERRESTIAL KILLED");
            SceneManager.LoadScene(0); //Carreguem el nivell de nou 

        }
    }

}
