using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Lvl2Lock : MonoBehaviour
{
    private Button myButton;


    public UnityEvent lvl2Check;

    private bool makeInteractable;
    void Awake()
    { 
        myButton = GetComponent<Button>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(myButton.interactable);
        Debug.Log("CheckRequestSent");
        lvl2Check.Invoke();
        if (makeInteractable)
        {
            Unlock();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Unlock()
    {
        myButton = GetComponent<Button>();
        myButton.interactable = true;
        makeInteractable = true;
        Debug.Log("unlocked");
        Debug.Log(myButton.interactable);

    }

}
