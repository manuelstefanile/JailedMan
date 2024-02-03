using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampadarioLuce : MonoBehaviour
{
    // Start is called before the first frame update
 public GameObject luceLampadario;


    // Update is called once per frame
    public void Lampeggioalternato(){
        StartCoroutine(LampeggioESpegnimento(luceLampadario.GetComponent<Light>(),5,0.6f));
    }
 
 IEnumerator LampeggioESpegnimento(Light luce,int numeroLampeggi,float intervallo)
    {
        for (int i = 0; i < numeroLampeggi; i++)
        {
            // Lampeggia la luce accendendola e spegnendola
            luce.enabled = !luce.enabled;
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.2f,intervallo));
        }

        // Spegni la luce dopo i lampeggi
        luce.enabled = false;
    }
}
