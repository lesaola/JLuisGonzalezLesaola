using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack : MonoBehaviour
{

    // Globales
    [SerializeField]
    private Rigidbody _shellPrefab; // Prefab de la bala

    [SerializeField]
    private Transform _posShell; // Posición de salida

    [SerializeField]
    private float _launchForce; // Fuerza de la bala

    [SerializeField]
    private AudioSource _audioSource;
    

   
    void Update()
    {
        InputPlayer();
    }


    private void InputPlayer()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            Launch();


        }

    }

    private void Launch()
    {
        Rigidbody cloneShellPrefab = Instantiate(_shellPrefab, _posShell.position, _posShell.rotation);

        _audioSource.Play();

        cloneShellPrefab.velocity = _posShell.forward * _launchForce;
    }
}
