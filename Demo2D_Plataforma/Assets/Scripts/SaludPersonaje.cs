using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Mantiene informaci�n de la salud del personaje
 * Autor: Equipo 1
 * Ariadna Jocelyn Guzmán Jiménez A01749373
 * Jorge Chávez Badillo A01749448
 * Liam Garay Monroy A01750632
 * Amy Murakami Tsutsumi A01750185
 * Andrea Vianey Díaz Álvarez A01750147
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
