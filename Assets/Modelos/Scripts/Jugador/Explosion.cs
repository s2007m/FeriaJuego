using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class Explosion : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {

        GameObject.Destroy(Instantiate(Jugador.ExplosionAtaque, transform.position, Quaternion.identity),3);
        GameObject.Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            GameObject.Destroy(Instantiate(Jugador.ExplosionAtaque, transform.position, Quaternion.identity), 3);
            GameObject.Destroy(gameObject);

            

        }
    }
}
