using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMenu : MonoBehaviour
{
    // Start is called before the first frame update
  public void exitApplicazione(){
    Debug.Log("exit");
    Application.Quit();
  }
}
