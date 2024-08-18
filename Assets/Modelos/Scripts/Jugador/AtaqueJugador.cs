using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueJugador : MonoBehaviour
{ 
    public void TerminarAtaque()
    {
        Jugador.Estado = "Idle";
    }



    public void Ataque()
    {
        GameObject g = Instantiate(Jugador.Ataque, transform.position + transform.forward * 5, Jugador.Ataque.transform.rotation);
        g.GetComponent<Rigidbody>().velocity = transform.forward * 70;
        GameObject.Destroy(g,5);
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Jugador.Estado == "Idle") 
        {
            Jugador.Estado = "Atacando";

            string NumAtaque = Random.Range(1,3).ToString();
            Jugador.Anim.Play("Ataque" + NumAtaque);
        }
 
    }
}
