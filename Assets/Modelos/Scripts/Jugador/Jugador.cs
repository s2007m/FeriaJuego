using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;


public static class Jugador
{
    public static string Estado = "Idle";
    public static bool Invencible = false;
    public static Transform transform;
    public static float Velocidad = .3f;
    public static Animator Anim;
    public static Camera Cam;
    public static GameObject Ataque;
    public static GameObject ExplosionAtaque;
    public static int pts = 0;

}
