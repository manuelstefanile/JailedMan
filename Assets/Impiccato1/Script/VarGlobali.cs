using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;


public class VarGlobali : MonoBehaviour
{
    public bool fineGioco=false;
    public String parola;
    public string suggerimento;
    public String[] arrayParole;
    /*******/
    private WordsContainer paroleESugg;
    /*******/
    public Vector3[] arrayPosizioniLettere;
    public GameObject[] paretiGabbia;
    public Material galera;
    public Material galeraParole;
    public int vite;
    public int paroleCompletate=0;
    public GameObject torcia;
    //per notificare che è stato caricato il globalScript
     private bool scriptAStarted = false;
     public GameObject sconfitta;


    public GameObject[] testiScore;
    public GameObject[] testiLife;
     public Punti score;
     public int lettereConsec=0;
     public bool useHint=false;

     public GameObject testoScoreAnimazionePrefab;
     //0,1,2,3,4,5,6,7,8,9,,
     public Sprite[] numeri;
     

    void Start(){
        paroleESugg=GameObject.FindWithTag("JSON").GetComponent<JsonParole>().GetListaParole();
        WordAndHint p= paroleESugg.words[UnityEngine.Random.Range(0,paroleESugg.words.Count-1)];
        parola=p.word;
        suggerimento=p.hint;
        GameObject.FindWithTag("TestoLuce").GetComponent<TextMeshProUGUI>().text=suggerimento;

        score=new Punti();

        arrayPosizioniLettere= new Vector3[parola.Length];
        parola=parola.ToUpper();
        Debug.Log(parola);
        vite=6;
        scriptAStarted = true;

        SettaTestoLife();
        //setto la parola per quando perdo
        GameObject.Find("TextWordLose").GetComponent<TextMeshProUGUI>().text="World: " + parola;
        
    }
    private void SettaTestoLife(){
        foreach(GameObject lif in testiLife){
            lif.GetComponent<TextMeshProUGUI>().text=vite.ToString();
        }
    }
    public void SottraiVarVita(){
        vite--;
        SettaTestoLife();
        //setta il testo di life di vittoria e sconfitta
    }
    //mi dice se lo script è stato caricato o meno
    public bool IsScriptAStarted()
    {
        return scriptAStarted;
    }
    public void SottraiVita(){
        
        if(SceneManager.GetActiveScene().name.Equals("Impiccato_Livello_1")){
            GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
            SottraiVarVita();
            Debug.Log("vite 1 Livello" + vite);
            switch (vite)
            {
                case 5:
                    GameObject parete1= GameObject.Find("Parete1");
                    GameObject parete2= GameObject.Find("Parete2");
                    GameObject parete3= GameObject.Find("Parete3");
                    GameObject parete4= GameObject.Find("Parete4");
                    GameObject planeGiocatore= GameObject.Find("PlaneGiocatore");
                    GameObject pareteParola= GameObject.Find("PareteParola");
                    GameObject planeParola= GameObject.Find("PlaneParola");
                    parete1.GetComponent<Renderer>().material=galera;
                    parete2.GetComponent<Renderer>().material=galera;
                    parete3.GetComponent<Renderer>().material=galera;
                    parete4.GetComponent<Renderer>().material=galera;
                    planeGiocatore.GetComponent<Renderer>().material=galera;
                    pareteParola.GetComponent<Renderer>().material=galeraParole;
                    planeParola.GetComponent<Renderer>().material=galeraParole;
                    break;
                case 4:
                    GameObject gabbia1=paretiGabbia[0];
                    Galera varg=gabbia1.GetComponent<Galera>();
                    varg.follow=true;
                    GameObject[] lampadari =GameObject.FindGameObjectsWithTag("Lampadario");
                    foreach(GameObject lampadario in lampadari){
                        lampadario.GetComponent<LampadarioLuce>().Lampeggioalternato();
                    }
                    
                    torcia.SetActive(true);
                    break;
                case 3:
                    GameObject gabbia2=paretiGabbia[1];
                    Galera varg2=gabbia2.GetComponent<Galera>();
                    varg2.follow=true;
                    break;
                case 2:
                    GameObject gabbia3=paretiGabbia[2];
                    Galera varg3=gabbia3.GetComponent<Galera>();
                    varg3.follow=true;
                    break;
                case 1:
                    GameObject gabbia4=paretiGabbia[3];
                    Galera varg4=gabbia4.GetComponent<Galera>();
                    varg4.follow=true;
                    break;
                case 0:
                    GameObject gabbia5=paretiGabbia[4];
                    Galera varg5=gabbia5.GetComponent<Galera>();
                    varg5.follow=true;
                    fineGioco=true;
                    sconfitta.SetActive(true);
                    sconfitta.GetComponents<AudioSource>()[1].Play();
                    FindObjectOfType<TextureBeW>().settaTextureBeW();
                    break;
                default:break;
            }
        }
                    
    }



//trova gli oggetti anche non attivi in scena;
    private GameObject TrovaOggettoPerNome(String oggetto){
        GameObject[] tuttiGliOggetti = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject ogg in tuttiGliOggetti)
        {
            if (ogg.name == oggetto)
            {
                return ogg;
            }
        }
        return null;
    }

    public int paroleMancanti(){
        return parola.Length-paroleCompletate;
    }

    public void AssegnaEMostraPunti(GameObject letteraRiferimento){
        //setto lo score
        score.AddPointScore(vite,useHint,lettereConsec);
        //assegno lo score a tutti i menu
        foreach(GameObject testo in testiScore){
            testo.GetComponent<TextMeshProUGUI>().text="Score: "+score.score.ToString();
        }
        
        





        GameObject instanzPrefScore=Instantiate(testoScoreAnimazionePrefab,letteraRiferimento.transform.position,letteraRiferimento.transform.rotation);
        instanzPrefScore.name="EffettoTestoPoint";
        instanzPrefScore.GetComponent<ParticleSystem>().Stop(true);
        int posizioneArray=0;
        int i=0;
        //analizzo numero per numero lo score
         foreach(char c in score.score.ToString()){
            
                Debug.Log("c= "+ c);
                //utilizzo la differrenza in carattere ASCII per convertire il numero
                int numeroStamp=c-'0';
                if(numeroStamp>=0){
                    posizioneArray=numeroStamp;
                }else{
                                
                Debug.Log("virgola");
                //vuol dire che è la virgola
                posizioneArray=10;                    
                }
                
            Debug.Log("!! posiarray "+ posizioneArray);
            //prendo il particlesystem del game obj lettera
            ParticleSystem partSistem=instanzPrefScore.transform.GetChild(i).GetComponent<ParticleSystem>();
            Debug.Log("nome della lettera = "+ partSistem.name);
            ParticleSystem.TextureSheetAnimationModule part=partSistem.textureSheetAnimation;
            part.mode=ParticleSystemAnimationMode.Sprites;
            Debug.Log("size= "+ numeri[posizioneArray]);
            
            
            part.SetSprite(0,numeri[posizioneArray]);
            i++;
         }
         //elimina i figli in eccesso
         for(int p=0;p<instanzPrefScore.transform.childCount;p++){
            if(p>=i){
                GameObject figlio = instanzPrefScore.transform.GetChild(p).gameObject;
                Destroy(figlio);
            }
         }
         instanzPrefScore.GetComponent<ParticleSystem>().Play(true);
         
        
    }
       
}
