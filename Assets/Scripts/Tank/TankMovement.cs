using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    // Variables Globales

    [Header("Movement")]
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _turnspeed;

    private float _horizontal,
                  _vertical;

    private Rigidbody _rb;


    [Header("Sound")]
    [SerializeField]
    private AudioClip _idleClip;
    [SerializeField]
    private AudioClip _drivingClip;

    private AudioSource _audioSource;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    
    void Start()
    {
        
    }


    private void FixedUpdate()
    {
        Move();
        Turn();
    }


    void Update()
    {

        InputsPlayer();
        AudioPlayer();
    }

    private void InputsPlayer()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        
        Vector3 direction = transform.forward * _vertical * _speed * Time.deltaTime;
        _rb.MovePosition(transform.position + direction);
            
    }

    private void Turn()
    {

        float turn = _horizontal * _turnspeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler(0.0f, _horizontal, 0.0f);

        _rb.MoveRotation(transform.rotation * turnRotation);

    }

    private void AudioPlayer()
    {

        if(_vertical != 0.0f || _horizontal != 0.0f) 
        {
            if(_audioSource.clip != _drivingClip)
            {
                _audioSource.clip = _drivingClip;
                _audioSource.Play();
            
            }

        }
        else 
        {
        
            if(_audioSource.clip != _idleClip) 
            {
                _audioSource.clip = _idleClip;
                _audioSource.Play();
            }

        }
    }

}
