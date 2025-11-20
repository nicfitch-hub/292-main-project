using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Overlord : MonoBehaviour
{

    public static Overlord Instance { get; private set; } // Singleton thingy 


    // code from google \/
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    //


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    } 

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void LoadLvl1()
    {
        Debug.Log("Loadworked");
        SceneManager.LoadScene("Lvl1");
    }

}
