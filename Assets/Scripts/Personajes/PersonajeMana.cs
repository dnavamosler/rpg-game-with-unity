using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PersonajeMana : MonoBehaviour
{
    [SerializeField] private float manaInicial;
    [SerializeField] private float manaMax;
    [SerializeField] private float regeneracionPorSegundo;

    
    
    public float ManaActual { get; private set; }

    private PersonajeVida _personajeVida;

    private void Awake()
    {
        _personajeVida = GetComponent<PersonajeVida>();
    }

    private void Start()
    {
        ManaActual = manaInicial;
        ActualizarBarraMana();
        
        InvokeRepeating(nameof(RegenerarMana),1,1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            UsarMana(10);
        }
    }

    public void UsarMana(float cantidad)
    {
        if (ManaActual >= cantidad)
        {
            ManaActual -= cantidad;
            ActualizarBarraMana();
        }
        
        
    }

    private void RegenerarMana()
    {
        if (_personajeVida.Salud > 0 && ManaActual < manaMax)
        {
            ManaActual += regeneracionPorSegundo;
            ActualizarBarraMana();
        }
    }

    public void RestablecerMana()
    {
        ManaActual = manaInicial;
        ActualizarBarraMana();
    }
    
    private void ActualizarBarraMana()
    {
        UiManager.Instance.ActualizarManaPersonaje(ManaActual,manaMax);
    }
}
