using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Prueba si el collider este DENTRO o FUERA de una plataforma
 * Autor: Equipo 1
 * Ariadna Jocelyn Guzmán Jiménez A01749373
 * Jorge Chávez Badillo A01749448
 * Liam Garay Monroy A01750632
 * Amy Murakami Tsutsumi A01750185
 * Andrea Vianey Díaz Álvarez A01750147
 */

public class PruebaPiso : MonoBehaviour
{
    public static bool estaEnPiso = false;

    //Se ejecuta cuando el collider ENTRA a otro collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Moneda")
        {
            estaEnPiso = true;
            //print(message: "Est� en piso");
        }

    }

    //Se ejecuta cuando el collider SALE a otro collider
    private void OnTriggerExit2D(Collider2D other)
    {
        estaEnPiso = false;
        //print(message: "No est� en piso");
    }
}
