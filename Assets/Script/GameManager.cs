using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Vector3 spawnPoint;
    private GameObject player;
    
    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnLoad;
        } else {
            Destroy(gameObject);
        }
    }

    public void LoadScene(Vector3 spawnPoint, string cena){
        this.spawnPoint = spawnPoint;
        SceneManager.LoadScene(cena);
    }
    
    void OnLoad(Scene scene, LoadSceneMode loadSceneMode){
        player = Instantiate(playerPrefab, spawnPoint, Quaternion.identity);
    }

    public static GameManager GetInstance(){
        return instance;
    }

    public GameObject GetPlayer(){
        return player;
    }
}
