using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Pausemenu : MonoBehaviour
{

    public GameObject PauseUI; // Creem el gameobject dins del codi anomenat PauseUI

    private bool paused = false; //Iniciem el mode pause en false

    void start()
    {
        PauseUI.SetActive(false); //Quan s'inicia l'aplicació el menu esta en modo false per tant no apareix.
    }

    void update()
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
}