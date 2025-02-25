using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{

    // Globales
    [Header("Health")]
    [SerializeField]
    private float _maxHealth; // salud máx
    [SerializeField]
    private float _currentHealth; // salud actual
    [SerializeField]
    private float _damageEnemyBullet; // salud que me quita una bala

    [Header("ProgressBar")]
    [SerializeField]
    private Image _lifeBar;

    [Header("Explosion")]
    [SerializeField]
    private ParticleSystem _smallExplosion;
    [SerializeField]
    private ParticleSystem _bigExplosion;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _lifeBar.fillAmount = 1.0f;
    }

    private void OnTriggerEnter(Collider infoAccess)
    {
        if(infoAccess.CompareTag("BulletEnemy"))
        {
            _currentHealth -= _damageEnemyBullet;
            _lifeBar.fillAmount = _currentHealth / _maxHealth;
            Destroy(infoAccess.gameObject);

            if (_currentHealth <= 0.0f)
            {

                Death();
            }


        }

    }

    private void Death()
    {

        Destroy(gameObject);
    
    }

}
