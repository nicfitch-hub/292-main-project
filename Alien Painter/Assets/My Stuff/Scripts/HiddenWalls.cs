using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenWalls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collide");
        if (collision.gameObject.tag == ("Player") || collision.gameObject.tag == ("PlayerMain"))
        {
            Debug.Log("Dying");
            Destroy(gameObject);
           
        }

    }
}
