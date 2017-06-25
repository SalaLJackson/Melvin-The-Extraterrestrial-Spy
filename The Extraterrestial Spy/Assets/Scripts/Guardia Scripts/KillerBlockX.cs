using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerBlockX : MonoBehaviour
{

    private float useSpeed;
    public float directionSpeed = 9.0f;
    float origX;
    public float distance = 5.0f;


    void Start()
    {
        origX = transform.position.x;
        useSpeed = -directionSpeed;
    }


    void Update()
    {
        if (origX - transform.position.x > distance)
        {
            useSpeed = directionSpeed; //flip direction
        }
        else if (origX - transform.position.x < -distance)
        {
            useSpeed = -directionSpeed; //flip direction
        }
        transform.Translate(useSpeed * Time.deltaTime, 0, 0);




    }
}