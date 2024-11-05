using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
            return;
        }

        if (agente != null)
        {
            if (NavMesh.SamplePosition(transform.position, out NavMeshHit hit, 1f, NavMesh.AllAreas))
            {
                agente.Warp(hit.position);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (jugador != null && agente != null && agente.isActiveAndEnabled)
        {
            if (NavMesh.SamplePosition(agente.transform.position, out NavMeshHit hit, 1f, NavMesh.AllAreas))
            {
                agente.SetDestination(jugador.transform.position);
            }
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
