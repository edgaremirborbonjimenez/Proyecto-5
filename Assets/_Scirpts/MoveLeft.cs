using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;
        
    //Creamos una variable del componente(Script) PlayerController
    private PlayerController _playerController;
    // Start is called before the first frame update
    void Start()
    {
        //Busca un GameObject con el nombre de Player 
        //Y solicitamos su componente PlayerController
        _playerController = GameObject.Find("Player").
            GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Si la variable gameOver del componente PlayerController
        //del GameObject con el nombre Player es false procede a mover el background
        //en caso contrario ya no lo muevas
        if (!_playerController.gameOver)
        {
            this.transform.Translate(Vector3.left*speed*Time.deltaTime);

        }

    }
}
