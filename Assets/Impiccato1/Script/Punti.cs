using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punti 
{
    private float point=1.4f;
    private float pointAdd= 0.1f;
    public float score=0;


    public void AddPointScore(int vite,bool usoHint,int consec){
        float moltiplicatore=0;
        float puntiDaAssegnare=0f;
        //consec = 3 allora 0.01*3 = o.003 allora point
        switch(vite){
            case 6:
            case 5:
                moltiplicatore=3;
                puntiDaAssegnare=consec==1?moltiplicatore:moltiplicatore+(point+(pointAdd*(consec-1)));
                break;
            case 4:
            case 3:
            case 2:
            case 1:
                moltiplicatore=usoHint?1.5f:2;
                puntiDaAssegnare=consec==1?moltiplicatore:moltiplicatore+(point+(pointAdd*(consec-1)));
                break;
        }
        score+=puntiDaAssegnare;
    }

}
