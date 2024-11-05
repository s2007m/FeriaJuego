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
        if (other.name == "Enemigo1" || other.name == "Enemigo1(Clone)")
        {
            vida = vida - 5;

            textoVida.text = "           " + vida;

            if (vida <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }   
        else if (other.name == "Enemigo2" || other.name == "Enemigo2(Clone)")
        {
            vida = vida - 10;

            textoVida.text = "           " + vida;

            if (vida <= 0)
            {
                 SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
              else if (other.name == "Enemigo3" || other.name == "Enemigo3(Clone)")
        {
                  vida = vida - 15;

                  textoVida.text = "           " + vida;

                  if (vida <= 0)
                  {
                      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                  }
              }
    }
}
