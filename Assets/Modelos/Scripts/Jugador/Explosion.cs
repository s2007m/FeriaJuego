using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameObject.Destroy(Instantiate(Jugador.ExplosionAtaque, transform.position, Quaternion.identity),3);
        GameObject.Destroy(gameObject);
    }
}
