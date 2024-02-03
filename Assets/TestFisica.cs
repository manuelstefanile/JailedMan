using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFisica : MonoBehaviour
{
    public CapsuleCollider camerab;
    private Inizzializzazione inizializzazioneVar;
    void Start()
    {
        StartCoroutine(WaitForScriptAStart());
        }
    

    private IEnumerator WaitForScriptAStart()
    {
        // Cerca l'oggetto contenente lo Script A
        inizializzazioneVar = FindAnyObjectByType<Inizzializzazione>();

        // Aspetta finché lo Start() di Script globale non è stato completato
        while (inizializzazioneVar == null || !inizializzazioneVar.IsScriptAStarted())
        {
            yield return null;
        }
         GameObject[] objectsToIgnore = GameObject.FindGameObjectsWithTag("Lettera");
        foreach (GameObject obj1 in objectsToIgnore)
        {
           
            Debug.Log(obj1.name);
            Collider col1 = obj1.GetComponent<Collider>();
            Physics.IgnoreCollision(camerab, col1.GetComponent<BoxCollider>(), true);
           
            }


    }
    }