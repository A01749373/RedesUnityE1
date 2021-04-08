using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Detecta la colisi�n de la moneda con el personaje
 * Autora: Amy Murakami Tsutsumi
 */
public class Moneda : MonoBehaviour
{
    //Referencia al Audio Source
    public AudioSource efectoMoneda;

    //La moneda colision� con otro objeto (colliders)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Recolectar
            //print(message: "Recolectando....");

            //Reproducir un efecto de sonido
            efectoMoneda.Play();
            //Dejar de dibujar la moneda
            GetComponent<SpriteRenderer>().enabled = false;
            //Prender la explosi�n
            //moneda.transform.hijo del transform (transform de la explosi�n).explosi�n.Se hace activa
            gameObject.transform.GetChild(0).gameObject.SetActive(true);

            Destroy(gameObject, 0.5f);

            // Contar monedas
            SaludPersonaje.instance.monedas += 25; //25 puntos por cada moneda
            HUD.instance.ActualizarMonedas();
        }
    }
}
