using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class EvilSaw : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f; 
    [SerializeField] Transform playerTransform;
    [SerializeField] float raylegnth;
    private bool isAwake = false;

    [SerializeField] float health;
    [SerializeField] GameObject explosion;

    [SerializeField] float dashSpeed;
    private Vector3 randomDirection;
    [SerializeField] float dashingTime;
    private float dashing;

    private float damageTimer = .25f;
    // Start is called before the first frame update
    void Start()
    {
        // More google AI. 
        // Generate a random angle in degrees (0 to 360)
        float randomAngle = Random.Range(0f, 360f);
        // Convert the angle to a direction vector
        randomDirection = new Vector3(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad)).normalized;

        // Normalize the direction to ensure consistent speed regardless of distance
        randomDirection.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 origin = transform.position;
        Vector2 direction = transform.right;

        // Perform the CircleCast
        RaycastHit2D hit = Physics2D.CircleCast(origin, raylegnth, direction, 1, LayerMask.GetMask("Player"));

        // Draw the ray for debugging
        Debug.DrawRay(origin, direction * Vector2.down, Color.blue);

        // If something was hit, you can draw a line to the hit point
        if (hit.collider != null)
        {
            Debug.DrawLine(origin, hit.point, Color.red);
        }

   
        if (!isAwake && hit)
        {
                WakeUp();
        }

        // Code from google AI
        
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("PlayerMain"); // Player Tag
        if (playerGameObject != null)
        {
            Vector3 playerCurrentPosition = playerGameObject.transform.position;
            playerTransform = playerGameObject.transform;
            Debug.Log("Player Position by Tag: " + playerCurrentPosition);
        }


        if (playerTransform != null && dashing >= 0)
        {
            transform.position += randomDirection * dashSpeed * Time.deltaTime;

            dashing -= Time.deltaTime;
        }
        else if (playerTransform != null && isAwake)
        {

            // Calculate the direction to the player
            Vector3 directionToPlayer = playerTransform.position - transform.position;

            // Normalize the direction to ensure consistent speed regardless of distance
            directionToPlayer.Normalize();

            // Move the enemy towards the player
            transform.position += directionToPlayer * moveSpeed * Time.deltaTime;


        }

        // Damage Invicibility Timer
        if (damageTimer > 0)
        {
            damageTimer -= Time.deltaTime;
        }

    }

    void WakeUp()
    {
        //Debug.Log("WAKEUP");
        isAwake = true;
    }

    private void TakeDamage()
    { 
        if (damageTimer <= 0)
        {
            health -= 1;
            //Debug.Log(health);
            if (health == 0)
            {
                Destroy(gameObject);
            }
            dashing = dashingTime;
            WakeUp();
            damageTimer = .25f;
        }
    }

    private void Take3Damage()
    {
        if (damageTimer <= 0)
        {
            health = 0;
            //Debug.Log(health);
            if (health == 0)
            {
                Destroy(gameObject);
            }
            dashing = dashingTime;
            WakeUp();
            damageTimer = .25f;
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
            Take3Damage();
        }
        if (collision.gameObject.tag == ("Explosion"))
        {
            Take3Damage();
        }
    }


}
