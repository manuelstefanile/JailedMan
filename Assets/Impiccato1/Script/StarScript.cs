using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{  
       private float shrinkDuration = 2.0f; // Durata del ridimensionamento in secondi
    private float currentTime = 0.0f;
    private Vector3 initialScale;

    void Start()
    {
        initialScale = transform.localScale;
    }

    void Update()
    {
        if (currentTime < shrinkDuration)
        {
            currentTime += Time.deltaTime;

            // Calcola il valore di t basato sul tempo trascorso rispetto alla durata totale
            float t = currentTime / shrinkDuration;

            // Utilizza Lerp per modificare gradualmente le dimensioni
            transform.localScale = Vector3.Lerp(initialScale, Vector3.zero, t);

            if (t >= 1.0f)
            {
                Destroy(gameObject);
            }
        }
    }
}