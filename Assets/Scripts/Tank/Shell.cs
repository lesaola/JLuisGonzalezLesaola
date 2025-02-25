using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _explosionShell;

    private AudioSource _audiosource;
    private Collider _coll;
    private Renderer _rend;



    private void Awake()
    {
        _audiosource = GetComponent<AudioSource>();
        _coll = GetComponent<Collider>();
        _rend = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision infoCollision)
    {
        _coll.enabled = false;
        _rend.enabled = false;
        _explosionShell.Play();
        _audiosource.Play();
        Destroy(gameObject, 0.5f);
    }

}