using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PinkPaint : MonoBehaviour
{

    [SerializeField] float paintSpeed = 1.0f;
    GameObject crosshair;
    private Rigidbody2D rbody;

    [SerializeField] GameObject SecretWalls;
    [SerializeField] GameObject Grid;
    [SerializeField] float raylegnth;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();

        
        crosshair = GameObject.FindGameObjectsWithTag("Crosshair")[0];

        // Going to do bullet spread later, its not MVP
        //double randxOffset = UnityEngine.Random.Range(100, -100) / 1000;
        //double randyOffset = UnityEngine.Random.Range(100, -100) / 1000;

        Vector2 direction = ((crosshair.transform.position ) - transform.position).normalized;

        

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

        // Detect Secret Walls Code (Work In progress)


    //    if (collision.gameObject.tag == ("SecretGround"))
    //    {
    //        GridLayout gridLayout = Grid.GetComponent<GridLayout>();
    //
    //       Ray ray = (Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - .5f, transform.position.z), Vector2.down, raylegnth, LayerMask.GetMask("Ground"));
    //        RaycastHit hit;

        //    Debug.Log("CollisionHitSecret");

        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        Debug.Log("RayHit");
        //        if (hit.transform.tag == "SecretGround")
        //        {
        //            Vector3 p0 = hit.transform.position;
        //            Vector3Int g0 = gridLayout.WorldToCell(p0);
        //            SecretWalls.GetComponent<DestrutableTiles>().TileDetector(g0);
        //            Debug.Log("TileHit");

        //        }
        //    }

        //}
        if (collision.gameObject.layer == 6)
        {
            Destroy(gameObject);
        }
     
     }

}




