using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class BackgroundRepeating : MonoBehaviour
{
    private Vector3 posicionInicial;

    private float anchuraRepeticion;
    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = this.transform.position;
        //Sacamos la mitad de la anchura del background para saber cuando lo regresaremos
        anchuraRepeticion = GetComponent<BoxCollider>().size.x/2;
    }

    // Update is called once per frame
    void Update()
    {
        //Al recorrer la mitad del fondo que normalmente es al recorrer 50 en x
        // O tambien para ser mas exactos puedes sacar el tamaño en x del fondo con un boxcollider
        if ((posicionInicial.x - transform.position.x) > anchuraRepeticion)
        {
            transform.position = posicionInicial;
        }
    }
}
