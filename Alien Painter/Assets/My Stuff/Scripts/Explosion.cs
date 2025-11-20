using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Explosion : MonoBehaviour
{

    [SerializeField] float eTime;
    [SerializeField] float scaleFactor;
    [SerializeField] GameObject SecretWalls;
    
    Tilemap tilemap;
    [SerializeField] TileBase tile;

    // Start is called before the first frame update
    void Start()
    {

        // Top 10 worst coding experiance BUT IT WORKS BABY LETS GOOOOOOO

        GameObject grid = GameObject.FindGameObjectWithTag("Grid");

        Vector3 p0 = transform.position;
        Vector3 p1 = new Vector3 (transform.position.x + 1f, transform.position.y, transform.position.z);
        Vector3 p2 = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
        Vector3 p3 = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        Vector3 p4 = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);

        Vector3 p5 = new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z);
        Vector3 p6 = new Vector3(transform.position.x - 2f, transform.position.y, transform.position.z);
        Vector3 p7 = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        Vector3 p8 = new Vector3(transform.position.x, transform.position.y - 2f, transform.position.z);

        Vector3 p9 = new Vector3(transform.position.x + 1.9f, transform.position.y + .1f, transform.position.z);
        Vector3 p10 = new Vector3(transform.position.x + 1.9f, transform.position.y - .1f, transform.position.z);
        Vector3 p11 = new Vector3(transform.position.x - 1.9f, transform.position.y + .1f, transform.position.z);
        Vector3 p12 = new Vector3(transform.position.x - 1.9f, transform.position.y - .1f, transform.position.z);
        Vector3 p13 = new Vector3(transform.position.x + .1f, transform.position.y + 1.9f, transform.position.z);
        Vector3 p14 = new Vector3(transform.position.x - .1f, transform.position.y + 1.9f, transform.position.z);
        Vector3 p15 = new Vector3(transform.position.x + .1f, transform.position.y - 1.9f, transform.position.z);
        Vector3 p16 = new Vector3(transform.position.x - .1f, transform.position.y - 1.9f, transform.position.z);

        Vector3 p17 = new Vector3(transform.position.x + 1f, transform.position.y + 1f, transform.position.z);
        Vector3 p18 = new Vector3(transform.position.x - 1f, transform.position.y - 1f, transform.position.z);
        Vector3 p19 = new Vector3(transform.position.x + 1f, transform.position.y - 1f, transform.position.z);
        Vector3 p20 = new Vector3(transform.position.x - 1f, transform.position.y + 1f, transform.position.z);

        Vector3 p21 = new Vector3(transform.position.x + 1.25f, transform.position.y + 1.25f, transform.position.z);
        Vector3 p22 = new Vector3(transform.position.x - 1.25f, transform.position.y - 1.25f, transform.position.z);
        Vector3 p23 = new Vector3(transform.position.x + 1.25f, transform.position.y - 1.25f, transform.position.z);
        Vector3 p24 = new Vector3(transform.position.x - 1.25f, transform.position.y + 1.25f, transform.position.z);

        GridLayout gridLayout = grid.GetComponent<GridLayout>();

        Vector3Int g0 = gridLayout.WorldToCell(p0);
        TileKiller(g0);
        Vector3Int g1 = gridLayout.WorldToCell(p1);
        TileKiller(g1);
        Vector3Int g2 = gridLayout.WorldToCell(p2);
        TileKiller(g2);
        Vector3Int g3 = gridLayout.WorldToCell(p3);
        TileKiller(g3);
        Vector3Int g4 = gridLayout.WorldToCell(p4);
        TileKiller(g4);
        Vector3Int g5 = gridLayout.WorldToCell(p5);
        TileKiller(g5);
        Vector3Int g6 = gridLayout.WorldToCell(p6);
        TileKiller(g6);
        Vector3Int g7 = gridLayout.WorldToCell(p7);
        TileKiller(g7);
        Vector3Int g8 = gridLayout.WorldToCell(p8);
        TileKiller(g8);
        Vector3Int g9 = gridLayout.WorldToCell(p9);
        TileKiller(g9);
        Vector3Int g10 = gridLayout.WorldToCell(p10);
        TileKiller(g10);
        Vector3Int g11 = gridLayout.WorldToCell(p11);
        TileKiller(g11);
        Vector3Int g12 = gridLayout.WorldToCell(p12);
        TileKiller(g12);
        Vector3Int g13 = gridLayout.WorldToCell(p13);
        TileKiller(g13);
        Vector3Int g14 = gridLayout.WorldToCell(p14);
        TileKiller(g14);
        Vector3Int g15 = gridLayout.WorldToCell(p15);
        TileKiller(g15);
        Vector3Int g16 = gridLayout.WorldToCell(p16);
        TileKiller(g16);
        Vector3Int g17 = gridLayout.WorldToCell(p17);
        TileKiller(g17);
        Vector3Int g18 = gridLayout.WorldToCell(p18);
        TileKiller(g18);
        Vector3Int g19 = gridLayout.WorldToCell(p19);
        TileKiller(g19);
        Vector3Int g20 = gridLayout.WorldToCell(p20);
        TileKiller(g20);
        Vector3Int g21= gridLayout.WorldToCell(p21);
        TileKiller(g21);
        Vector3Int g22 = gridLayout.WorldToCell(p22);
        TileKiller(g22);
        Vector3Int g23 = gridLayout.WorldToCell(p23);
        TileKiller(g23);
        Vector3Int g24 = gridLayout.WorldToCell(p24);
        TileKiller(g24);

        Debug.Log(p9);
        //Debug.Log(p15);
        //Debug.Log(p24);
        Debug.Log(g9);
        //Debug.Log(g15);
        //Debug.Log(g24);
        //Debug.Log(p0);
        //Debug.Log(g0);
        //Debug.Log("TileSetHasCastAll");

    }

    // Update is called once per frame
    void Update()
    {
        if (eTime > 0)
        {
            eTime -= Time.deltaTime;
            
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    public void TileKiller(Vector3Int pos)
    {
        Debug.Log("call");
        GameObject SecWalls = GameObject.FindGameObjectWithTag("SecretGround");
        tilemap = SecWalls.GetComponent<Tilemap>();
        tilemap.SetTile(pos, null);
        Debug.Log(pos);
    }


}
