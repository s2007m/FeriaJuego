using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public CharacterController Controller;

    private void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        if((hor != 0 || ver != 0) && Jugador.Estado == "Idle")
        {
            Jugador.Anim.Play("Movimiento");    
        }

        Vector3 Move = new Vector3(hor, 0, ver) * Jugador.Velocidad;
        Controller.Move(Move);

        //rotar personaje cuando sigue al mouse en un plano invisible
        Plane playerplane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist;
        if (playerplane.Raycast(ray, out hitdist))
        {
            Vector3 puntomira = ray.GetPoint(hitdist);
            Quaternion puntorotacion = Quaternion.LookRotation(puntomira - transform.position);
            transform.rotation = (Quaternion.Slerp(transform.rotation, puntorotacion, 50f * Time.deltaTime));//realentiza un poco la rotacion del personaje para que no sea intantanea
        }
    }

    private void LateUpdate()
    {
        //la camaa sigue al jugador
        Vector3 puntoPosicion = transform.position + new Vector3(0, 50, 0);
        Vector3 nuevaPosicion = Vector3.MoveTowards(Jugador.Cam.transform.position, puntoPosicion, 150f * Time.deltaTime);
        Jugador.Cam.transform.position = nuevaPosicion;
    }
}
