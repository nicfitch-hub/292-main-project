using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Lvl6Lock : MonoBehaviour
{
    private Button myButton;


    public UnityEvent lvl6Check;

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
        lvl6Check.Invoke();
        if (makeInteractable)
        {
            Unlock6();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Unlock6()
    {
        myButton = GetComponent<Button>();
        myButton.interactable = true;
        makeInteractable = true;
        Debug.Log("unlocked");
        Debug.Log(myButton.interactable);

    }
}
