using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeAnimaciones : MonoBehaviour
{

    [SerializeField] private string LayerIdle;
    [SerializeField] private string LayerCaminar;
    
    /*Detectar la animación.*/
    private Animator _animator;
    /*Obtener la clase personajeMovimiento*/
    private PersonajeMovimiento _personajeMovimiento;
    
    /*Utilizar string To hashs*/
    /*Nos sirve para almacenar constantes del animator*/
    private readonly int direccionX = Animator.StringToHash("X");
    private readonly int direccionY = Animator.StringToHash("Y");
    private readonly int derrotado = Animator.StringToHash("Derrotado");
    private void Awake()
    {
        /*Capturar el componente de animación*/
        _animator = GetComponent<Animator>();
        _personajeMovimiento = GetComponent<PersonajeMovimiento>();
    }


    private void Update()
    {
        /*Actualizar los layers segun corresponda*/
        ActualizarLayers();
        /*Si el personaje no esta moviendose terminamos*/
        if (!_personajeMovimiento.EnMovimiento)
        {
            
            return;
        }
        
        /*Actualizar parametros de Animation*/
        _animator.SetFloat(direccionX,_personajeMovimiento.DireccionMovimiento.x);
        _animator.SetFloat(direccionY,_personajeMovimiento.DireccionMovimiento.y);
    }


    private void ActivarLayer(string NombreLayer)
    {
        /*Desactivar el resto de layers*/
        for (int i = 0; i < _animator.layerCount; i++)
        {
            _animator.SetLayerWeight(i,0f);
        }
        /*Activar un layer*/
        _animator.SetLayerWeight(_animator.GetLayerIndex(NombreLayer),1);
    }

    private void ActualizarLayers()
    {
        if (_personajeMovimiento.EnMovimiento)
        {
            ActivarLayer(LayerCaminar);
        }
        else
        {
            ActivarLayer(LayerIdle);
        }
    }

    public void RevivirPersonaje()
    {
        ActivarLayer(LayerIdle);
        _animator.SetBool(derrotado,false);
    }

    private void PersonajeDerrotadoRespuesta()
    {
        if (_animator.GetLayerWeight(_animator.GetLayerIndex(LayerIdle)) == 1)
        {
            _animator.SetBool(derrotado,true);
        }
    }
    /*Es llamado cuando la clase es activada*/
    private void OnEnable()
    {
        PersonajeVida.EventoPersonajeDerrotado += PersonajeDerrotadoRespuesta;
    }

    /*Cuando la clase se desactiva*/
    private void OnDisable()
    {
        PersonajeVida.EventoPersonajeDerrotado -= PersonajeDerrotadoRespuesta;
    }
}
