using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilBee : MonoBehaviour
{
    [SerializeField] float beeSpeed = 1.0f;
    private Rigidbody2D rbody;
    Vector2 direction;

    [SerializeField] float raylegnth;
    [SerializeField] float sideRaylegnth;
    [SerializeField] float timer;
    float flipTimer;

    [SerializeField] float health;

    [SerializeField] GameObject explosion;


    bool isLeft;
    // Start is called before the first frame update
    void Start()
    {
        float flipTimer = timer;
        rbody = GetComponent<Rigidbody2D>();


        int coinflip = UnityEngine.Random.Range(0, 2);
        if (coinflip == 0)
        {
            GoLeft();
        }
        else
        {
            GoRight();
        }



    }

    // Update is called once per frame
    void Update()
    {
        //Ray cast tests. Check if hitting wall or edge
        //Debug.DrawRay(new Vector3(transform.position.x + .6f, transform.position.y - .5f, transform.position.z), Vector2.down * raylegnth, UnityEngine.Color.blue);
        //Debug.DrawRay(new Vector3(transform.position.x - .6f, transform.position.y - .5f, transform.position.z), Vector2.down * raylegnth, UnityEngine.Color.blue);



        //Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - .3f, transform.position.z), Vector2.right * sideRaylegnth, UnityEngine.Color.red);
        //Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - .6f, transform.position.z), Vector2.right * sideRaylegnth, UnityEngine.Color.red);
        //Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + .6f, transform.position.z), Vector2.right * sideRaylegnth, UnityEngine.Color.red);


        //Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - .3f, transform.position.z), Vector2.left * sideRaylegnth, UnityEngine.Color.green);
        //Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - .6f, transform.position.z), Vector2.left * sideRaylegnth, UnityEngine.Color.green);
        //Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + .6f, transform.position.z), Vector2.left * sideRaylegnth, UnityEngine.Color.green);


        if (flipTimer <= 0 && Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - .3f, transform.position.z), Vector2.right, raylegnth, LayerMask.GetMask("Ground")))
        {
            Flip();
        }
        if (flipTimer <= 0 && Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - .6f, transform.position.z), Vector2.right, raylegnth, LayerMask.GetMask("Ground")))
        {
            Flip();
        }
        if (flipTimer <= 0 && Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y + .6f, transform.position.z), Vector2.right, raylegnth, LayerMask.GetMask("Ground")))
        {
            Flip();
        }


        if (flipTimer <= 0 && Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - .3f, transform.position.z), Vector2.left, raylegnth, LayerMask.GetMask("Ground")))
        {
            Flip();
        }
        if (flipTimer <= 0 && Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - .6f, transform.position.z), Vector2.left, raylegnth, LayerMask.GetMask("Ground")))
        {
            Flip();
        }
        if (flipTimer <= 0 && Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y + .6f, transform.position.z), Vector2.left, raylegnth, LayerMask.GetMask("Ground")))
        {
            Flip();
        }

        if (flipTimer > 0)
        {
            flipTimer -= Time.deltaTime;
        }

    }

    private void GoLeft()
    {
        direction = Vector2.left;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rbody.velocity = new Vector2(direction.x, direction.y).normalized * beeSpeed;
        isLeft = true;
    }

    private void GoRight()
    {
        direction = Vector2.right;
        transform.rotation = Quaternion.Euler(0, 180, 0);
        rbody.velocity = new Vector2(direction.x, direction.y).normalized * beeSpeed;
        isLeft = false;
    }

    private void Flip()
    {
        if (!isLeft)
        {
            GoLeft();
        }
        else
        {
            GoRight();
        }
        flipTimer = timer;
    }
    private void TakeDamage()
    {
        health -= 1;
        Debug.Log(health);
        if (health == 0)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Hit!");
        if (collision.gameObject.tag == ("pShot"))
        {
            Destroy(collision.gameObject);
            TakeDamage();
        }
        if (collision.gameObject.tag == ("gShot"))
        {
            Destroy(collision.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            TakeDamage();
            TakeDamage();
            TakeDamage();
        }
        if (collision.gameObject.tag == ("Explosion"))
        {
            TakeDamage();
            TakeDamage();
            TakeDamage();
        }
    }
}
