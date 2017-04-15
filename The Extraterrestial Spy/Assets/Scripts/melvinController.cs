using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class melvinController : MonoBehaviour
{

    //Variables de moviment
  
    private Rigidbody2D rig;
    private bool right;
    private bool Xpressed;

    [SerializeField] //Variables que nomes poden sr modificades per certa funció
    public float movementSpeed;
    public float ganxoSpeed;
   

    void Start()
    {
        rig = GetComponent<Rigidbody2D>(); //Estalvi d'escriptura
        right = true; //El jugador sempre comença mirant cap a la dreta
    }


    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); //Rebem l'Input horitzontal del jugador
        float vertical = Input.GetAxis("Vertical"); //Rebrem l'input vertical del jugador

        //Funcions
        movimentMelvin(horizontal); //Moviment  
        flipsentitMelvin(horizontal);//Moviment - sentit
        ganxoMelvin(vertical);//Ganxo amb "x" 
        saltMelvin(vertical);//Salt amb "space"
    }
    //  -----------------------------------Funcions de moviment---------------------------------------------


    private void movimentMelvin(float horizontal) //Permet moure al jugador la seva posició X
    {

        rig.velocity = new Vector2(horizontal *movementSpeed, rig.velocity.y);

    }

    private void flipsentitMelvin(float horizontal)  //Permet canviar el sentit de moviment
    {
        if(horizontal > 0 && !right || horizontal <0 && right) 
        {
            right = !right;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale; //Canviem a negatiu la "scale" X de Melvin
        }
    }

    private void ganxoMelvin ( float vertical) //Permet moure al jugador la seva posició Y
    {
        int aux = 0;
        if (Input.GetKey("x") == true)
        {
            while (aux != 4)
            {
                {
                    rig.velocity = new Vector2(rig.velocity.x, vertical + 4);

                }

                aux++;
            }
        }
    }

    private void saltMelvin(float vertical) //Permet saltar al jugador, augment no-regular de X
    {
        if (Input.GetKeyDown("space")==true)
        {
            rig.velocity = new Vector2(rig.velocity.x, vertical + 3);
        }
    }
}