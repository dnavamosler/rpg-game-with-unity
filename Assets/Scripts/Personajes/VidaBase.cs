using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBase : MonoBehaviour
{

    [SerializeField] protected float saludInicial;
    [SerializeField] protected float saludMax;

    /*Esta propiedad puede ser vista por otras clases.. pero no modificada*/
    public float Salud { get;protected set; }
    
    // Start is called before the first frame update
   protected virtual void Start()
    {
        Salud = saludInicial;
    }

    /*Logica para recibir un daño*/
    public void RecibirDanio(float cantidad)
    {
        if (cantidad <= 0)
            return;

        /*Si tenemos salud, dañamos al personaje*/
        if (Salud > 0)
        {
            Salud -= cantidad;
            ActualizarBarraVida(Salud,saludMax);
            /*Si el personaje fue derrotado*/
            if (Salud <= 0f)
            {
                ActualizarBarraVida(Salud,saludMax);
                PersonajeDerrotado();
            }
        }
        
        
        
    }

    /*Virtual sirve para hacer override en otra clase al ser heredado*/
    protected virtual void ActualizarBarraVida(float vidaActual,float vidaMax)
    {
        
    }

    protected virtual void PersonajeDerrotado()
    {
        
    }
}
