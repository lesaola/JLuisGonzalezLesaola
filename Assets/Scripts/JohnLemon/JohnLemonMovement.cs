using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnLemonMovement : MonoBehaviour
{
    // Variables Globales
    [Header("Movement")]
    [SerializeField]
    private float _speed,
                  _turnSpeed;

    private float _horizontal,
                  _vertical;

    // Se guarda la direccion del movimiento
    [SerializeField]
    private Vector3 _direction;
    
    // Se obtiene el Animator y el Rigidbody
    private Rigidbody _rb;
    private Animator _anim;

    private AudioSource _audioSource;
    
   

    private void Awake()
    {
        _rb =  GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        Rotation();
    }

    private void OnAnimatorMove() // Mover al pj cuando se mueve la animación
    {
        _rb.MovePosition(transform.position + (_direction * _anim.deltaPosition.magnitude));

        //_rb.MovePosition(transform.position + (_direction * _speed * Time.deltaTime)); 
        // si la animación no se desplazase 
    }


    
    void Update() // Update siempre para llamar teclas pulsadas (cada frame)
    {
        InputsPlayer();
        IsAnimate();
        AudioSteps();
    }


    private void InputsPlayer() // Recoger info de las teclas y normalizar la dirección
    {

        // Teclas A y D, y arrowkeys izq. y dcha.
        _horizontal = Input.GetAxis("Horizontal");
        // Teclas W y S, y arrowkeys arriba y abajo
        _vertical = Input.GetAxis("Vertical");

        // Guarda en su interior las dos variables anteriores 
        _direction = new Vector3(_horizontal, 0.0f, _vertical);

        // Normalizar diagonal
        _direction.Normalize();
    }

    private void IsAnimate() // Booleano para la animación de caminar
    {

        if (_horizontal != 0.0f || _vertical != 0.0f) 
        {
            _anim.SetBool("IsWalking", true);
        }
        else
        { 
            _anim.SetBool("IsWalking", false);
        }

    }

    private void Rotation() // Para cambiar súbitamente la orientación de los ejes
    {

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, _direction, _turnSpeed * Time.deltaTime, 0.0f);
        Quaternion rotation = Quaternion.LookRotation(desiredForward);
        _rb.MoveRotation(rotation);
    
    }

    private void AudioSteps() 
    {
        if (_horizontal != 0.0f || _vertical != 0.0f)
        { 

            if (_audioSource.isPlaying == false)
            {
                _audioSource.Play();
            }

        }
        else
        {
            _audioSource.Stop();
        }
    }
}
