using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;

public class Inizzializzazione : MonoBehaviour
{
    public GameObject postazione;
    public GameObject tassello;
    private GameObject[] arrayPosizione;
    private GameObject[] arrayTassello;
    private List<Material> materialiColor=new List<Material>();
    private bool scriptAStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        Material[] TuttiMaterial = Resources.LoadAll<Material>("Material");
        foreach(Material mat in TuttiMaterial){
            
            if(mat.ToString().StartsWith("Color_")){
            
                materialiColor.Add(mat);
            }
        }

        
        //Vector3 posizioneTassello= tassello.transform.position;
        Vector3 posizionePostazione= postazione.transform.position;
        Vector3 posizioneTassello= tassello.transform.position;

        arrayPosizione= new GameObject[26];
        arrayTassello = new GameObject[26];

        TextMeshPro letteraTassello=tassello.transform.GetChild(0).GetComponent<TextMeshPro>();
        char lettera='A';
        letteraTassello.text=lettera.ToString();
        int j=0;
        arrayPosizione.Append(postazione);
        arrayTassello.Append(tassello);
        
        for(int i=0;i<25;i++){
            if((i+1)%9==0){
                posizionePostazione = posizionePostazione+ new Vector3(0,2.0f,0);
                posizioneTassello = posizioneTassello + new Vector3(0,2.0f,0);
                j=-3;
            }
            GameObject oggettoPostazione=Instantiate(postazione,posizionePostazione+new Vector3(0,0,j+3),postazione.transform.rotation);
            GameObject oggettoTassello=Instantiate(tassello,posizioneTassello+new Vector3(0,0,j+3),tassello.transform.rotation);
            
            lettera++;
            oggettoPostazione.name="Postazione"+lettera.ToString();
            oggettoTassello.name=lettera.ToString();
            
            oggettoTassello.transform.GetChild(0).GetComponent<TextMeshPro>().text=lettera.ToString();
            oggettoTassello.transform.GetChild(1).GetComponent<TextMeshPro>().text=lettera.ToString();
            oggettoTassello.transform.GetChild(2).GetComponent<TextMeshPro>().text=lettera.ToString();
            oggettoTassello.transform.GetChild(3).GetComponent<TextMeshPro>().text=lettera.ToString();
            oggettoTassello.transform.GetChild(4).GetComponent<TextMeshPro>().text=lettera.ToString();
            oggettoTassello.transform.GetChild(5).GetComponent<TextMeshPro>().text=lettera.ToString();

            Renderer tasselloOggColore=oggettoTassello.transform.GetChild(6).GetComponent<Renderer>();

            //devo per forza assegnare tutto l arrey di materiali
            Material[] materialsCopy = tasselloOggColore.materials; 
            if (materialsCopy.Length > 1)
                {
                    materialsCopy[1] = materialiColor[UnityEngine.Random.Range(0, materialiColor.Count)]; 
                    tasselloOggColore.materials = materialsCopy; 
                }  

            arrayPosizione.Append(oggettoPostazione);
            arrayTassello.Append(oggettoTassello);
            j+=3;
                
            scriptAStarted = true;
        }
    }

    // Update is called once per frame
    public bool IsScriptAStarted()
    {
        return scriptAStarted;
    }
}
