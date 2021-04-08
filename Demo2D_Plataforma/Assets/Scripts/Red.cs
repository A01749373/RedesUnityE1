using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking; //Para red, UnityWebRequest
using UnityEngine.UI;

/*
 * Muestra el uso de UnityWebRequest para comunicarse con un servidor en la red
 * Autor:
 * Andrea Vianey Díaz Álvarez
 * Liam Garay Monroy
 * Amy Murakami Tsutsumi
 * Jorge Chávez Badillo
 * Ariadna Jocelyn Guzmán
 */
public class Red : MonoBehaviour
{
    //Variable para desplegar la informacion
    public Text resultado;
    public Text textoNombre;
    public Text textoPuntos;

    public struct DatosUsuario
    {
        public string nombre;
        public int puntos;
    }
    //Encapsular los datos JSON
    public DatosUsuario datos;
    
    //ESCRIBIR JSON
    public void EscribirJSON()
    {
        //Concurrente
        StartCoroutine(SubirJSON()); //Paralelo
    }
    
    //Parte se ejecuta en paraalelo
    private IEnumerator SubirJSON()
    {
        datos.nombre = textoNombre.text;
        datos.puntos= Int32.Parse(textoPuntos.text);
        print(JsonUtility.ToJson(datos));
        //Encapsular los datos que se suben a red con POST
        WWWForm forma = new WWWForm();
        forma.AddField("datosJSON", JsonUtility.ToJson(datos));
        UnityWebRequest request = UnityWebRequest.Post("http://localhost:8080/recibeJSON",forma); //http://189.139.248.236/unity/recibeJSON.php
        yield return request.SendWebRequest(); //Regresa, ejecuta, espera...
        // ... ya regresó por que termino de ejecutar SendWebRequest()
        if (request.result == UnityWebRequest.Result.Success)  //200 
        {
            string textoPlano = request.downloadHandler.text; //Datos descargados de la red
            resultado.text = textoPlano;
        }
        else
        {
            resultado.text = "Error en la descarga: " + request.responseCode.ToString();
        }
        
    }
    public void LeerJSON() //Boton
    {
        //Concurrente
        StartCoroutine(DescargarJSON()); //'Paralelo'

    }
    
    //Parte de este codigo se ejecuta en 'Paralelo'
    private IEnumerator DescargarJSON()
    {
        UnityWebRequest request = UnityWebRequest.Get("http://localhost:8080/generaJSON"); //http://189.139.248.236/unity/generaJSON.php
        yield return request.SendWebRequest(); //Regresa, ejecuta, espera...
        // ... ya regresó por que termino de ejecutar SendWebRequest()
        if (request.result == UnityWebRequest.Result.Success)  //200 
        {
            string textoPlano = request.downloadHandler.text; //Datos descargados de la red
            resultado.text = textoPlano;

            Dictionary<string, string> datos =
                JsonConvert.DeserializeObject<Dictionary<string, string>>(textoPlano);
            foreach (var dato in datos)
            {
                print(dato.Key + " : " + dato.Value);
            }
            {
                
            }
        }
        else
        {
            resultado.text = "Error en la descarga: " + request.responseCode.ToString();
        }
    }


    //ESCRIBIR
    public void EscribirTextoPlano()
    {
        //Concurrente
        StartCoroutine(SubirTextoPlano()); //Paralelo
    }
    
    //Parte se ejecuta en paraalelo
    private IEnumerator SubirTextoPlano()
    {
        //Encapsular los datos que se suben a red con POST
        WWWForm forma = new WWWForm();
        forma.AddField("nombre", textoNombre.text);
        forma.AddField("puntos", textoPuntos.text);
        UnityWebRequest request = UnityWebRequest.Post("http://localhost:8080/recibeTextoPlano",forma);  //http://189.139.248.236/unity/recibeTextoPlano.php
        yield return request.SendWebRequest(); //Regresa, ejecuta, espera...
        // ... ya regresó por que termino de ejecutar SendWebRequest()
        if (request.result == UnityWebRequest.Result.Success)  //200 
        {
            string textoPlano = request.downloadHandler.text; //Datos descargados de la red
            resultado.text = textoPlano;
        }
        else
        {
            resultado.text = "Error en la descarga: " + request.responseCode.ToString();
        }
        
    }

    public void LeerTextoPlano() //Boton
    {
        //Concurrente
        StartCoroutine(DescargarTextoPlano()); //'Paralelo'

    }
    
    //Parte de este codigo se ejecuta en 'Paralelo'
    private IEnumerator DescargarTextoPlano()
    {
        UnityWebRequest request = UnityWebRequest.Get("http://localhost:8080/texto"); //http://189.139.248.236/unity/texto.txt
        yield return request.SendWebRequest(); //Regresa, ejecuta, espera...
        // ... ya regresó por que termino de ejecutar SendWebRequest()
        if (request.result == UnityWebRequest.Result.Success)  //200 
        {
            string textoPlano = request.downloadHandler.text; //Datos descargados de la red
            resultado.text = textoPlano;
        }
        else
        {
            resultado.text = "Error en la descarga: " + request.responseCode.ToString();
        }
    }

}
