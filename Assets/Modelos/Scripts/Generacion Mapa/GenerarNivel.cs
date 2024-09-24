using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerarNivel : MonoBehaviour
{
    public Sprite HabActual;
    public Sprite HabSinExplorar;
    public Sprite HabJefe;
    public Sprite HabVacia;

    void PonerHabsEnMapa(Hab R)
    {
        GameObject CasillaMapa = new GameObject("CasillaMapa");
        Image ImagenHab = CasillaMapa.AddComponent<Image>();
        ImagenHab.sprite = R.HabSprite;
        RectTransform rectTransform = ImagenHab.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(Nivel.Alto, Nivel.Ancho) * Nivel.EscalaIcon;
        rectTransform.position = R.Ubicacion * (Nivel.EscalaIcon * Nivel.Alto * Nivel.Escala + (Nivel.relleno * Nivel.Alto * Nivel.Escala));
        ImagenHab.transform.SetParent(transform, false);

        Nivel.Habs.Add(R);
    }

    bool RevisarSiExisteHab(Vector2 v)
    {
        return Nivel.Habs.Exists(x => x.Ubicacion == v);
    }

    bool RevisarSiHabsAlrededorCrearonHabs(Vector2 v, string direccion)
    {
        switch (direccion)
        {
            case "Der":
                {
                    //Revisa izq, abajo y arriba
                    if (Nivel.Habs.Exists(x => x.Ubicacion == new Vector2(v.x - 1, v.y)) ||
                        Nivel.Habs.Exists(x => x.Ubicacion == new Vector2(v.x, v.y - 1)) ||
                        Nivel.Habs.Exists(x => x.Ubicacion == new Vector2(v.x, v.y + 1)))
                        return true;

                    break;
                }
            case "Izq":
                {
                    //Revisa der, abajo y arriba
                    if (Nivel.Habs.Exists(x => x.Ubicacion == new Vector2(v.x + 1, v.y)) ||
                        Nivel.Habs.Exists(x => x.Ubicacion == new Vector2(v.x, v.y - 1)) ||
                        Nivel.Habs.Exists(x => x.Ubicacion == new Vector2(v.x, v.y + 1)))
                        return true;

                    break;
                }
            case "Abajo":
                {
                    //Revisa izq, derecha y arriba
                    if (Nivel.Habs.Exists(x => x.Ubicacion == new Vector2(v.x - 1, v.y)) ||
                        Nivel.Habs.Exists(x => x.Ubicacion == new Vector2(v.x + 1, v.y )) ||
                        Nivel.Habs.Exists(x => x.Ubicacion == new Vector2(v.x, v.y + 1)))
                        return true;

                    break;
                }
            case "Arriba":
                {
                    //Revisa izq, derecha y abajo
                    if (Nivel.Habs.Exists(x => x.Ubicacion == new Vector2(v.x - 1, v.y)) ||
                        Nivel.Habs.Exists(x => x.Ubicacion == new Vector2(v.x + 1, v.y)) ||
                        Nivel.Habs.Exists(x => x.Ubicacion == new Vector2(v.x, v.y - 1)))
                        return true;

                    break;
                }
        }


        return false;
    }



    int segurofallo = 0;
    void GenerarHab(Hab hab)
    {
        segurofallo++;
        if (segurofallo > 50)
        {
            return;
        }
        PonerHabsEnMapa(hab);

        //izq
        if (Random.value > Nivel.ProbGeneracionHab)
        {
            Hab nuevaHab = new Hab();
            nuevaHab.Ubicacion = new Vector2(-1, 0) + hab.Ubicacion;
            nuevaHab.HabSprite = Nivel.HabDefaultIcon;
            if (!RevisarSiExisteHab(nuevaHab.Ubicacion))
            {
                if (!RevisarSiHabsAlrededorCrearonHabs(nuevaHab.Ubicacion, "Der"))
                {
                    if(Mathf.Abs(nuevaHab.Ubicacion.x) < Nivel.LimiteHab && Mathf.Abs(nuevaHab.Ubicacion.y) < Nivel.LimiteHab)
                    GenerarHab(nuevaHab);
                }
            }
        }

        //der
        if (Random.value > Nivel.ProbGeneracionHab)
        {
            Hab nuevaHab = new Hab();
            nuevaHab.Ubicacion = new Vector2(1, 0) + hab.Ubicacion;
            nuevaHab.HabSprite = Nivel.HabDefaultIcon;

            if(!RevisarSiExisteHab(nuevaHab.Ubicacion))
            {
                if (!RevisarSiHabsAlrededorCrearonHabs(nuevaHab.Ubicacion, "Izq"))
                {
                    if (Mathf.Abs(nuevaHab.Ubicacion.x) < Nivel.LimiteHab && Mathf.Abs(nuevaHab.Ubicacion.y) < Nivel.LimiteHab)
                        GenerarHab(nuevaHab);
                }
            }
        }

        //arriba
        if (Random.value > Nivel.ProbGeneracionHab)
        {
            Hab nuevaHab = new Hab();
            nuevaHab.Ubicacion = new Vector2(0, 1) + hab.Ubicacion;
            nuevaHab.HabSprite = Nivel.HabDefaultIcon;
            if (!RevisarSiExisteHab(nuevaHab.Ubicacion))
            {
                if (!RevisarSiHabsAlrededorCrearonHabs(nuevaHab.Ubicacion, "Abajo"))
                {
                    if (Mathf.Abs(nuevaHab.Ubicacion.x) < Nivel.LimiteHab && Mathf.Abs(nuevaHab.Ubicacion.y) < Nivel.LimiteHab)
                        GenerarHab(nuevaHab);
                }
            }
        }

        //abajo
        if (Random.value > Nivel.ProbGeneracionHab)
        {
            Hab nuevaHab = new Hab();
            nuevaHab.Ubicacion = new Vector2(0, -1) + hab.Ubicacion;
            nuevaHab.HabSprite = Nivel.HabDefaultIcon;
            if (!RevisarSiExisteHab(nuevaHab.Ubicacion))
            {
                if (!RevisarSiHabsAlrededorCrearonHabs(nuevaHab.Ubicacion, "Arriba"))
                {
                    if (Mathf.Abs(nuevaHab.Ubicacion.x) < Nivel.LimiteHab && Mathf.Abs(nuevaHab.Ubicacion.y) < Nivel.LimiteHab)
                        GenerarHab(nuevaHab);
                }
            }
        }

        
    }

    private void GenerarHabJefe()
    {
        float NumMax = 0;
        Vector2 HabMasLejana = Vector2.zero;

        foreach (Hab R in Nivel.Habs)
        {
            if (Mathf.Abs(R.Ubicacion.x) + Mathf.Abs(R.Ubicacion.y) >= NumMax)
            {
                NumMax = Mathf.Abs(R.Ubicacion.x) + Mathf.Abs(R.Ubicacion.y);
                HabMasLejana = R.Ubicacion;
            }

        }

        Hab HabJefe = new Hab();
        HabJefe.HabSprite = Nivel.HabJefeIcon;
        HabJefe.NumHab = 3;

        //Izq
        if (!RevisarSiExisteHab(HabMasLejana + new Vector2(-1, 0)))
        {
            if (!RevisarSiHabsAlrededorCrearonHabs(HabMasLejana + new Vector2(-1, 0), "Derecha"))
            {
                HabJefe.Ubicacion = HabMasLejana + new Vector2(-1, 0);
            }
        }

        //Der
        else if (!RevisarSiExisteHab(HabMasLejana + new Vector2(1, 0)))
        {
            if (!RevisarSiHabsAlrededorCrearonHabs(HabMasLejana + new Vector2(1, 0), "Izquierda"))
            {
                HabJefe.Ubicacion = HabMasLejana + new Vector2(1, 0);
            }
        }

        //Arriba
        else if (!RevisarSiExisteHab(HabMasLejana + new Vector2(0, 1)))
        {
            if (!RevisarSiHabsAlrededorCrearonHabs(HabMasLejana + new Vector2(0, 1), "Abajo"))
            {
                HabJefe.Ubicacion = HabMasLejana + new Vector2(0, 1);
            }
        }
            
        //Abajo
        else if (!RevisarSiExisteHab(HabMasLejana + new Vector2(0, -1)))
        {
            if (!RevisarSiHabsAlrededorCrearonHabs(HabMasLejana + new Vector2(0, -1), "Arriba"))
            {
                HabJefe.Ubicacion = HabMasLejana + new Vector2(0, -1);
            }
        }
             


        PonerHabsEnMapa(HabJefe);
    }



    private void Awake()
    {
        Nivel.HabDefaultIcon = HabVacia;
        Nivel.HabJefeIcon = HabJefe;
        Nivel.HabActualIcon = HabActual;
        Nivel.HabSinExplorarIcon = HabSinExplorar;
    }

    void Start()
    {

        Hab HabInicio = new Hab();
        HabInicio.Ubicacion = new Vector2(0, 0);
        HabInicio.HabSprite = Nivel.HabActualIcon;
        HabInicio.NumHab =0;

        Jugador.HabActual = HabInicio;

        //Pone la habitacion inical
        PonerHabsEnMapa(HabInicio);

        //izq
        if(Random.value > Nivel.ProbGeneracionHab)
        {
            Hab nuevaHab = new Hab();
            nuevaHab.Ubicacion = new Vector2(-1, 0);
            nuevaHab.HabSprite = Nivel.HabDefaultIcon;
            if (!RevisarSiExisteHab(nuevaHab.Ubicacion))
            {
                if (!RevisarSiHabsAlrededorCrearonHabs(nuevaHab.Ubicacion, "Der"))
                {
                    if (Mathf.Abs(nuevaHab.Ubicacion.x) < Nivel.LimiteHab && Mathf.Abs(nuevaHab.Ubicacion.y) < Nivel.LimiteHab)
                        GenerarHab(nuevaHab);
                }
            }
        }

        //der
        if (Random.value > Nivel.ProbGeneracionHab)
        {
            Hab nuevaHab = new Hab();
            nuevaHab.Ubicacion = new Vector2(1, 0);
            nuevaHab.HabSprite = Nivel.HabDefaultIcon;
            if (!RevisarSiExisteHab(nuevaHab.Ubicacion))
            {
                if (!RevisarSiHabsAlrededorCrearonHabs(nuevaHab.Ubicacion, "Izq"))
                {
                    if (Mathf.Abs(nuevaHab.Ubicacion.x) < Nivel.LimiteHab && Mathf.Abs(nuevaHab.Ubicacion.y) < Nivel.LimiteHab)
                        GenerarHab(nuevaHab);
                }
            }
        }

        //arriba
        if (Random.value > Nivel.ProbGeneracionHab)
        {
            Hab nuevaHab = new Hab();
            nuevaHab.Ubicacion = new Vector2(0, 1);
            nuevaHab.HabSprite = Nivel.HabDefaultIcon;
            if (!RevisarSiExisteHab(nuevaHab.Ubicacion))
            {
                if (!RevisarSiHabsAlrededorCrearonHabs(nuevaHab.Ubicacion, "Abajo"))
                {
                    if (Mathf.Abs(nuevaHab.Ubicacion.x) < Nivel.LimiteHab && Mathf.Abs(nuevaHab.Ubicacion.y) < Nivel.LimiteHab)
                        GenerarHab(nuevaHab);
                }
            }
        }

        //abajo
        if (Random.value > Nivel.ProbGeneracionHab)
        {
            Hab nuevaHab = new Hab();
            nuevaHab.Ubicacion = new Vector2(0, -1);
            nuevaHab.HabSprite = Nivel.HabDefaultIcon;
            if (!RevisarSiExisteHab(nuevaHab.Ubicacion))
            {
                if (!RevisarSiHabsAlrededorCrearonHabs(nuevaHab.Ubicacion, "Arriba"))
                {
                    if (Mathf.Abs(nuevaHab.Ubicacion.x) < Nivel.LimiteHab && Mathf.Abs(nuevaHab.Ubicacion.y) < Nivel.LimiteHab)
                        GenerarHab(nuevaHab);
                }
            }
        }

        GenerarHabJefe();

    }


    bool regenerar = false;
    void PararRegenerar()
    {
        regenerar = false;
    }
    private void Update()
    {
        //Regenerar mapa con tecla TAB (y que haya cooldown pq Update activa cada frame)
        if (Input.GetKey(KeyCode.Tab) && !regenerar)
        {
            regenerar = true;
            Nivel.Habs.Clear();
            Invoke(nameof(PararRegenerar), 1);
            for(int i = transform.childCount - 1; i >= 0; i--)
            {
                Transform child = transform.GetChild(i);
                Destroy(child.gameObject);
            }


            Start();
        }
    }
}
