using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Collider grabbedObjectCollider;
    public Collider cameraCollider;
    public Collider pareteCollider;
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(grabbedObjectCollider, cameraCollider, true);
         GameObject[] gallaObjects = GameObject.FindGameObjectsWithTag("PallaBowling");

        // Ignora la collisione con la camera per ciascun oggetto trovato
        foreach (GameObject gallaObject in gallaObjects)
        {
            Collider grabbedObjectCollider = gallaObject.GetComponent<Collider>();
            
            if (grabbedObjectCollider != null && cameraCollider != null)
            {
                Physics.IgnoreCollision(grabbedObjectCollider, pareteCollider, true);
            }
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
