using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeMovimiento : MonoBehaviour
{

    /*Forma actual de realizar un getter*/
    public Vector2 DireccionMovimiento => _direccionMovimiento;
    public bool EnMovimiento => _direccionMovimiento.magnitude > 0f;
    
    
   [SerializeField] private float velocidad;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _input;
    private Vector2 _direccionMovimiento;
    private PersonajeVida _personajeVida;
    
    private void Awake()
    {
        _personajeVida = GetComponent<PersonajeVida>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (_personajeVida.Derrotado)
        {
            return;
        }
        /*Capturar el input del usuario*/
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        /*Asignar correspondientemente los vectores X y Y*/
        _direccionMovimiento.x = _input.x > 0.1f ? 1f : _input.x < 0f ? -1f : 0f;
        _direccionMovimiento.y = _input.y > 0.1f ? 1f : _input.y < 0f ? -1f : 0f;
    }


    private void FixedUpdate()
    {
        /*Aplicar movimiento a posición correspondiente.*/
        _rigidbody2D.MovePosition(_rigidbody2D.position +_direccionMovimiento.normalized * velocidad * Time.fixedDeltaTime);
        
    }
}
