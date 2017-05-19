using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AscensorY : MonoBehaviour
{
    //RIGIDBODY -> NO DESFIXAR LA Y
    private float useSpeed;
    public float directionSpeed = 9.0f;
    float origY;
    public float distance = 5.0f;
    int delay;


    void Start()
    {
        origY = transform.position.y; //Posició original
        useSpeed = -directionSpeed;
        delay = 3;
    }


    void Update()
    {
        if (origY - transform.position.y > distance)
        {
            useSpeed = directionSpeed; //flip 
        }
        else if (origY - transform.position.y < -distance)
        {
            //yield return new WaitForSeconds(delay);
            useSpeed = -directionSpeed; //flip 
        }
        transform.Translate(0, useSpeed * Time.deltaTime, 0);




    }

    public void OnCollisionEnter2D(Collision2D coll) //Adaptar la velocitat (X,Y) en caiguda per evitar efecte de caiguda
    {
        Debug.Log("Player enters platform");
        if (coll.gameObject.tag == "Player")
        {

            coll.gameObject.transform.Translate(0, useSpeed * Time.deltaTime, 0);
        }
    }

    public void OnCollisionStay2D(Collision2D coll) //Adaptar la velocitat (X,Y) en caiguda per evitar efecte de caiguda
    {
        Debug.Log("Player on platform");
        if (coll.gameObject.tag == "Player")
        {

            coll.gameObject.transform.Translate(0, useSpeed * Time.deltaTime, 0);
        }
    }

    public void OnCollisionExit2D(Collision2D coll)
    {
        Debug.Log("Player exit platform");

        coll.gameObject.transform.Translate(0, useSpeed * Time.deltaTime, 0);

    }

}