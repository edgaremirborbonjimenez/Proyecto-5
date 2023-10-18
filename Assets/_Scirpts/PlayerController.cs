using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

//Con esta linea dices que el script nomas funciona con objetos que tengan el componente RigidBody,
//si no lo tienen se lo agrega automaticamente
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;

    public float jumpForce = 10;

    public float gravityMultpiplier = 1;

    public bool isOnGround=false;

    private Animator _animator;
    private float speedMultiplier = 1;

    public AudioClip jumpSound, dieSound;
    private AudioSource _audioSource;
    [Range(0, 1)] 
    public float audioVolume = 1;
    
    //Creamos una variable para las particulas de la explosion y las de la tierra al correr
    public ParticleSystem explosion;
    public ParticleSystem tierraCorrer;

    private bool _gameOver = false;

    //Getter y setter de la variable gameOver
    //este formato es funcion lamda
    public bool gameOver
    {
        get => _gameOver;
        //set => _gameOver = value;
        set
        {
            if (_gameOver)
            {
                _gameOver = true;
            }
            else
            {
                _gameOver = value;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Le asigna el componente del RigidBody del objeto a la variable playerRB de tipo RigidBody
        playerRB = GetComponent<Rigidbody>();
        Debug.Log(Physics.gravity);
        //Physics.gravity *= gravityMultpiplier;
        Physics.gravity = gravityMultpiplier*new Vector3(0,-9.81f,0);
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Velocidad de la animacion de correr
        speedMultiplier += Time.deltaTime / 10;
        _animator.SetFloat("Speed Multiplier",speedMultiplier);
        
        
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !_gameOver)
        {
            //Le aplica la fuerza instantania de 1000Newton tomando en cuenta la masa
            playerRB.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
            isOnGround = false;
            //Activa el trigger de la accion de salto para la animacion
            _animator.SetTrigger("Jump_trig");
            _animator.SetBool("isGround",false);
            
            tierraCorrer.Stop();
            
            _audioSource.PlayOneShot(jumpSound,audioVolume);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground")&&!gameOver)
        {
            isOnGround = true;
            _animator.SetBool("isGround",true);
            tierraCorrer.Play();

        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            
            //Activa las particulas
            tierraCorrer.Stop();
            explosion.Play();
            _animator.SetBool("Death_b",true);
            int muerte = Random.Range(1, 3);
            _animator.SetInteger("DeathType_int",muerte);
            _audioSource.PlayOneShot(dieSound,audioVolume);
            //Llamara al metodo restartGame despues de 1 segundo
            Invoke("restartGame",1.0f);
        }
    }

    void restartGame()
    {
        speedMultiplier = 1;
        //Elimina la escena actual con todas las instancias echas
        //SceneManager.UnloadSceneAsync("Prototype 3");
        //Crea una nueva escena
        SceneManager.LoadSceneAsync("Prototype 3");
    }

}
