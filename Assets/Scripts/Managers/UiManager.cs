using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*Esta es la primera clase que usamos como Singleton*/
public class UiManager : Singleton<UiManager>
{
    [Header("Stats")] 
    [SerializeField] private PersonajeStats stats;

    [Header("Paneles")] 
    [SerializeField] private GameObject panelStats;
    
    [Header("Barra")]
    [SerializeField] private Image vidaPlayer;
    [SerializeField] private Image manaPlayer;
    [SerializeField] private Image expPlayer;
    
    [Header("Texto")]
    [SerializeField] private TextMeshProUGUI VidaTMP;
    [SerializeField] private TextMeshProUGUI ManaTMP;
    [SerializeField] private TextMeshProUGUI ExpTMP;

    [Header("Stats")] 
    [SerializeField] private TextMeshProUGUI statDanioTMP;
    [SerializeField] private TextMeshProUGUI statDefensaTMP;
    [SerializeField] private TextMeshProUGUI statCriticoTMP;
    [SerializeField] private TextMeshProUGUI statBloqueoTMP;
    [SerializeField] private TextMeshProUGUI statVelocidadTMP;
    [SerializeField] private TextMeshProUGUI statNivelTMP;
    [SerializeField] private TextMeshProUGUI statExpTMP;
    [SerializeField] private TextMeshProUGUI statExpRequeridaTMP;
    
    private float vidaActual;
    private float manaActual;
    private float ExpActual;
    
    private float vidaMax;
    private float manaMax;
    private float expRequeridaNuevoNivel;

    

    // Update is called once per frame
    void Update()
    {
        ActualizarUiPersonaje();
        ActualizarPanelStats();
    }

    private void ActualizarUiPersonaje()
    {
        vidaPlayer.fillAmount = Mathf.Lerp(vidaPlayer.fillAmount,
            vidaActual / vidaMax, 10f * Time.deltaTime);

        manaPlayer.fillAmount = Mathf.Lerp(manaPlayer.fillAmount, manaActual / manaMax, 10f * Time.deltaTime);
        
        expPlayer.fillAmount = Mathf.Lerp(expPlayer.fillAmount, ExpActual / expRequeridaNuevoNivel, 10f * Time.deltaTime);
        
        
        VidaTMP.text = $"{vidaActual}/{vidaMax}";
        ManaTMP.text = $"{manaActual}/{manaMax}";
        ExpTMP.text = $"{((ExpActual/expRequeridaNuevoNivel)*100):F2}%";
    }

    private void ActualizarPanelStats()
    {
        if (panelStats.activeSelf == false)
        {
            return;
        }
        
        /*Actualizar estadisticas*/
        statDanioTMP.text = stats.Danio.ToString();
        statDefensaTMP.text = stats.Defensa.ToString();
        statCriticoTMP.text = $"{stats.PorcentajeCritico}%";
        statBloqueoTMP.text = $"{stats.PorcentajeBloqueo}%";
        statVelocidadTMP.text = stats.Velocidad.ToString();
        statNivelTMP.text = stats.Nivel.ToString();
        statExpTMP.text = stats.ExpActual.ToString();
        statExpRequeridaTMP.text = stats.ExpRequeridaSiguienteNivel.ToString();
    }
    
    public void ActualizarVidaPersonaje(float pVidaActual, float pVidaMax)
    {
        vidaActual = pVidaActual;
        vidaMax = pVidaMax;
    }


    public void ActualizarManaPersonaje(float pManaActual, float pManaMax)
    {
        manaActual = pManaActual;
        manaMax = pManaMax;
    }
    

    public void ActualizarExpPersonaje(float pExpActual, float pExpRequerida)
    {
        ExpActual = pExpActual;
        expRequeridaNuevoNivel = pExpRequerida;
        
    }
}
