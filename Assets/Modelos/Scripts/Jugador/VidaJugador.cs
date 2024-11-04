using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class VidaJugador : MonoBehaviour
{
    public int vida = 100;

    public Text textoVida; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Enemigo")
        {
            vida = vida - 10;

            textoVida.text = "              " + vida;

            if (vida == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
