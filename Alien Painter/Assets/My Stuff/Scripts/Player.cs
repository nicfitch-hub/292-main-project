using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float speed = 1f;
    [SerializeField] float jumpForce = 10f;

    private bool grounded;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Right and left movement

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }

        // Jump

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            Rigidbody2D body = GetComponent<Rigidbody2D>();
            body.AddForce(new Vector3(0, jumpForce, 0));
            grounded = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            grounded = true;
        }


    }

}
