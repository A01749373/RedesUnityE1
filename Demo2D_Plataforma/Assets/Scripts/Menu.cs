using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * Controla el men�
 * Agregamos los m�todos para atender los componentes del men�
 * Autora: Amy Murakami Tsutsumi
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
