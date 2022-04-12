using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*Esta es la primera clase que usamos como Singleton*/
public class UiManager : Singleton<UiManager>
{
   
    
    [Header("Barra")]
    [SerializeField] private Image vidaPlayer;
    [SerializeField] private Image manaPlayer;
    [SerializeField] private Image expPlayer;
    
    [Header("Texto")]
    [SerializeField] private TextMeshProUGUI VidaTMP;
    [SerializeField] private TextMeshProUGUI ManaTMP;
    [SerializeField] private TextMeshProUGUI ExpTMP;

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
    }

    private void ActualizarUiPersonaje()
    {
        vidaPlayer.fillAmount = Mathf.Lerp(vidaPlayer.fillAmount,
            vidaActual / vidaMax, 10f * Time.deltaTime);

        manaPlayer.fillAmount = Mathf.Lerp(manaPlayer.fillAmount, manaActual / manaMax, 10f * Time.deltaTime);
        
        expPlayer.fillAmount = Mathf.Lerp(expPlayer.fillAmount, ExpActual / expRequeridaNuevoNivel, 10f * Time.deltaTime);
        
        
        VidaTMP.text = $"{vidaActual}/{vidaMax}";
        ManaTMP.text = $"{manaActual}/{manaMax}";
        ExpTMP.text = $"{ExpActual}/{expRequeridaNuevoNivel}";
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
