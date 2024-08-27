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
        ImagenHab.sprite = R.Habimagen;
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
            nuevaHab.Habimagen = Nivel.HabDefaultIcon;
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
            nuevaHab.Habimagen = Nivel.HabDefaultIcon;

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
            nuevaHab.Habimagen = Nivel.HabDefaultIcon;
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
            nuevaHab.Habimagen = Nivel.HabDefaultIcon;
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
        HabInicio.Habimagen = Nivel.HabActualIcon;

        //Pone la habitacion inical
        PonerHabsEnMapa(HabInicio);

        //izq
        if(Random.value > Nivel.ProbGeneracionHab)
        {
            Hab nuevaHab = new Hab();
            nuevaHab.Ubicacion = new Vector2(-1, 0);
            nuevaHab.Habimagen = Nivel.HabDefaultIcon;
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
            nuevaHab.Habimagen = Nivel.HabDefaultIcon;
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
            nuevaHab.Habimagen = Nivel.HabDefaultIcon;
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
            nuevaHab.Habimagen = Nivel.HabDefaultIcon;
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
