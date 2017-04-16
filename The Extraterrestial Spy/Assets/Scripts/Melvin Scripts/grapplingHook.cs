using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grapplingHook : MonoBehaviour
{

    // Variable que referencia a l'objecte "line" de Unity, que farem servir per a poder mostrar la corda del ganxo per pantalla.
    public LineRenderer line;

    // Variable amb la que accedirem al nostre objecte "joint".
    public DistanceJoint2D joint;

    // Variable amb la que deternimarem si la posició destí.
    Vector3 targetPos;

    // Variable amb la que determinarem si el nostre objecte col·lisiona amb una altre.
    RaycastHit2D hit;

    // Variable que determina la llargaria del nostre ganxo.
    public float distance = 10f;

    public LayerMask mask;

    public float step = -0.2f;

    // Variable que determina si el personatge toca el terra.
    bool isGrounded;

    // Variable que determina si el ganxo està activat.
    public bool ganxo;

    // Variable que determina si som al sostre.
    bool isCeiling;

    // Variable que determina si som contra una paret.
    bool isWall;

	// Use this for initialization
	void Start ()
    {
        joint = GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        line.enabled = false;
        isGrounded = true;
        ganxo = false;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {/*
        // Aquest codi fara que el jugador sigui atret cap a l'objecte automàticament.
        if (joint.distance > 1f)
        {
            joint.distance -= step;
        }
        else
        {
            line.enabled = false;
            joint.enabled = false;
        }

        // Si mantenim apretada la lletra E...
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Aquesta part del codi detecta on hi ha el cursos en pantalla.
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0;
            hit = Physics2D.Raycast(transform.position, new Vector2(transform.localScale.x, 100), distance,mask);
            // Comprova si el ganxo entra en contacte amb un objecte RigidBody
            if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>()!=null)
            {
                joint.enabled = true;
                joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                // Restem la distància del centre de l'objecte a el punt on ha entrat en contacte amb el ganxo, per a així fer que aquest s'enganxi en aquell punt en especific.
                Vector2 connectPoint = hit.point - new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y-1);
                connectPoint.x = connectPoint.x / hit.collider.transform.localScale.x;
                connectPoint.y = connectPoint.y / hit.collider.transform.localScale.y;
                joint.connectedAnchor = connectPoint;
                joint.distance = Vector2.Distance(transform.position,hit.point);
                // Codi per a la linea.
                line.enabled = true;
                line.SetPosition(0, transform.position);
                line.SetPosition(1, hit.point);
                line.GetComponent<ropeRatio>().grabPosition=hit.point;
            }
        }
        // Actualització corda.
        if (Input.GetKey(KeyCode.E))
        {
            line.SetPosition(0, transform.position);
        }
        // Si deixem anar la lletra E...
        if (Input.GetKeyUp(KeyCode.E))
        {
            joint.enabled = false;
            line.enabled = false;
        }*/

        // Aquest codi fara que el jugador sigui atret cap a l'objecte automàticament.


        // Si premem la lletra E i no tenim el ganxo activat, aquest apareixerà en pantalla activant-se.
        if (Input.GetKeyDown(KeyCode.E) && !ganxo && isGrounded)
        {
            ganxo = true;
        }
        // Si premem la lletra E i tenim el ganxo activat aquest es desactiva i desapareix.
        else if (Input.GetKeyDown(KeyCode.E) && ganxo || isCeiling)
        {
            ganxo = false;
            joint.enabled = false;
            line.enabled = false;
            isCeiling = false;
        }
        if (isGrounded && ganxo && !isWall)
        {
            // Determina el punt de contacte entre la corda i l'objecte.
            hit = Physics2D.Raycast(transform.position, new Vector2(transform.localScale.x, 100), distance,mask);
            // Comprova si el ganxo entra en contacte amb un objecte RigidBody
            if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>()!=null)
            {
                joint.enabled = true;
                joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                // Restem la distància del centre de l'objecte a el punt on ha entrat en contacte amb el ganxo, per a així fer que aquest s'enganxi en aquell punt en especific.
                Vector2 connectPoint = hit.point - new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y-1);
                connectPoint.x = connectPoint.x / hit.collider.transform.localScale.x;
                connectPoint.y = connectPoint.y / hit.collider.transform.localScale.y;
                joint.connectedAnchor = connectPoint;
                joint.distance = Vector2.Distance(transform.position,hit.point);
                // Codi per a la linea.
                line.enabled = true;
                line.SetPosition(0, transform.position);
                line.SetPosition(1, hit.point);
                line.GetComponent<ropeRatio>().grabPosition=hit.point;
            }       
        }
        // Actualització corda. Amb aquest codi, la corda s'anirà actualitzant visualment.
        if (!ganxo)
        {
            joint.enabled = false;
            line.enabled = false;
            isCeiling = false;
        }
        line.SetPosition(0, transform.position);  
	}

    // Funció cridada al produir-se una col·lisió.
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ceiling")
        {
            isCeiling = true;
        }
        if (coll.gameObject.tag == "Wall")
        {
            isWall = true;
        }
    }

    // Funció cridad al sortir d'un collider.
    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        if (collision.gameObject.tag == "Ceiling")
        {
            isCeiling = false;
        }
        if (collision.gameObject.tag == "Wall")
        {
            isWall = false;
        }
    }

    // Funció cridada mentres un objecte estigui en un collider.
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }
}
