using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Permita que la c�mara siga al personaje
 * Autor: Equipo 1
 * Ariadna Jocelyn Guzmán Jiménez A01749373
 * Jorge Chávez Badillo A01749448
 * Liam Garay Monroy A01750632
 * Amy Murakami Tsutsumi A01750185
 * Andrea Vianey Díaz Álvarez A01750147
 */
public class MoverCamara : MonoBehaviour
{
    public GameObject personaje; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Clamp(value: personaje.transform.position.x, min: 0, max: 18.6f);
        float y = Mathf.Clamp(value: personaje.transform.position.y, min: 0, max: 8.6f);
        float z = transform.position.z;
        transform.position = new Vector3(x, y, z);
    }
}
