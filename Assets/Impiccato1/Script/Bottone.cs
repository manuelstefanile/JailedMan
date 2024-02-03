using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Bottone : MonoBehaviour
{
    
    private Color startColor ;
    public Color endColor;
    private bool attiva=false;
    public GameObject oggettoEnable;
    public GameObject oggettoDisable;
    public bool exitButton;

    void Start(){

        if(endColor==new Color(0.000f, 0.000f, 0.000f, 0.000f)){
            endColor=Color.yellow;
        }
        startColor=transform.GetChild(0).GetComponent<Renderer>().material.color;
    }
 
    public void attivadisattivaAnimazione(){  
        if(this.isActiveAndEnabled){     
        Animator animazioneBottone=this.GetComponent<Animator>();
        if(animazioneBottone.GetBool("Attivo")){
            animazioneBottone.SetBool("Attivo",false);
            StartCoroutine(reverseColor(endColor,startColor));
            attiva=false;
        }else {
            animazioneBottone.SetBool("Attivo",true);
            StartCoroutine(reverseColor(startColor,endColor));
            attiva=true;
        }
        }
        

    }
      private IEnumerator reverseColor(Color colorA,Color colorB){
        float duration = 0.7f;  // Durata del movimento in secondi
        float startTime = Time.time;
        while (Time.time - startTime < duration)
        {
             float t = (Time.time - startTime) / duration;
            Color lerpedColor = Color.Lerp(colorA, colorB, t);
            transform.GetChild(0).GetComponent<Renderer>().material.color = lerpedColor;
            yield return null;
        }
        
        
     }
     private IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(0.3f);
        transform.parent.gameObject.GetComponent<BoxCollider>().enabled=true;
    }
     private void OnEnable()
    {
        transform.parent.gameObject.GetComponent<BoxCollider>().enabled=false;
        StartCoroutine(DelayedAction());
    }


     public void FunzioneBottone(){

        if(exitButton){
            GetComponent<ScriptMenu>().exitApplicazione();
            return;
        }
        transform.GetChild(0).GetComponent<Renderer>().material.color=startColor;
        oggettoEnable.SetActive(true);
        oggettoDisable.SetActive(false);
     }

}