using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Permite modificar el parametro velocidad del Animator
 * Para hacer las transiciones 
 * Autor: Equipo 1
 * Ariadna Jocelyn Guzmán Jiménez A01749373
 * Jorge Chávez Badillo A01749448
 * Liam Garay Monroy A01750632
 * Amy Murakami Tsutsumi A01750185
 * Andrea Vianey Díaz Álvarez A01750147
 */ 
public class CambiaAnimacion : MonoBehaviour
{
    private Rigidbody2D rb2D;
    //Animator
    private Animator anim; //Animator, actualizar el par�metro velocidad
    //SpriteRenderer, es para cambiar la orientaci�n, FlipX FlipY
    private SpriteRenderer sprRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //velocidad
        float velocidad = Mathf.Abs(rb2D.velocity.x);
        anim.SetFloat(name:"velocidad", velocidad);
        
        //Orientaci�n
        if(rb2D.velocity.x > 0)
        {
            sprRenderer.flipX = false;
        } else if (rb2D.velocity.x < 0)
        {
            sprRenderer.flipX = true;
        }

        //Saltando
        anim.SetBool(name: "saltando", !(PruebaPiso.estaEnPiso));
    }
}
