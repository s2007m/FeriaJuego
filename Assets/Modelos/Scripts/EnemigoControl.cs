using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemigoControl : MonoBehaviour
{
    private NavMeshAgent agente;
    private GameObject jugador;


    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        jugador = GameObject.FindGameObjectWithTag("Player");

        if (jugador == null)
        {
            Debug.LogError("No se encontró el objeto con la etiqueta player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (jugador != null)
        {
            agente.SetDestination(jugador.transform.position);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Proyectil"))
        {
            Destroy(gameObject);
        }
    }
}
