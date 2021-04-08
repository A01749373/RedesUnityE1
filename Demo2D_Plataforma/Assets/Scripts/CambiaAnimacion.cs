using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Permite modificar el par�metro velocidad del Animator
 * Para hacer las transiciones 
 * Autor: Amy Murakami Tsutsumi 
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
