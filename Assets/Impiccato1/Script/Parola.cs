using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Parola : MonoBehaviour
{
    public GameObject pareteTessera;
    public GameObject tessera;
    private GameObject[] arrayParete;
    private VarGlobali globali;
    public Material materialePareteParola;
    
    // Start is called before the first frame update
    void Start()
    {
        //Attendo che lo start delle var.globali sia caricato.
        StartCoroutine(WaitForScriptAStart());
    }
     private IEnumerator WaitForScriptAStart()
    {
        // Cerca l'oggetto contenente lo Script A
        globali = FindAnyObjectByType<VarGlobali>();

        // Aspetta finché lo Start() di Script globale non è stato completato
        while (globali == null || !globali.IsScriptAStarted())
        {
            yield return null;
        }
         
        //una volta completato, eseguo questo codice 
        arrayParete=new GameObject[globali.parola.Length];
        Vector3 spawnLoc=this.GetComponent<Transform>().position+new Vector3(-5.2f,0,0f);

        Quaternion rotazione=pareteTessera.transform.rotation;
        rotazione *= Quaternion.Euler(0, 90, 0);

        for(int i=0;i<globali.parola.Length;i++){

            spawnLoc=spawnLoc-new Vector3(-1.5f,0,0);
            GameObject oggettoParete=Instantiate(pareteTessera,spawnLoc,rotazione);
            oggettoParete.name="SoluzioneParete"+globali.parola[i];
            oggettoParete.GetComponent<Renderer>().material=materialePareteParola;
            oggettoParete.GetComponent<XRSocketInteractor>().enabled=false;
            globali.arrayPosizioniLettere[i]=spawnLoc;

        }

    }

}
