using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftCilinder : MonoBehaviour
{
    public float speedRotation=60;
    public float speedTranslate = 6;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        transform.Rotate(Vector3.up*speedRotation*Time.deltaTime);
        //Traslada a la direccion local osea que la izquierda del mundo no la izquierda del GameObject
        //Asi evitamos que se regrese con la rotacion
        transform.localPosition += Vector3.left * speedTranslate * Time.deltaTime;
    }
}
