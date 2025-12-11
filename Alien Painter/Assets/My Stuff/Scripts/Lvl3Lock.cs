using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Lvl3Lock : MonoBehaviour
{
    private Button myButton;


    public UnityEvent lvl3Check;

    private bool makeInteractable;
    void Awake()
    {
        myButton = GetComponent<Button>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(myButton.interactable);
        //Debug.Log("CheckRequestSent");
        lvl3Check.Invoke();
        if (makeInteractable)
        {
            Unlock3();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Unlock3()
    {
        myButton = GetComponent<Button>();
        myButton.interactable = true;
        makeInteractable = true;
        Debug.Log("unlocked");
        Debug.Log(myButton.interactable);

    }
}
