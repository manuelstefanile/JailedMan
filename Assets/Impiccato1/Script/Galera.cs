using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galera : MonoBehaviour
{
    public bool follow;
    public Vector3 offset;
    public Vector3 rotazione;
    private float velocita;
    public GameObject oggettoDaSeguire;
    private Vector3 posizioneReturn;
    private Quaternion rotazioneReturn;
    private float lerpTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        posizioneReturn=transform.position;
        rotazioneReturn=transform.rotation;
        velocita=5.0f;
        follow=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(follow){
            Vector3 direzione=oggettoDaSeguire.transform.position-this.transform.position;
            this.transform.position+=(direzione+offset)*velocita*Time.deltaTime;
            if(rotazione!=Vector3.zero){
                  Quaternion rotazioneObiettivo = Quaternion.Euler(direzione);
                  Quaternion offset=Quaternion.Euler(rotazione);
                   transform.rotation = Quaternion.Slerp(transform.rotation, rotazioneObiettivo*offset , velocita * Time.deltaTime);
            }

        }
        if(FindAnyObjectByType<VarGlobali>().fineGioco&&transform.position!=posizioneReturn){
            
            if(follow) follow=false;
             lerpTime += velocita * Time.deltaTime;        
             lerpTime = Mathf.Clamp01(lerpTime);
             transform.position = Vector3.Lerp(this.transform.position, posizioneReturn, lerpTime);
             transform.rotation = Quaternion.Lerp(this.transform.rotation, rotazioneReturn, lerpTime);

        }
    }
}
