using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float speed = 1f;
    [SerializeField] float jumpForce = 10f;

    private bool grounded;

    [SerializeField] GameObject pPaint;
    [SerializeField] GameObject gPaint;

    [SerializeField] GameObject firePoint;

    private bool canFire = true;
    [SerializeField] float timeBetweenShots;
    [SerializeField] float gTimeBetweenShots;
    float timer = 0;
    float gTimer = 0;

    private bool pinkFire = true;


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

        // Shoot Timer 
        if (!canFire)
        {
            timer += Time.deltaTime;
            gTimer += Time.deltaTime;
            if (pinkFire)
            {
                if (timer > timeBetweenShots)
                {
                    canFire = true;
                    timer = 0;
                }
            }
            else
            {
                if (gTimer > gTimeBetweenShots)
                {
                    canFire = true;
                    gTimer = 0;
                }
            }
            
        }

        // Shooting code
        if (pinkFire)
        {
            if (Input.GetButton("Fire1") && canFire)
            {
                canFire = false;
                Instantiate(pPaint, firePoint.transform.position, Quaternion.identity);

            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1") || (canFire && Input.GetButton("Fire1")) )
            {
                canFire = false;
                Instantiate(gPaint, firePoint.transform.position, Quaternion.identity);

            }
        }
     

        // Switch Weapons 

        if (Input.GetButtonDown("Jump"))
        {
            if (pinkFire)
            {
                pinkFire = false;
                gTimer = 10;
            }
            else
            {
                pinkFire = true;
                timer = 10;
            }
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
