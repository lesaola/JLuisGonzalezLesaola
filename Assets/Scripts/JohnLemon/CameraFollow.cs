using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    // Variables Globales
    public Transform Target;

    [Header("Vectors")]

    // Velocidad de seguimiento de cámara
    [SerializeField]
    private float _smoothing;

    // Distancia inicial entre camara y pj
    [SerializeField]
    private Vector3 _offset;


    void Start()
    {
        _offset = transform.position - Target.position;
    }


    private void LateUpdate()
    {
        // Posición a la que queremos mover la cam
        Vector3 desiredPosition = Target.position + _offset;

        // Movemos la cámara
        transform.position = Vector3.Lerp(transform.position, desiredPosition, _smoothing * Time.deltaTime);
       

    }
}
