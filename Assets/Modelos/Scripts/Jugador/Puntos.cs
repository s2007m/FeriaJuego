using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Puntos : MonoBehaviour
{
    int pts;
    public Text TextoPts;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            pts += 5;
            TextoPts.text = "" + pts;
        }
    }
}
