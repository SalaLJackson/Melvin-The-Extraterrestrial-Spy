using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AscensorX : MonoBehaviour
{
    //RIGIDBODY -> NO DESFIXAR LA Y
    private float useSpeed;
    public float directionSpeed = 9.0f;
    float origX;
    public float distance = 5.0f;


    void Start()
    {
        origX = transform.position.x; //Posició original
        useSpeed = -directionSpeed;
    }


    void Update()
    {
        if (origX - transform.position.x > distance)
        {
            useSpeed = directionSpeed; //flip 
        }
        else if (origX - transform.position.x < -distance)
        {
            useSpeed = -directionSpeed; //flip 
        }
        transform.Translate(useSpeed * Time.deltaTime, 0, 0);




    }

    public void OnCollisionEnter2D(Collision2D coll) //Adaptar la velocitat (X,Y) en caiguda per evitar efecte de caiguda
    {

        if (coll.gameObject.tag == "Player")
        {

            coll.gameObject.transform.Translate(useSpeed * Time.deltaTime, 0, 0);
        }
    }

    public void OnCollisionStay2D(Collision2D coll) //Adaptar la velocitat (X,Y) en caiguda per evitar efecte de caiguda
    {
      
        if (coll.gameObject.tag == "Player")
        {

            coll.gameObject.transform.Translate(useSpeed * Time.deltaTime, 0, 0);
        }
    }

    public void OnCollisionExit2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "Player")
        {
            coll.gameObject.transform.Translate(useSpeed * Time.deltaTime, 0, 0);
        }
    }

}