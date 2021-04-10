using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

/*
 * Detecta la colisión del enemigo con el personaje
 * Autor: Equipo 1
 */
public class Enemigo : MonoBehaviour
{
    public AudioSource efectoEnemigo;
    public AudioSource efectoMuere;
    public static String tiempoFinal;
    public static Enemigo instance;

    public IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Reproducir el efecto
            efectoEnemigo.Play();
            //Descontar una vida
            SaludPersonaje.instance.vidas--;
            //Actualizar los corazones
            HUD.instance.ActualizarVidas();

            if (SaludPersonaje.instance.vidas == 0)
            {
                efectoMuere.Play();
                Destroy(other.gameObject, 5f);
                //SceneManager.LoadScene("EscenaMenu"); //Pierde, regresa al menu

                tiempoFinal = System.DateTime.Now.TimeOfDay.ToString(); //Declaramos la hora final en el momento que pierde las 3 vidas
                String TiempoInicio2 = Red.tiempoInicio; //Traemos del archivo Red el tiempo inicio

                WWWForm forma2 = new WWWForm();

                forma2.AddField("TiempoInicio", TiempoInicio2);
                forma2.AddField("TiempoFinal", tiempoFinal);
                forma2.AddField("TiempoUsuario", Red.nombre);

                UnityWebRequest request = UnityWebRequest.Post("http://Localhost:8080/AgregarTiempo", forma2);
                yield return request.SendWebRequest();
                if (request.result == UnityWebRequest.Result.Success)  //200 OK
                {
                    string textoPlano = request.downloadHandler.text;  //Datos descargados de la red
                    print(textoPlano);
                }
                else
                {
                    print("Error en la descarga: " + request.responseCode.ToString());
                }
            }
        }
    }
}

