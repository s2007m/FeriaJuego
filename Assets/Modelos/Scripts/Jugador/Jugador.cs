using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Jugador
{
    public static string Estado = "Idle";
    public static Transform transform;
    public static float Velocidad = .1f;
    public static Animator Anim;
    public static Camera Cam;
    public static GameObject Ataque;
    public static GameObject ExplosionAtaque;
    public static Hab HabActual;
}
