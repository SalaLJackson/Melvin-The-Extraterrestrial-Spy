using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAGuardies : MonoBehaviour {

    public Transform[] patrolpoints; // Array on els guarden els punts X de desplaçament del guardia
    int currentPoint; //Target del guardia, es cap a on anira
    public float speed; //Velocitat de desplaçament del guardia entre els punts dins la funcio MoveTowards
    public float Delay; // Delay que tindrà el guardia al arribar a l'extrem de l'array de desplaçament.

    Animator anim;
    
    void Start ()
    {

        StartCoroutine("Patrol"); //Iniciem la rutina patrol
        speed = 0.1f;
        Delay = 5f;
        anim = GetComponent<Animator>(); // Animator
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
                currentPoint++; // Quan s'arriba a la posició, actualitzem la posició acutal.
                anim.SetBool("walking", false); // Desactivem l'animació de Walking ja que el guardia entrarà en Delay durant Delay segons.
                yield return new WaitForSeconds(Delay); //Delay
                anim.SetBool("walking", true); // El jugador torna a caminar per tant activem l'animació de walking.

            }

            if(currentPoint >=patrolpoints.Length) //Si el target es igual a la size maxima de l'array, el target ara es la posicio 0 de l'array per tal de crear un bucle infinit de desplaçament.
            {
                currentPoint = 0;

            }

            transform.position = Vector2.MoveTowards(transform.position, new Vector2(patrolpoints[currentPoint].position.x, transform.position.y),  speed); //MoveTowards funció de desplaçament seguint un punt en concret.
            //La posicio es modificara segons la funcio MoveTowards(posició actual, nova posicio[target] y=0, velocitat de desplaçament);
            if (transform.position.x > patrolpoints[currentPoint].position.x)
            {
                transform.localScale = new Vector2(-1, 1); //Girem l'sprite.

            }

            else if(transform.position.x < patrolpoints[currentPoint].position.x)
            {
                transform.localScale = Vector2.one; //Girem l'sprite.
            }

            yield return null;
        }
    }
}





