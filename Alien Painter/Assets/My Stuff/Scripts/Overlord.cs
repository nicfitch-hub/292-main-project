using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Overlord : MonoBehaviour
{

    public static Overlord Instance { get; private set; } // Singleton thingy 

    private bool lvl1 = false;
    private bool lvl2 = false;
    private bool lvl3 = false;
    public UnityEvent lvl2Unlock;
    public UnityEvent lvl3Unlock;
    public UnityEvent lvl4Unlock;

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
        
        // not setting as false for some reason so trying it twice here
        lvl1 = false;
        lvl2 = false;
        lvl3 = false;
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
        SceneManager.LoadScene("Lvl1");
    }
    public void LoadLvl2()
    {
        SceneManager.LoadScene("Lvl2");
    }
    public void LoadLvl3()
    {
        SceneManager.LoadScene("Lvl3");
    }


    public void Lvl1Won()
    {
        lvl2Unlock.Invoke();
    }
    public void Lvl2Won()
    {
        lvl3Unlock.Invoke();
    }
    public void Lvl3Won()
    {
        lvl4Unlock.Invoke();
    }

    public void CheckLvl1()
    {
        Debug.Log("CheckRequestRecived");
        Debug.Log(lvl1);
        //Debug.Log(lvl2);
        if (lvl1 == true)
        {
            lvl2Unlock.Invoke();
        }
    }
    public void CheckLvl2()
    {

        if (lvl2 == true)
        {
            lvl3Unlock.Invoke();
        }
    }
    public void CheckLvl3()
    {

        if (lvl3 == true)
        {
            lvl4Unlock.Invoke();
        }
    }

}
