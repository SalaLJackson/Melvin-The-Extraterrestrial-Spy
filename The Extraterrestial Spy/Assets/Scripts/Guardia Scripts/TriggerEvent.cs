using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TriggerEvent : MonoBehaviour
{

   

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(" EXTRATERRESTIAL DETECTED");
            SceneManager.LoadScene(0);
            
        }
    }

}
