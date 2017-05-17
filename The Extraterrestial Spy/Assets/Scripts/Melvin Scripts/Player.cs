using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // Creem la variable que emmagatzemarà el collider 2D.
    private BoxCollider2D boxCol;

    // Creem la variable que emmagatzemarà el RigidBody que utilitzarem en el nostre programa
    // tenint en compte que només hem creat la variable i aquesta encara no referencia a cap objecte.
    private Rigidbody2D myRigidBody;

    // Creem la variable que emmagatzemarà l'Animator que utilitzarem en el nostre programa.
    private Animator myAnimator;

    // Determina la velocitat del nostre personatge. A més a més, gràcies a SerializeField podem modificar el valor "speed" directament des de Unity.
    [SerializeField]
    private float speed;

    // Determina si el jugador esta tocant un sostre o terra.
    private bool canCrouch;

    // Determina si el jugador mira cap a la dreta o cap a l'esquerra.
    private bool facingRight;

    // Variable que guardarà el valors dels inputs horitzontals.
    float horizontal;

    // Variable que determina si el jugador està en contacte amb el sostre.
    bool isCeiling;

    // Variable que determina si el jugador toca una paret.
    bool isWall;

    // Variable que determina si el jugador toca el terra.
    bool isFloor;

    // Variable que guarda les magnituds del collider.
    float normalSizeX = 0.8991379f;
    float normalSizeY = 1.15f;

    // Variable que guarda en quan es redueix la hitbox al ajupir-se.
    float crouchSizeY = 0.5f;

    // Variable que determina si el jugador està ajupit
    bool isCrouch;

    // Variable que determina el temps que el jugador es a l'aire
    float airTime;
    bool airTrigger;
    const float fallMinimum=0.5f;

    // Variable que determina l'estat del "crouch"
    bool crouchState;

    // Variable que determina si el jugador es pot aixecar
    bool cantGetUp;

    // Use this for initialization
    void Start ()
    {
        boxCol = GetComponent<BoxCollider2D>();
        facingRight = true; // Al iniciar el joc, el jugador sempre mira a la dreta.
        myRigidBody = GetComponent<Rigidbody2D>(); // Ara inicialitzem la variable fent que aquesta referencii a un RigidBody, per tant, ja la podem modificar.
        myAnimator = GetComponent < Animator>(); // Inicialitzem la variable per a accedir a l'animator.
        isCeiling = false;
        isCrouch = false;
        crouchState = false;
        airTrigger = true;
        cantGetUp = false;
        //Physics2D.gravity *= -1;
    }
	
	// Update is called once per frame --> A no ser que canviem Update per FixedUpdate, el qual fixa cada quant es crida a la funció evitant així errors entre diferents PCs.
	void FixedUpdate ()
    {
        if (!GameObject.Find("Player").GetComponent<grapplingHook>().ganxo)
        {
            horizontal = Input.GetAxis("Horizontal"); // Edit/ProjectSettings/Input per a accedir al "llistat d'Inputs". Podem utilitzar Debug.Log(horizontal) per a debugar.
            handleMovement(horizontal);
            horizontalFlip(horizontal);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                GameObject.Find("Player").GetComponent<grapplingHook>().joint.distance++;
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                GameObject.Find("Player").GetComponent<grapplingHook>().joint.distance--;
            }
        }

        // Si la tecla E es prem i el personatge es al sostre
        if (Input.GetKeyDown(KeyCode.E) && isCeiling==true)
        {
            Physics2D.gravity *= -1;
            isCeiling = false;
            verticalFlip();
        }
        checkAir();
        checkCrouch();
    }

    // Funció que s'encarrega del moviment del nostre jugador.

    
    private void handleMovement(float horizontal)
    {
        myRigidBody.velocity = new Vector2(horizontal * speed, myRigidBody.velocity.y); // x=InputHoritzontal * speed ,y=0  Ens movem cap a la dreta o esquerra amb la velocitat definida per "speed".
        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
    }

    // Funció que girarà l'sprite del jugador (horitzontalment).
    private void horizontalFlip(float horizontal)
    {
        if ((horizontal>0 && !facingRight) || (horizontal<0 && facingRight))
        {
            facingRight = !facingRight; // facingRight = El contrari de facingRight.
            Vector3 scale = transform.localScale;
            scale.x = scale.x * (-1); // Girem l'sprite.
            transform.localScale = scale;
        }
    }

    // Funció que girarà l'sprite del jugador(verticalment).
    private void verticalFlip()
    {
        Vector3 scale = transform.localScale;
        scale.y = scale.y * (-1);
        transform.localScale = scale;
    }

    // Funció cridada al produir-se una col·lisió.
    void OnCollisionEnter2D(Collision2D coll)
    {
        //Col·lisio amb les coins
        if (coll.gameObject.tag == "Coin")
        {
            GameManager.Instance.CollectedCoins++;
            Destroy(coll.gameObject);
        }

        // Al col·lisionar amb el sostre, el nostre personatge es gira.
        if (coll.gameObject.tag== "Ceiling")
        {
            Debug.Log("enter ceiling");
            verticalFlip();
            Physics2D.gravity *= -1;
            isCeiling = true;
            canCrouch = false;
            // Si el jugador toca amb alguna d'aquestes col·lisions, ja no serà a l'aire.
            myAnimator.SetBool("isFall", false);
            airTrigger = true;
        }
        if (coll.gameObject.tag == "Floor")
        {
            isFloor = true;
            canCrouch = true;
            // Si el jugador toca amb alguna d'aquestes col·lisions, ja no serà a l'aire.
            myAnimator.SetBool("isFall", false);
            airTrigger = true;
        }
        if (coll.gameObject.tag == "Floor" && GameObject.Find("Player").GetComponent<grapplingHook>().ganxo)
        {
            GameObject.Find("Player").GetComponent<grapplingHook>().ganxo = !GameObject.Find("Player").GetComponent<grapplingHook>().ganxo;
            // Si el jugador toca amb alguna d'aquestes col·lisions, ja no serà a l'aire.
            myAnimator.SetBool("isFall", false);
            airTrigger = true;
        }
        if (coll.gameObject.tag == "Wall")
        {
            isWall = true;
            // Si el jugador toca amb alguna d'aquestes col·lisions, ja no serà a l'aire.
            myAnimator.SetBool("isFall", false);
            airTrigger = true;
        }
    }

    // Funció cridada al entrar en un trigger.
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "crouchZone")
        {
            cantGetUp = true;
        }
    }

    // Funció cridada al sortir d'un trigger.
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "crouchZone")
        {
            cantGetUp = false;
        }
    }

    // Funció cridada al sortir-se d'un collider.
    private void OnCollisionExit2D(Collision2D coll)
    {
        if (isCeiling == true)
        {
            Debug.Log("leave ceiling");
            isCeiling = false;
            Physics2D.gravity *= -1;
            Vector3 scale = transform.localScale;
            scale.y = Mathf.Abs(scale.y);
            transform.localScale = scale;
            transform.Translate (new Vector2(0, 1)); //NO CANVIAR (Evita bug gravetat)

        }
        if (coll.gameObject.tag == "Floor")
        {
            isFloor = false;
            canCrouch = false;
            myAnimator.SetBool("isCrouch", false);
            boxCol.size = new Vector3(normalSizeX, normalSizeY, 0);
            isCrouch = false;
        }
        if (coll.gameObject.tag == "Wall")
        {
            isWall = false;
        }
        // Si el jugador no toca ni un terrra, ni una paret, ni el sostre, significa que aquest serà a l'aire.
    }
    
    // Funció que tracta amb l'animador si el personatge cau.
    private void checkAir()
    {
        if (!isWall && !isFloor && !isCeiling && !GameObject.Find("Player").GetComponent<grapplingHook>().ganxo)
        {
            if (airTrigger)
            {
                airTime = Time.time;
                airTrigger = false;
            }
            if (Time.time - airTime == fallMinimum)
            {
                myAnimator.SetBool("isFall", true);
            }
        }
        else
        {
            myAnimator.SetBool("isFall", false);
        }
    }

    // Funció que tracta amb l'animador si el personatge penja del ganxo.
    private void checkGanxo()
    {
        if (GameObject.Find("Player").GetComponent<grapplingHook>().ganxo)
        {
            myAnimator.SetBool("isGanxo", true);
        }
        else
        {
            myAnimator.SetBool("isGanxo", false);
        }
    }

    // Funció que tracta amb l'animador si el personatge esta ajupit.
    private void checkCrouch()
    {
        if (Input.GetKeyDown(KeyCode.C) && !cantGetUp)
        {
            if (!crouchState && canCrouch && !isCrouch)
            {
                myAnimator.SetBool("isCrouch", true);
                boxCol.size = new Vector3(normalSizeX, crouchSizeY, 0);
                isCrouch = true;
                boxCol.transform.Translate(new Vector3(0, -(normalSizeY - crouchSizeY), 0));
            }
            if (isCrouch && crouchState)
            {
                myAnimator.SetBool("isCrouch", false);
                boxCol.size = new Vector3(normalSizeX, normalSizeY, 0);
                isCrouch = false;
                boxCol.transform.Translate(new Vector3(0, normalSizeY - crouchSizeY, 0));
            }
            crouchState = !crouchState;
        }
    }
    

  
}
