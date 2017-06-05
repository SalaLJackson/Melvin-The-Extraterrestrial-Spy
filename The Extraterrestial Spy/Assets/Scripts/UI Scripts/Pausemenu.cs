using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Libreria per gestionar les escenes



public class Pausemenu : MonoBehaviour
{

    public GameObject PauseUI; // Creem el gameobject dins del codi anomenat PauseUI

    private bool paused = false; //Iniciem el mode pause en false

    private int actualScene;

   

    

    void Start()
    {
        PauseUI.SetActive(false); //Quan s'inicia l'aplicació el menu esta en modo false per tant no apareix.
        actualScene = 0;
        
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //Quan premem ESC, el mode pause canvia de false i s'activa el menu ja que el mode es true.
        {
            paused = !paused;
        }

        if (paused) //Si el mode pause es true, activem el menu i parem el temps amb la funcio Time.timeScale.
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (!paused) //Si el mode pause es diferent de true, desactivem el menu i tornem a acivar el temps amb la funcio Time.timeScale.
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void OnTriggerEnter2D(Collider2D other) //Quan es detecta una entrada contra un trigger 2D per part de l'objecte al que se li assigna el collider:
    {
        if (other.gameObject.tag == ("EndOfLevel")) // Si el tag que entra dins el trigger es "PLAYER":
        {
            Debug.Log("LEVEL++");
            actualScene++;

        }


    }
  

    public void Resume()
    {
        paused = false;
    }

    public void Restart()
    {
        
            paused = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void MainMenu()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadLeve3()
    {
        SceneManager.LoadScene(2);
    }
}

