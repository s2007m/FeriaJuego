using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CambiarHabs : MonoBehaviour
{
    public Transform Habs;
    public float OffsetSpawnHab = 16;

    private Sprite ImgAnterior;

    private void Start()
    {
        ImgAnterior = Nivel.HabDefaultIcon;
    }

    void CambiarIconHab(Hab HabActual, Hab NuevaHab)
    {
        HabActual.Habimagen.sprite = ImgAnterior;
        ImgAnterior = NuevaHab.Habimagen.sprite;
        NuevaHab.Habimagen.sprite = Nivel.HabActualIcon;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.name == "PuertaIzq")
        {
            //donde estamos?
            Vector2 ubicacion = Jugador.HabActual.Ubicacion;

            //a donde vamos?
            ubicacion = ubicacion + new Vector2(-1, 0);

            if(Nivel.Habs.Exists(x => x.Ubicacion == ubicacion))
            {
                Hab R = Nivel.Habs.First(x => x.Ubicacion == ubicacion);

                //desabilita la hab en la que estamos
                Habs.Find(Jugador.HabActual.NumHab.ToString()).gameObject.SetActive(false);

                //encuentra la nueva hab y la activa
                GameObject nuevaHab = Habs.Find(R.NumHab.ToString()).gameObject;
                nuevaHab.SetActive(true);

                //mover al jugador a la zona de la puerta donde estaria pasando
                Jugador.transform.position = nuevaHab.transform.Find("Puertas").transform.Find("PuertaDer").position + new Vector3(-OffsetSpawnHab,0);

                CambiarIconHab(Jugador.HabActual, R);

                Jugador.HabActual = R;

            }
        }
    }
}
