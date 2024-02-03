using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestoIlluminato : MonoBehaviour
{

    public Light lightSource; // Assegna la sorgente luminosa desiderata nell'Editor di Unity
    private TextMeshProUGUI rend;
    private bool illuminato;
    private VarGlobali globali;

    void Start(){
        globali=FindAnyObjectByType<VarGlobali>();
        illuminato=false;
        rend=this.GetComponent<TextMeshProUGUI>();
        Color colore = rend.color;
        colore.a=0f;
        rend.color=colore;
        

        
    }


    void Update(){

    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Torcia"))
        {
            Debug.Log("dentro");
            //segnallo che ho usato il suggerimento
            if(!globali.useHint)globali.useHint=true;
            StartCoroutine(OpacityInTime(0.6f));
            // Esegui azioni specifiche quando l'oggetto viene colpito dalla luce
        }
    }
    void OnTriggerExit(Collider obj){
        if (obj.gameObject.CompareTag("Torcia"))
        {
            StartCoroutine(OpacityInTime(0f));
            Debug.Log("fuori");
            
            // Esegui azioni specifiche quando l'oggetto viene colpito dalla luce
        }
    }
    public IEnumerator OpacityInTime(float valore){
         float elapsedTime = 0.0f;
        float startOpacity = rend.color.a;
        Color objectColor = rend.color;

        while (elapsedTime < 0.3f)
        {
            elapsedTime += Time.deltaTime;

            // Calcola l'opacità in base al tempo trascorso
            float newOpacity = Mathf.Lerp(startOpacity, valore, elapsedTime / 0.3f);

            // Imposta il colore dell'oggetto con la nuova opacità
            objectColor.a = newOpacity;
            rend.color = objectColor;

            yield return null;
        }

        // Assicurati che l'oggetto sia completamente trasparente alla fine
        objectColor.a = valore;
        rend.color = objectColor;
    }

    public void InizioCoroutine(float valore){
        StartCoroutine(OpacityInTime(valore));
    }

    
}