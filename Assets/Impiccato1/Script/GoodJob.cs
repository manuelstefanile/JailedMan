using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GoodJob : MonoBehaviour
{
   private Transform telecamera;
    public float delay = 0.5f; // Aggiungi una variabile per il ritardo

    private Vector3 targetPosition; // Memorizza la posizione desiderata

    void Start()
    {
        // Ottenere il riferimento alla telecamera principale
        telecamera = Camera.main.transform;

        // Ruota l'oggetto di -180 gradi sull'asse Y solo al primo avvio
        transform.Rotate(0, -180, 0);
    }

    void Update()
    {
        // Assicurati che la telecamera sia stata assegnata correttamente
        if (telecamera != null)
        {
            // Imposta la posizione desiderata
            Vector3 desiredPosition = telecamera.position + telecamera.forward * 6;

            // Aggiungi un offset di 2 unità a sinistra rispetto alla direzione della fotocamera
            desiredPosition -= telecamera.right * 2;

            // Gradualmente sposta l'oggetto verso la posizione desiderata con un ritardo
            targetPosition = Vector3.Lerp(targetPosition, desiredPosition, Time.deltaTime / delay);
            transform.position = targetPosition;

            // Ruota l'oggetto rispetto alla rotazione della fotocamera
            Quaternion ro = telecamera.rotation;
            ro.eulerAngles = ro.eulerAngles - new Vector3(0, 180, 0);
            transform.rotation = ro;
            Vector3 currentRotation = transform.rotation.eulerAngles;
            currentRotation.z *= -1;
            transform.rotation = Quaternion.Euler(currentRotation);
            
        }
    }
}