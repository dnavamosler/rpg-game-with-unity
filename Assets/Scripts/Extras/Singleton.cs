using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*Esta clase debe poder heredarse por cualquier clase --> para ello usamos <T> y debe ser MonoBehaviour donde
 la T es un componente*/
public class Singleton<T> : MonoBehaviour where T : Component
{
    /*La t hace refencia a la clase que esta heredando*/
    private static T _instance;
    
    /*Instancia publica que hace referencia a la instancia que podemos llamar de la clase para acceder a sus metodos*/
    public static T Instance
    {
        get
        {
            /*No tenemos la instancia que queremos aun*/
            if (_instance == null)
            {
                /*Buscamos la instancia que necesitamos*/
                _instance = FindObjectOfType<T>();
                
                /*Si aún no tenemos la referencia.. debemos obtenerla a la fuerza*/
                if (_instance == null)
                {
                    
                    GameObject nuevoGO = new GameObject();
                    _instance = nuevoGO.AddComponent<T>();
                }
                
            }

            return _instance;
        }
    }

    protected  virtual void Awake()
    {
        _instance = this as T;
    }
}
