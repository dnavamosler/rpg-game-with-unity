using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeExperiencia : MonoBehaviour
{

    [Header("stats")] 
    [SerializeField] private PersonajeStats Stats;
    
    [Header("Config")]
    [SerializeField] private int nivelMax;
    [SerializeField] private int expBase;
    [SerializeField] private int valorIncremental;


    private float expActual;
    private float expActualTemp;
    private float expRequeridaSiguienteNivel;
    private void Start()
    {
      
        Stats.Nivel = 1;
        expRequeridaSiguienteNivel = expBase;
        Stats.ExpRequeridaSiguienteNivel = expRequeridaSiguienteNivel;
        ActualizarBarraExp();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
           AddExperience(10); 
        }
    }

    public void AddExperience(float expObtenida)
    {
        if (expObtenida > 0f)
        {
            float expRestanteNuevoNivel = expRequeridaSiguienteNivel - expActualTemp;
            if (expObtenida >= expRestanteNuevoNivel)
            {
                expObtenida -= expRestanteNuevoNivel;
                expActual += expObtenida;
                ActualizarNivel();
                AddExperience(expObtenida);
            }
            else
            {
                expActual += expObtenida;
                expActualTemp += expObtenida;
                if (expActualTemp == expRestanteNuevoNivel)
                {
                    ActualizarNivel();
                }
            }
        }

        Stats.ExpActual = expActual;
        ActualizarBarraExp();
    }

    private void ActualizarNivel()
    {
        /*Actualizar
         experiencia requerida
         el nivel
         experiencia actual temporal
         */

        if (Stats.Nivel < nivelMax)
        {
            Stats.Nivel++;
            expActualTemp = 0f;
            expRequeridaSiguienteNivel *= valorIncremental;
            Stats.ExpRequeridaSiguienteNivel = expRequeridaSiguienteNivel;
        }
    }

    private void ActualizarBarraExp()
    {
        UiManager.Instance.ActualizarExpPersonaje(expActualTemp,expRequeridaSiguienteNivel);
    }
}
