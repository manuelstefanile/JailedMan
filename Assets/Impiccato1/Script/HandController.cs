using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandController : MonoBehaviour
{
    public InputActionProperty triggerAction;
    public InputActionProperty gripAction;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float triggerValue= triggerAction.action.ReadValue<float>();
        float gripValue= gripAction.action.ReadValue<float>();
        anim.SetFloat("Trigger",triggerValue);
        anim.SetFloat("Grip",gripValue);
    }
}
