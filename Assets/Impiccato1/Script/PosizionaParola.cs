using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PosizionaParola : MonoBehaviour
{
    private Transform targetPosition;
    
    private VarGlobali globali;
    private bool parolaCheck=false;
    public GameObject goodJob;
    public GameObject mainCamera;
    // Start is called before the first frame update

    void Start(){
        globali=FindAnyObjectByType<VarGlobali>();
        
    }
     void OnCollisionEnter(Collision c)
    {
        
        if(c.gameObject.tag.Equals("Lettera")&&!c.gameObject.GetComponent<Blocco>().onCollision&&!globali.fineGioco){
            c.gameObject.GetComponent<Blocco>().onCollision=true;
            String parola = globali.parola;
            for(int i=0;i<globali.parola.Length;i++){
                if(parola[i].Equals(c.gameObject.name[0])){
                    parolaCheck=true;
                    c.gameObject.SetActive(false);

                    GameObject lettera= Instantiate(c.gameObject,c.transform.position,c.transform.rotation);
                    lettera.name="Clone"+lettera.name;
                    lettera.transform.GetChild(0).gameObject.name="Clone"+lettera.transform.GetChild(0).gameObject.name;
                    lettera.transform.GetChild(1).gameObject.name="Clone"+lettera.transform.GetChild(1).gameObject.name;
                    lettera.transform.GetChild(2).gameObject.name="Clone"+lettera.transform.GetChild(2).gameObject.name;
                    lettera.transform.GetChild(3).gameObject.name="Clone"+lettera.transform.GetChild(3).gameObject.name;
                    lettera.transform.GetChild(4).gameObject.name="Clone"+lettera.transform.GetChild(4).gameObject.name;
                    lettera.transform.GetChild(5).gameObject.name="Clone"+lettera.transform.GetChild(5).gameObject.name;
                    lettera.transform.GetChild(6).gameObject.name="Clone"+lettera.transform.GetChild(6).gameObject.name;
                    lettera.SetActive(true);
                    lettera.GetComponent<Rigidbody>().isKinematic=true;
                    lettera.GetComponent<XRGrabInteractable>().interactionLayers=LayerMask.GetMask("NoGrab");
                    //riproduci il suono se la lettera è corretta
                    lettera.GetComponents<AudioSource>()[1].PlayOneShot(lettera.GetComponents<AudioSource>()[1].clip);
                    StartCoroutine(MoveObjectToB(lettera,globali.arrayPosizioniLettere[i]));  
                    globali.paroleCompletate++;
                }
            }
            StartCoroutine(ReduceSize(c.gameObject)); 
            //se hai sbagliato la lettera 
            if(!parolaCheck){
                
                globali.SottraiVita(); 
                globali.lettereConsec=0;     
            //altrimenti
            }else {
                
                globali.lettereConsec++;
                //passo la poszione della lettera
                globali.AssegnaEMostraPunti(c.gameObject);
                //vittoria se completa la parola
                if(globali.paroleMancanti()==0){
                    GameObject buonLavoro=Instantiate(goodJob,mainCamera.transform.position,mainCamera.transform.rotation);
                    buonLavoro.SetActive(true);                    
                    buonLavoro.GetComponent<AudioSource>().Play();

                    globali.fineGioco=true;

                    FindObjectOfType<TextureBeW>().settaTextureBeW();
                    if(goodJob!=null)Destroy(goodJob);
                }
            }
            parolaCheck=false;
            //vittoria se completa la parola
        }else{
            return;
        } 
    }

     private IEnumerator ReduceSize(GameObject obj){
        Vector3 scaleStart= obj.transform.localScale;
        float duration = 2.0f;  // Durata del movimento in secondi
        float startTime = Time.time;
        while (Time.time - startTime < duration)
        {
             float t = (Time.time - startTime) / duration;
             obj.transform.localScale=Vector3.Lerp(scaleStart,Vector3.zero,t);
             yield return null;
        }
        obj.transform.localScale=Vector3.zero;
        Destroy(obj);
     }

    private IEnumerator MoveObjectToB(GameObject obj,Vector3 puntoB)
    {
        Vector3 pointA = obj.transform.position;  // Posizione attuale dell'oggetto
        float duration = 2.0f;  // Durata del movimento in secondi
        float startTime = Time.time;
        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            obj.transform.position = Vector3.Lerp(pointA, puntoB, t);

            // Calcola l'angolo di rotazione sull'asse Y
            float rotationAngle = Mathf.Lerp(0, 90, t);
            obj.transform.rotation = Quaternion.Euler(0, rotationAngle, 0);
            
            yield return null;
        }
    obj.transform.position = puntoB;
    }

    

}
