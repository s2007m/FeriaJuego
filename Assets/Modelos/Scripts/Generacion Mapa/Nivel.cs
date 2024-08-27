using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel
{
    public static float Alto = 500;
    public static float Ancho = 500;

    public static float Escala = 1f;
    public static float EscalaIcon = .07f;
    public static float relleno = .01f;

    public static float ProbGeneracionHab = .5f;

    public static int LimiteHab = 6;

    public static Sprite HabJefeIcon;
    public static Sprite HabSinExplorarIcon;
    public static Sprite HabDefaultIcon;
    public static Sprite HabActualIcon;

    public static List<Hab> Habs = new List<Hab>();
    public static Hab HabActual;
}

public class Hab
{
    public int NumHab = 0;
    public Vector2 Ubicacion;
    public Sprite Habimagen;

}