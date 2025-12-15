using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LvlBonusLock : MonoBehaviour
{
    private Button myButton;


    public UnityEvent lvlBonusCheck;

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
        lvlBonusCheck.Invoke();
        if (makeInteractable)
        {
            UnlockBonus();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UnlockBonus()
    {
        myButton = GetComponent<Button>();
        myButton.interactable = true;
        makeInteractable = true;
        Debug.Log("unlocked");
        Debug.Log(myButton.interactable);

    }
}
