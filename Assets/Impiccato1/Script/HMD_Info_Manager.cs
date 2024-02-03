using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;



public class HMD_Info_Manager : MonoBehaviour
{ 
    public InputActionProperty triggerAction;
    public InputActionProperty gripAction;
/*
void Update()
    {
        float triggerValue= triggerAction.action.ReadValue<float>();
        float gripValue= gripAction.action.ReadValue<float>();
        Debug.Log("trigger " + triggerValue);
        Debug.Log("grip " + gripValue);
        
    }*/
}