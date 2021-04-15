using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * Controlador del menu pausa (muestra/oculta)
 * Autor: Equipo 1
 * Ariadna Jocelyn Guzmán Jiménez A01749373
 * Jorge Chávez Badillo A01749448
 * Liam Garay Monroy A01750632
 * Amy Murakami Tsutsumi A01750185
 * Andrea Vianey Díaz Álvarez A01750147
 */
public class MenuPausa : MonoBehaviour
{
    private bool estaPausado; //true-> Estoy en pausa
    public GameObject pantallaPausa; //PANEL

    // El usuario solicita pausar o quitar la pausa
    public void Pausar()
    {
        estaPausado = !estaPausado; 
        //Prende/apaga la pantalla
        pantallaPausa.SetActive(estaPausado);
        //Escala de tiempo -if terciario-
        Time.timeScale = estaPausado ? 0 : 1;
    }

    public void SalirJuego()
    {
        SceneManager.LoadScene("EscenaMenu");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausar();
        }
    }
}
