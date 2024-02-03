using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
using UnityEngine.SceneManagement;
public class TextureBeW : MonoBehaviour
{
    Dictionary<Renderer,Texture> textOriginal=new Dictionary<Renderer, Texture>();
    public bool VoS;
    
    // Start is called before the first frame update
    public void settaTextureBeW()
    {
        Renderer[] render=FindObjectsOfType<Renderer>();
        
        foreach(Renderer re in render){
           if(re.GetComponent<TextMeshPro>() == null) {
            if(!re.name.StartsWith("GoodJob")){
                if(!re.name.StartsWith("Macharena")){
                    if(!re.name.StartsWith("osso")){
                        if(!re.name.StartsWith("testa")){
                            if(!re.name.StartsWith("denti")){
                                if(!re.name.StartsWith("YouLose")){
                                    if(!re.name.StartsWith("Clone")){
                                        if(!re.name.StartsWith("hands")){
                                        
                                            textOriginal.Add(re,re.material.mainTexture);
                                            re.material.mainTexture=null;
                                            if(!VoS)
                                                re.material.color=Color.black;
                                            }
                                    
                                        }
                                    }
                            }
                        }
                    }
                }
            
            }
           }
           if(re.tag.Equals("Lettera")&&!re.name.StartsWith("Clone")){
            GameObject cuboMesh=re.transform.GetChild(6).gameObject;
            Debug.Log("****devo lettera " + re.name);
            foreach(Material materialeLettera in cuboMesh.GetComponent<Renderer>().materials){
                if(VoS)
                    materialeLettera.color=Color.white;
                else materialeLettera.color=Color.black;
            }
           }
 
        }

        
        
    }

    // Update is called once per frame
    public void ripristinaTexture(){
/*        foreach(var re in textOriginal){
            re.Key.material.mainTexture=re.Value;

        }*/
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    } 
}
