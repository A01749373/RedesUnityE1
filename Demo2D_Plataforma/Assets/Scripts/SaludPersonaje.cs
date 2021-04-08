using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Mantiene información de la salud del personaje
 * Autora: Amy Murakami Tsutsumi
 */
public class SaludPersonaje : MonoBehaviour
{
    public int vidas = 3;

    public int monedas = 0; //Monedas recolectadas

    public static SaludPersonaje instance;

    private void Awake()
    {
        instance = this; //
    }


}
