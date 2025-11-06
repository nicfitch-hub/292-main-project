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
        
            if (collision.gameObject.tag == ("Explosion"))
            {
                Debug.Log("Ex Hit");
                Destroy(gameObject);

            }

        
    }


}
