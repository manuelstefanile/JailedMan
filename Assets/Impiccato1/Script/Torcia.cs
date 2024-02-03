using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Torcia : MonoBehaviour
{    GameObject torciaFiglio;
    public GameObject testoIlluminato;
    public bool attiva;
    private Collider[] colList ;
    // Start is called before the first frame update
    void Start()
    {
        attiva=false;
        torciaFiglio=this.transform.Find("Luce").gameObject;

        //prendi lo script del grab
        XRGrabInteractable xrg=GetComponent<XRGrabInteractable>();

        colList = torciaFiglio.transform.GetComponentsInChildren<Collider>();
        foreach(Collider col in colList){
            col.enabled=false;
        }
        
        //ogni volta che premi il tasto sx del mouse(quando hai preso l oggetto)
        xrg.activated.AddListener(esegui);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //spegni o accendi la torcia e disattiva i collider della torcia
    //
    private void esegui(ActivateEventArgs arg){
        if(attiva){
            Debug.Log("spengo");
            torciaFiglio.GetComponent<Light>().enabled=false;
            foreach(Collider col in colList){
                col.enabled=false;
                }
            testoIlluminato.GetComponent<TestoIlluminato>().InizioCoroutine(0f);
            attiva=false;
        }
        else {
            Debug.Log("accendo");
            torciaFiglio.GetComponent<Light>().enabled=true;
            foreach(Collider col in colList){
            col.enabled=true;
        }
            attiva=true;
        }
        
        

    }

}
