using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    private static StoryManager instance;

    [SerializeField] private TextAsset inkAsset;

    private Story inkStory;

    private string actualKnot = "";
    
    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
            inkStory = new Story(inkAsset.text);
        } else {
            Destroy(gameObject);
        }
    }

    public (string, bool) RunKnot(string name){
        if(actualKnot != name || !inkStory.canContinue)
            inkStory.ChoosePathString(name);
            actualKnot = name;
        return (inkStory.Continue(), inkStory.canContinue);
    }
    
    public static StoryManager GetInstance(){
        return instance;
    }
}
