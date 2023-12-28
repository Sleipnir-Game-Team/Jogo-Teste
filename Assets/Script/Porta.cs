using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Porta : MonoBehaviour
{
    [SerializeField] string cena;
    [SerializeField] private Vector3 spawnPoint;
    void OnTriggerEnter2D(Collider2D collider){
        GameManager.GetInstance().LoadScene(spawnPoint, cena);
        
        (string, bool) KnotResponse = StoryManager.GetInstance().RunKnot("Porta");
        while(KnotResponse.Item2 == true){
            print(KnotResponse.Item1);
            KnotResponse = StoryManager.GetInstance().RunKnot("Porta");
        }
        print(KnotResponse.Item1);
    }

}
