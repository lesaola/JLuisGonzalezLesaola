using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    // Variables Globales

    [SerializeField]
    private float _speed; // Variable de velocidad

    [SerializeField]
    private Transform[] _positionsArray; // Array de posiciones para patrullar
    

    private Vector3 _posToGo; // Almacenar la posicion a la que se dirige

    private int _i; // Controla en que casilla o posición del Array estoy 

    private Ray _ray;
    private RaycastHit _hit;

    public GameManager GameManagerScript;

   
    void Start()
    {

        _i = 0;
        _posToGo = _positionsArray[_i].position;

    }


    private void FixedUpdate()
    {
        DetectionJohnLemon();
    }


    void Update()
    {
        Move();
        Rotate();
        ChangePosition();
    }


    private void Move()
    {
    
        transform.position = Vector3.MoveTowards(transform.position, _posToGo, _speed * Time.deltaTime);
    
    }

    private void ChangePosition()
    {
        // Si el Ghost llega a su destino

        if(Vector3.Distance(transform.position, _posToGo) <= Mathf.Epsilon)
        {

            // Comprobar si estoy en la última casilla del Array
            if (_i == _positionsArray.Length - 1)
            {

                // Vuelvo a la casilla inicial del Array
                _i = 0;

            }
            else 
            {

                _i++;

            }

            _posToGo = _positionsArray[_i].position;

        }
    }

    private void Rotate() // Para que mire hacia donde va
    {
    
        transform.LookAt(_posToGo);
    
    }

    
    private void DetectionJohnLemon()
    {
    
        //  Subir el origen del rayo 1m en eje Y (por si acaso)
        _ray.origin = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        _ray.direction = transform.forward;

        if(Physics.Raycast(_ray, out _hit))
        {

            if(_hit.collider.CompareTag("JohnLemon"))
            {
                Debug.Log("Ghost te ha pillado");

                GameManagerScript.IsPlayerCaught = true;
            }
        }
    }
}
