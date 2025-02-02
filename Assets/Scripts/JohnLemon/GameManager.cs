using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    // Variables Globales
    [Header("Images")]
    [SerializeField]
    private Image _caughtImage;
    [SerializeField]
    private Image _wonImage;


    [Header("Fade")] 
    [SerializeField] 
    private float _fadeDuration; // La duración del Fade
    [SerializeField]
    private float _displayImageDuration; // Duración de la imagen

    private float _timer; // Contador de tiempo para el fade

    public bool IsPlayerAtExit; // Si llegamos a la salida
    public bool IsPlayerCaught; // Si nos han pillado
    private bool _isRestartLevel; // Si reseteamos o no

    [Header("Audio")]
    [SerializeField]
    private AudioClip _caughtClip;
    [SerializeField]
    private AudioClip _wonClip;

    private AudioSource _audioSource;



    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsPlayerAtExit) 
        {
            Won();
        }
        else if(IsPlayerCaught) 
        {
            Caught();
        }

    }

    private void OnTriggerEnter(Collider infoAccess)
    {

        if (infoAccess.CompareTag("JohnLemon"))
        {
            Debug.Log("He ganado");

            IsPlayerAtExit = true;

        }

    }


    private void Won()
    {
        _audioSource.clip = _wonClip; 
        if(_audioSource.isPlaying == false)
        {
            _audioSource.Play();
        }

        // Contador de tiempo:
        _timer = _timer + Time.deltaTime;
        // o bien "_timer += Time.deltaTime"

        _wonImage.color = new Color(_wonImage.color.r, _wonImage.color.g, _wonImage.color.b, _timer/_fadeDuration);
        
        // Para que la imagen se quede
        if (_timer > _fadeDuration + _displayImageDuration) 
        {
            Debug.Log("He ganado");
        }

    }

    private void Caught()
    {
        _audioSource.clip = _caughtClip;
        if (_audioSource.isPlaying == false)
        {
            _audioSource.Play();
        }

        // Contador de tiempo:
        _timer = _timer + Time.deltaTime;
        

        _caughtImage.color = new Color(_caughtImage.color.r, _caughtImage.color.g, _caughtImage.color.b, _timer/_fadeDuration);

        // Para que la imagen se quede
        if (_timer > _fadeDuration + _displayImageDuration)
        {
            Debug.Log("He perdido");
            SceneManager.LoadScene("JuanitoLimones");
        }

    }







}
