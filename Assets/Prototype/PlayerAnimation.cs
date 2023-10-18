using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    private const string Moving_Hand = "Moving Hand";
    private const string MovingX = "MoveX";
    private const string MovingY = "MoveY";


    private bool isMovingHand = false;

    private float moveX = 0.0f, moveY = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        //Guardamos el componente solicitado del que tiene el script
        _animator = GetComponent<Animator>();
        //Le asignamos valor por default del parametro a modificar
        _animator.SetBool(Moving_Hand,isMovingHand);
        _animator.SetFloat(MovingX,moveX);
        _animator.SetFloat(MovingY,moveY);
    }

    // Update is called once per frame
    void Update()
    {

        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        if (Mathf.Sqrt(moveX*moveX + moveY*moveY) > 0.01)
        {
            _animator.SetBool("isMoving",true);
            _animator.SetFloat(MovingX,moveX);
            _animator.SetFloat(MovingY,moveY);
        }
        else
        {
            _animator.SetBool("isMoving",false);
        }
        


        //Si preciona espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMovingHand = !isMovingHand;
            //Cambia el valor del parametro de Moving Hand
            _animator.SetBool(Moving_Hand,isMovingHand);
        }
    }
}
