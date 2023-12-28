using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{

    void OnTriggerStay2D()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            print(StoryManager.GetInstance().RunKnot("NPC").Item1);
        }
    }


}
