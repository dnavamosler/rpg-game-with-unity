using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeExperiencia : MonoBehaviour
{

    [SerializeField] private int nivelMax;
    [SerializeField] private int expBase;
    [SerializeField] private int valorIncremental;

    public int Nivel { get; set; }

    private float expActualTemp;
    private float expRequeridaSiguienteNivel;
    private void Start()
    {
        Nivel = 1;
        expRequeridaSiguienteNivel = expBase;
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
                ActualizarNivel();
                AddExperience(expObtenida);
            }
            else
            {
                expActualTemp += expObtenida;
                if (expActualTemp == expRestanteNuevoNivel)
                {
                    ActualizarNivel();
                }
            }
        }

        ActualizarBarraExp();
    }

    private void ActualizarNivel()
    {
        /*Actualizar
         experiencia requerida
         el nivel
         experiencia actual temporal
         */

        if (Nivel < nivelMax)
        {
            Nivel++;
            expActualTemp = 0f;
            expRequeridaSiguienteNivel *= valorIncremental;
        }
    }

    private void ActualizarBarraExp()
    {
        UiManager.Instance.ActualizarExpPersonaje(expActualTemp,expRequeridaSiguienteNivel);
    }
}
