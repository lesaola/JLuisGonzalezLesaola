using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    // Variables Globales
    public Transform Target;

    [Header("Vectors")]

    // Velocidad de seguimiento de c�mara
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
        // Posici�n a la que queremos mover la cam
        Vector3 desiredPosition = Target.position + _offset;

        // Movemos la c�mara
        transform.position = Vector3.Lerp(transform.position, desiredPosition, _smoothing * Time.deltaTime);
       

    }
}
