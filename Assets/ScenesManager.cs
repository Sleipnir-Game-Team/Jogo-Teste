using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesManager : MonoBehaviour
{
    private static ScenesManager instance;
    [SerializeField] private GameObject playerPrefab;

    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    void OnLoad(){
        GameObject player = Instantiate(playerPrefab);
    }

    public static ScenesManager GetInstance(){
        return instance;
    }
}
