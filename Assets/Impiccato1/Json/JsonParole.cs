using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class WordsContainer
{
    public List<WordAndHint> words;
}

public class JsonParole : MonoBehaviour
{
    public TextAsset fileJson;
    private WordsContainer container=new WordsContainer();

    public WordsContainer GetListaParole(){
        return container;
    }

    void Start()
    {
        string jsonString = fileJson.text;
        Debug.Log(jsonString.Length);
        container = JsonUtility.FromJson<WordsContainer>(jsonString);
    }

    void Update()
    {

    }
}
