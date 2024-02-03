using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using System;

public class RightXRInterazioni : MonoBehaviour
{
    private XRRayInteractor rayInteractor;
     public InputActionProperty triggerAction;
     private String oggettoInterazione;
     private Bottone pulsante;
    private void Start()
    {
        rayInteractor = GetComponent<XRRayInteractor>();
         
    
    
          
        rayInteractor.onHoverEntered.AddListener(OnHoverEntered);
        
        
        rayInteractor.onHoverExited.AddListener(OnHoverExited);
    }


    void Update(){
               if(oggettoInterazione!=null){
                    if(oggettoInterazione.Equals("BottoneNextOn")){
                        if(triggerAction.action.ReadValue<float>()==1){
                            //Debug.Log("clickBotton");
                            oggettoInterazione=null;
                            pulsante.FunzioneBottone();
                        }
                    }
               }
    }

    private void OnHoverEntered(XRBaseInteractable interactable)
    {
        // Questo metodo verrà chiamato quando l'evento onHoverEntered viene scatenato
        //Debug.Log("Il laser è entrato in contatto con qualcosa!" + interactable.gameObject.name);
        if(interactable.tag.Equals("BottoneNext")&&interactable.gameObject.GetComponent<BoxCollider>().enabled){
            pulsante=interactable.gameObject.transform.GetChild(0).GetComponent<Bottone>();            
            pulsante.attivadisattivaAnimazione();
            //Debug.Log("**enterButton");
            oggettoInterazione="BottoneNextOn";
        }
        // Puoi eseguire ulteriori azioni qui, ad esempio disabilitare il bottone, ecc.
       
    }

    private void OnHoverExited(XRBaseInteractable interactable)
    {
        // Questo metodo verrà chiamato quando l'evento onHoverExited viene scatenato
     //Debug.Log("Il laser è entrato in contatto con qualcosa!" + interactable.gameObject.name);
        if(interactable.tag.Equals("BottoneNext")&&interactable.gameObject.GetComponent<BoxCollider>().enabled){
            pulsante=interactable.gameObject.transform.GetChild(0).GetComponent<Bottone>();
            pulsante.attivadisattivaAnimazione();
            //Debug.Log("**exitButton");
            oggettoInterazione="BottoneNextOff";
        }
    }
}