using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicializarJugador : MonoBehaviour
{
    public Camera cam;
    public Animator JugadorAnim;
    public GameObject JugadorAtaque;
    public GameObject JugadorAtaqueExplosion;
    public Transform JugadorTransform;


    void Start()
    {
        Jugador.Cam = cam;
        Jugador.Anim = JugadorAnim;
        Jugador.Ataque = JugadorAtaque;
        Jugador.ExplosionAtaque = JugadorAtaqueExplosion;
        Jugador.transform = JugadorTransform;
    }
}
