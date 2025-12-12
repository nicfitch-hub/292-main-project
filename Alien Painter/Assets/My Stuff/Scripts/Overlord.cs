using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
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


    private bool key1 = false;
    private bool key2 = false;
    private bool key3 = false;
    private bool key4 = false;
    private bool key5 = false;
    private bool key6 = false;
    private bool key7 = false;
    private bool key8 = false;
    private bool key9 = false;
    private bool key10 = false;
    private bool key11 = false;
    private bool key12 = false;
    
    private int totalKeys = 0;
    [SerializeField] TextMeshProUGUI keyCount;

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

    public void RedKey1()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string thisLvl = currentScene.name;
        if (thisLvl == "Lvl1")
        {
            key1 = true;
        }
        else if (thisLvl == "Lvl2")
        {
            key3 = true;
        }
        else if (thisLvl == "Lvl3")
        {
            key5 = true;
        }
        else if (thisLvl == "Lvl4")
        {
            key7 = true;
        }
        else if (thisLvl == "Lvl5")
        {
            key9 = true;
        }
        else if (thisLvl == "Lvl6")
        {
            key11 = true;
        }
    }

    public void RedKey2()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string thisLvl = currentScene.name;
        if (thisLvl == "Lvl1")
        {
            key2 = true;
        }
        else if (thisLvl == "Lvl2")
        {
            key4 = true;
        }
        else if (thisLvl == "Lvl3")
        {
            key6 = true;
        }
        else if (thisLvl == "Lvl4")
        {
            key8 = true;
        }
        else if (thisLvl == "Lvl5")
        {
            key10 = true;
        }
        else if (thisLvl == "Lvl6")
        {
            key12 = true;
        }
    }

    // I know for a fact I could do a recursion thing here if I put the keys in a list
    // but I don't have the time right now to remeber how lists work
    public void KeyUpdate()
    {
        totalKeys = 0;
        if (key1) {totalKeys++;}
        if (key2) { totalKeys++; }
        if (key3) { totalKeys++; }
        if (key4) { totalKeys++; }
        if (key5) { totalKeys++; }
        if (key6) { totalKeys++; }
        if (key7) { totalKeys++; }
        if (key8) { totalKeys++; }
        if (key9) { totalKeys++; }
        if (key10) { totalKeys++; }
        if (key11) { totalKeys++; }
        if (key12) { totalKeys++; }
        keyCount.text = totalKeys.ToString() + "/12";
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
