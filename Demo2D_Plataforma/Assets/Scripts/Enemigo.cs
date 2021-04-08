using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * Detecta la colisión del enemigo con el personaje
 * Autora: Amy Murakami Tsutsumi
 */
public class Enemigo : MonoBehaviour
{
    //Referencia al Audio Source
    public AudioSource efectoEnemigo;
    public AudioSource efectoMuere;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Reproducir un efecto de sonido
            efectoEnemigo.Play();

            //Descontar una vida 
            SaludPersonaje.instance.vidas--; //Se disminuye en uno la variable vidas
            //Actualizar los 'corazones'
            HUD.instance.ActualizarVidas();
            if (SaludPersonaje.instance.vidas == 0)
            {
                efectoMuere.Play();
                Destroy(other.gameObject, 5f);
                //SceneManager.LoadScene("EscenaMenu"); //Pierde, regresa al menú
            }
        }
    }
}
