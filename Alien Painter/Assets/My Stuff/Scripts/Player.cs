using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player : MonoBehaviour
{

    [SerializeField] float speed = 1f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float pinkUpForce = 10f;
    [SerializeField] float greenUpForce = 10f;

    private bool grounded = false;
    [SerializeField] float raylegnth;
    [SerializeField] float sideRaylegnth;
    [SerializeField] float gForce = 10f;

    [SerializeField] GameObject pPaint;
    [SerializeField] GameObject gPaint;

    [SerializeField] GameObject firePoint;
    [SerializeField] GameObject piviotPoint;

    private bool canFire = true;
    [SerializeField] float timeBetweenShots;
    [SerializeField] float gTimeBetweenShots;
    float timer = 0;
    float gTimer = 0;

    private bool pinkFire = true;

    private int yKeys = 0;
    private int pAmmo = 50;
    private int gAmmo = 4;

    private int health = 3;
    [SerializeField] float iFrames = 1.5f;
    private float damageTimer = 0;

    [SerializeField] TextMeshProUGUI pAmmoUI;
    [SerializeField] TextMeshProUGUI gAmmoUI;
    [SerializeField] TextMeshProUGUI healthUI;

    private bool rKey1 = false;
    private bool rKey2 = false;

    public UnityEvent lvl1Win;
    public UnityEvent lvl2Win;
    public UnityEvent lvl3Win;

    public UnityEvent rKey1Found;
    public UnityEvent rKey2Found;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Old gravity
       // if (!GetGrounded())
        //{
          //  Rigidbody2D body = GetComponent<Rigidbody2D>();
            //body.AddForce(new Vector3(0, -gForce, 0));
        //}
        //else
        //{
          //  Rigidbody2D body = GetComponent<Rigidbody2D>();
           // body.velocity = Vector3.zero;
        //}


        // Right and left movement

        if (Input.GetKey(KeyCode.RightArrow) && CanRight() || Input.GetKey(KeyCode.D) && CanRight())
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && CanLeft() || Input.GetKey(KeyCode.A) && CanLeft())
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }

        //Raycasting tests

        // transform.position
        // Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - .5f, transform.position.z), Vector2.down * raylegnth, UnityEngine.Color.blue);
        // Debug.DrawRay(new Vector3(transform.position.x + .5f, transform.position.y - .5f, transform.position.z), Vector2.down * raylegnth, UnityEngine.Color.blue);
        // Debug.DrawRay(new Vector3(transform.position.x - .5f, transform.position.y - .5f, transform.position.z), Vector2.down * raylegnth, UnityEngine.Color.blue);

        //Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - .3f, transform.position.z), Vector2.right * sideRaylegnth, UnityEngine.Color.red);
        //Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - .95f, transform.position.z), Vector2.right * sideRaylegnth, UnityEngine.Color.red);
        //Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z), Vector2.right * sideRaylegnth, UnityEngine.Color.red);

        //Debug.DrawRay(new Vector3(transform.position.x, transform.position.y -.3f, transform.position.z), Vector2.left * sideRaylegnth, UnityEngine.Color.green);
        //Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - .95f, transform.position.z), Vector2.left * sideRaylegnth, UnityEngine.Color.green);
        //Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z), Vector2.left * sideRaylegnth, UnityEngine.Color.green);

        // Jump

        if ((Input.GetKeyDown(KeyCode.UpArrow) && GetGrounded()) || (Input.GetKeyDown(KeyCode.W) && GetGrounded()))
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

        // Damage Invicibility Timer
        if (damageTimer > 0)
        {
            damageTimer -= Time.deltaTime;
        }

        // Shooting code
        if (pinkFire)
        {
            if (Input.GetButton("Fire1") && canFire && pAmmo > 0)
            {
                canFire = false;
                Instantiate(pPaint, firePoint.transform.position, Quaternion.identity);
                pAmmo -= 1;
                pAmmoUI.text = "x" + pAmmo.ToString();
                if (piviotPoint.transform.rotation.eulerAngles.z > 255 && piviotPoint.transform.rotation.eulerAngles.z < 285)
                {
                    //light impulse and unground
                    Rigidbody2D body = GetComponent<Rigidbody2D>();
                    body.AddForce(new Vector3(0, pinkUpForce, 0));
                    grounded = false;
                }
                else if (piviotPoint.transform.rotation.eulerAngles.z > 225 && piviotPoint.transform.rotation.eulerAngles.z < 315 && !GetGrounded())  
                {
                    //light impulse
                    Rigidbody2D body = GetComponent<Rigidbody2D>();
                    body.AddForce(new Vector3(0, pinkUpForce, 0));

                }
                else 
                {
                    Debug.Log(piviotPoint.transform.rotation.eulerAngles.z);
                } 
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1") && gAmmo > 0)  // code to maybe make it automatic, needs fixing:|| (canFire && Input.GetButton("Fire1"))// 
            {
                canFire = false;
                Instantiate(gPaint, firePoint.transform.position, Quaternion.identity);
                gAmmo -= 1;
                gAmmoUI.text = "x" +gAmmo.ToString();
                if (piviotPoint.transform.rotation.eulerAngles.z > 255 && piviotPoint.transform.rotation.eulerAngles.z < 285)
                {
                    //big impulse and unground
                    Rigidbody2D body = GetComponent<Rigidbody2D>();
                    body.AddForce(new Vector3(0, greenUpForce, 0));
                    grounded = false;
                }
                else if (piviotPoint.transform.rotation.eulerAngles.z > 225 && piviotPoint.transform.rotation.eulerAngles.z < 315 && !GetGrounded())
                {
                    //big impulse
                    Rigidbody2D body = GetComponent<Rigidbody2D>();
                    body.AddForce(new Vector3(0, greenUpForce, 0));

                }

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

    private bool GetGrounded()
    {
        if (Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - .5f, transform.position.z), Vector2.down, raylegnth, LayerMask.GetMask("Ground")))
        {
            return true;
        }
        else if (Physics2D.Raycast(new Vector3(transform.position.x + .5f, transform.position.y - .5f, transform.position.z), Vector2.down, raylegnth, LayerMask.GetMask("Ground")))
        {
            return true;
        }
        else if (Physics2D.Raycast(new Vector3(transform.position.x - .5f, transform.position.y - .5f, transform.position.z), Vector2.down, raylegnth, LayerMask.GetMask("Ground")))
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    private bool CanRight()
    {
        if (Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - .3f, transform.position.z), Vector2.right, sideRaylegnth, LayerMask.GetMask("Ground")))
        {

            return false;
        }
        else if (Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y -.95f, transform.position.z), Vector2.right, sideRaylegnth, LayerMask.GetMask("Ground")))
        {
            return false;
        }
        else if (Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z), Vector2.right, sideRaylegnth, LayerMask.GetMask("Ground")))
        {
            return false;
        }
        else
        {
            return true;
        }
    }


    private bool CanLeft()
    {
        if (Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - .3f, transform.position.z), Vector2.left, sideRaylegnth, LayerMask.GetMask("Ground")))
        {
            
            return false;
        }
        else if (Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - .95f, transform.position.z), Vector2.left, sideRaylegnth, LayerMask.GetMask("Ground")))
        {
            return false;
        }
        else if (Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z), Vector2.left, sideRaylegnth, LayerMask.GetMask("Ground")))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void TakeDamage()
    {
        health -= 1;
        healthUI.text = "Health: " + health.ToString();
        // temp gameover code
        Debug.Log(health);
        if (health == 0)
        {
            Destroy(gameObject);
            //StartCoroutine(WaitAndPerformAction());
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    // Waiting code from google (not working rn)
    IEnumerator WaitAndPerformAction()
    {
        Debug.Log("Starting to wait...");
        yield return new WaitForSeconds(2f); // Wait for 2 seconds
        Debug.Log("2 seconds have passed! Performing action now.");
        // Place the code you want to execute after the delay here
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("yKey"))
        {
            Destroy(collision.gameObject);
            yKeys += 1;
            Debug.Log(yKeys);
        }
        if (collision.gameObject.tag == ("redKey1"))
        {
            rKey1Found.Invoke();
        }
        if (collision.gameObject.tag == ("redKey2"))
        {
            rKey2Found.Invoke();
        }



    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("pPool"))
        {
            pAmmo = 50;
            pAmmoUI.text = "x" + pAmmo.ToString();
        }
        else if (collision.gameObject.tag == ("gPool"))
        {
            if (gAmmo < 4)
            {
                gAmmo = 4;
                gAmmoUI.text = "x" + gAmmo.ToString();
            }
            Debug.Log(gAmmo);
        }
        if (collision.gameObject.tag == ("Door"))
        {
            if (Input.GetKey(KeyCode.E) && yKeys == 3) 
            {
                Scene currentScene = SceneManager.GetActiveScene();
                string thisLvl = currentScene.name;
                if (thisLvl == "Lvl1")
                {
                    lvl1Win.Invoke();
                    Debug.Log("Lvl1Sent");
                }
                else if (thisLvl == "Lvl2")
                {
                    lvl2Win.Invoke();
                }
                else if (thisLvl == "Lvl3")
                {
                    lvl3Win.Invoke();
                }

                if (thisLvl == "Lvl3")
                {
                    SceneManager.LoadScene("GameEnd");
                }
                else
                {
                    SceneManager.LoadScene("Menu");
                }
                    
            }
        }
        if (collision.gameObject.tag == ("Evil") && damageTimer <= 0)
        {
            TakeDamage();
            damageTimer = iFrames;
        }
    }






}
