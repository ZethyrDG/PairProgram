using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageGame : MonoBehaviour
{
    public delegate void Change();
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.activeSceneChanged += ChangedActiveScene;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ChangedActiveScene(Scene current, Scene next)
    {
        string currentName = current.name;

        if (currentName == null)
        {
            // Scene1 has been removed
            currentName = "Replaced";
        }

    }
    void OnEnable()
    {
        var AllGameObjects = GameObject.FindGameObjectsWithTag("Player");
        int count = 1;
        foreach(var thing in AllGameObjects){
            thing.transform.position = GameObject.Find($"SpawnPos{count}").transform.position;
            count++;
        }
        var CoinObject = GameObject.Find("Coin");
        CoinObject.transform.position = GameObject.Find("CoinLocation").transform.position;
    }

    void OnDisable()
    {
        
    }
}
