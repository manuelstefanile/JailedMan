using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class RightGrab : MonoBehaviour
{
    private bool startNoStar=false;
    private bool startNoSound=false;
    private Color[] colori=new Color[3];
    public Texture texturePalette;
    public InputActionProperty gripAction;
    private  Renderer rend;
    private int count=0;
    
    
    void Start(){
        rend=transform.GetChild(6).GetComponent<Renderer>();
         Material[] materialirend= rend.materials;
        int i=0;
        foreach(Material mat in materialirend){
            
            colori[i]=mat.color;
            i++;
        }
    }
    
    // Start is called before the first frame update
    public void Stelle(){
        if(startNoStar){
            GameObject star=GameObject.FindGameObjectWithTag("Star");
        
            for(int i=0;i<5;i++){
                Vector3 spawnPosition = RandomCircle(this.transform.position, 0.6f);
                GameObject st=Instantiate(star,spawnPosition,this.transform.rotation);
                st.GetComponent<MeshRenderer>().enabled=true;
                st.GetComponent<StarScript>().enabled=true;
                float randomX = UnityEngine.Random.Range(0f, 360f);
                float randomY =  UnityEngine.Random.Range(0f, 360f);
                float randomZ =  UnityEngine.Random.Range(0f, 360f);
            // Applica la rotazione randomica all'oggetto
                st.transform.rotation = Quaternion.Euler(randomX, randomY, randomZ);

            }
        }else startNoStar=true;
        

    }
        Vector3 RandomCircle(Vector3 center, float radius)
    {
        float angle = UnityEngine.Random.Range(0f, 360f);
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        pos.y = center.y;
        pos.z = center.z + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        return pos;
    }

    public void FirstHoverEnter(){
        
        if(count>=2){
            transform.GetChild(0).GetComponent<TextMeshPro>().color=Color.black;
            transform.GetChild(1).GetComponent<TextMeshPro>().color=Color.black;
            transform.GetChild(2).GetComponent<TextMeshPro>().color=Color.black;
            transform.GetChild(3).GetComponent<TextMeshPro>().color=Color.black;
            transform.GetChild(4).GetComponent<TextMeshPro>().color=Color.black;
            transform.GetChild(5).GetComponent<TextMeshPro>().color=Color.black;
            Material[] materialirend= rend.materials;
        
            foreach(Material mat in materialirend){
                mat.color=Color.white;

                mat.mainTexture=null;
            
            }
            float gripValue= gripAction.action.ReadValue<float>();

            if(gripValue==1){
                FirstHoverExit();
            }
            }
        count++;
        
        
          
        
        
        
        
    }
    public void FirstHoverExit(){
        
        
        transform.GetChild(0).GetComponent<TextMeshPro>().color=Color.white;
        transform.GetChild(1).GetComponent<TextMeshPro>().color=Color.white;
        transform.GetChild(2).GetComponent<TextMeshPro>().color=Color.white;
        transform.GetChild(3).GetComponent<TextMeshPro>().color=Color.white;
        transform.GetChild(4).GetComponent<TextMeshPro>().color=Color.white;
        transform.GetChild(5).GetComponent<TextMeshPro>().color=Color.white;
        Material[] materialirend= rend.materials;
        int i=0;
        foreach(Material mat in materialirend){
            
            mat.color=colori[i];
            Color mm=mat.color;
            mm.a=1f;
            
            
            if(mat.name.StartsWith("base"))
                mat.mainTexture=texturePalette;
            i++;
        }
        
    }
    public void SoundGrip(){
        if(startNoSound){
            GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        }else startNoSound=true;
    }
}
