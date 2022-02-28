using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugador : MonoBehaviour
{
    public float vel = 5.0f;
    public float correrVel = 8.0f;
    public float fuerzaSalto = 600f;

    public LayerMask capaSuelo;
    public Transform checkSuelo;

    bool enSuelo;
    bool CORRER;

    Rigidbody2D rb;
    Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float h;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            CORRER = true;
        }
        else
        {
            CORRER = false;
        }

        if (CORRER)
        {
            h = Input.GetAxis("Horizontal") * correrVel;
        }
        else
        {
            h = Input.GetAxis("Horizontal") * vel;

        }
        rb.velocity = new Vector2(h, rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.AddForce(Vector2.up * fuerzaSalto);
            anim.SetTrigger("SALTAR");
        }

        if (h !=0)
        {
            anim.SetBool("CORRER", true);
        }
        else
        {
            anim.SetBool("CORRER", false);
        }

        
        anim.SetBool("enSuelo", enSuelo);

    }

    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapCircle(checkSuelo.position, 0.1f, capaSuelo);
    }
}
