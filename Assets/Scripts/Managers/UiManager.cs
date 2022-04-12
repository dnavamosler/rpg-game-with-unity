using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    /*Crear singleton*/
    public static UiManager Instance;
    
    [Header("Config")]
    [SerializeField] private Image vidaPlayer;
    [SerializeField] private TextMeshProUGUI VidaTMP;

    private float vidaActual;
    private float vidaMax;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarUiPersonaje();
    }

    private void ActualizarUiPersonaje()
    {
        vidaPlayer.fillAmount = Mathf.Lerp(vidaPlayer.fillAmount,
            vidaActual / vidaMax, 10f * Time.deltaTime);

        VidaTMP.text = $"{vidaActual}/{vidaMax}";
    }
    
    public void ActualizarVidaPersonaje(float pVidaActual, float pVidaMax)
    {
        vidaActual = pVidaActual;
        vidaMax = pVidaMax;
    }
}
