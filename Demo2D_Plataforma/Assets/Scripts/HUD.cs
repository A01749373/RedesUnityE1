using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Para Image
/*
 * Oculta las vidas(corazones)
 * Autor: Equipo 1
 * Ariadna Jocelyn Guzmán Jiménez A01749373
 * Jorge Chávez Badillo A01749448
 * Liam Garay Monroy A01750632
 * Amy Murakami Tsutsumi A01750185
 * Andrea Vianey Díaz Álvarez A01750147
 */
public class HUD : MonoBehaviour
{
    public Image imagen1;
    public Image imagen2;
    public Image imagen3;

    public Text textoMonedas;

    public static HUD instance; 

    /*
     * Se ejecuta cuando el objeto se activa (antes de Start)
     */

    private void Awake()
    {
        instance = this;
    }

    public void ActualizarMonedas()
    {
        textoMonedas.text = SaludPersonaje.instance.monedas.ToString();
    }

    public void ActualizarVidas()
    {
        int vidas = SaludPersonaje.instance.vidas;
        if (vidas == 2)
        {
            imagen3.enabled = false;
        } else if (vidas == 1)
        {
            imagen2.enabled = false;
        } else if (vidas == 0)
        {
            imagen1.enabled = false;
        }
    }


}
