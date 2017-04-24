using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAGuardies : MonoBehaviour {

    public Transform[] patrolpoints; // Array on els guarden els punts X de desplaçament del guardia
    int currentPoint; //Target del guardia, es cap a on anira
    public float speed; //Velocitat de desplaçament del guardia entre els punts dins la funcio MoveTowards
    public float Delay;

    Animator anim;
    
    void Start ()
    {

        StartCoroutine("Patrol");
        speed = 0.1f;
        Delay = 5f;
        anim = GetComponent<Animator>();
        anim.SetBool("walking", true);
    }
	
	
	void FixedUpdate ()
    {

    }

    IEnumerator Patrol() //Update especific
    {
       while(true)
        {
            if (transform.position.x == patrolpoints[currentPoint].position.x) //Si la posicio es igual al target, target++. 0 -> 1
            {
                currentPoint++;
                anim.SetBool("walking", false);
                yield return new WaitForSeconds(Delay);
                anim.SetBool("walking", true);

            }

            if(currentPoint >=patrolpoints.Length) //Si el target es igual a la size maxima de l'array, el target ara es la posicio 0 de l'array.
            {
                currentPoint = 0;

            }

            transform.position = Vector2.MoveTowards(transform.position, new Vector2(patrolpoints[currentPoint].position.x, transform.position.y),  speed);
            //La posicio es modificara segons la funcio MoveTowards(posició actual, nova posicio[target] y=0, velocitat de desplaçament);
            if (transform.position.x > patrolpoints[currentPoint].position.x)
            {
                transform.localScale = new Vector2(-1, 1);

            }

            else if(transform.position.x < patrolpoints[currentPoint].position.x)
            {
                transform.localScale = Vector2.one;
            }

            yield return null;
        }
    }
}





