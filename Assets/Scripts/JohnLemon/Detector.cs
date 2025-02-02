using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{

    // Variables Globales 

    public GameManager GameManagerScript;

    private void OnTriggerEnter(Collider infoAccess)
    {
        
        if (infoAccess.CompareTag("JohnLemon"))
        {
            Debug.Log("Te he pillado");

            GameManagerScript.IsPlayerCaught = true;

        }

    }
}
