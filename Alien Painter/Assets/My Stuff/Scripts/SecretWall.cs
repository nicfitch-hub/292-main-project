using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretWall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Secret Script Working");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ping");
       if (collision.gameObject.tag == ("pShot"))
       {
            Debug.Log("pHit");
            Destroy(gameObject);
       }

        
    }


}
