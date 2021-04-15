using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * Controla el men�
 * Agregamos los m�todos para atender los componentes del men�
 * Autor: Equipo 1
 * Ariadna Jocelyn Guzmán Jiménez A01749373
 * Jorge Chávez Badillo A01749448
 * Liam Garay Monroy A01750632
 * Amy Murakami Tsutsumi A01750185
 * Andrea Vianey Díaz Álvarez A01750147
 */
public class Menu : MonoBehaviour
{
    public void Salir()
    {
        //Regresa al Sistema Operativo
        Application.Quit();
    }
    public void IniciarJuego()
    {
        //Cambiar de escena
        //print(message: "Click al bot�n");

        //Cambiar escena
        SceneManager.LoadScene("EscenaMapa");
    }
}
