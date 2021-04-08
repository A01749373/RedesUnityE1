using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Detecta la colisión de la moneda con el personaje
 * Autora: Amy Murakami Tsutsumi
 */
public class Moneda : MonoBehaviour
{
    //Referencia al Audio Source
    public AudioSource efectoMoneda;

    //La moneda colisionó con otro objeto (colliders)
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
            //Prender la explosión
            //moneda.transform.hijo del transform (transform de la explosión).explosión.Se hace activa
            gameObject.transform.GetChild(0).gameObject.SetActive(true);

            Destroy(gameObject, 0.5f);

            // Contar monedas
            SaludPersonaje.instance.monedas += 25; //25 puntos por cada moneda
            HUD.instance.ActualizarMonedas();
        }
    }
}
