using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPaint : MonoBehaviour
{
    [SerializeField] float paintSpeed = 1.0f;
    GameObject crosshair;
    private Rigidbody2D rbody;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();


        crosshair = GameObject.FindGameObjectsWithTag("Crosshair")[0];

        // Going to do bullet spread later, its not MVP
        //double randxOffset = UnityEngine.Random.Range(100, -100) / 1000;
        //double randyOffset = UnityEngine.Random.Range(100, -100) / 1000;

        Vector2 direction = ((crosshair.transform.position) - transform.position).normalized;

      

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle + 90);
        rbody.velocity = new Vector2(direction.x, direction.y).normalized * paintSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }

    }
}
