using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEditor.PlayerSettings;

public class DestrutableTiles : MonoBehaviour
{
    Tilemap tilemap;
    [SerializeField] TileBase tile;
    
    // Start is called before the first frame update
    void Start()
    {
        //tilemap = GetComponent<Tilemap>();
        //tilepos = Grid.LocalToCell();
        //Debug.Log("CodeStart");
        //tilemap.SetTile(new Vector3Int(6,7,0), null);
        //TileKiller(new Vector3Int(6, 6, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TileKiller(Vector3Int pos)
    {
        Debug.Log("call");
        GameObject SecWalls = GameObject.FindGameObjectWithTag("SecretGround");
        tilemap = SecWalls.GetComponent<Tilemap>();
        tilemap.SetTile(pos, null);
        Debug.Log(pos);
    }

    public void TileDetector(Vector3Int pos)
    {
        GameObject SecWalls = GameObject.FindGameObjectWithTag("SecretGround");
        tilemap = SecWalls.GetComponent<Tilemap>();
        tilemap.SetTile(pos, tile);
        Debug.Log(pos);
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {


       Debug.Log("COlin Hit");
       // if (collision.gameObject.tag == ("Explosion"))
       // {
       //     Debug.Log("Ex Hit");
       //     Vector3 hitPos = Vector3.zero;
       //     foreach (ContactPoint2D hit in collision.contacts)
       //     {
       //        hitPos.x = hit.point.x + hit.normal.x;
       //        hitPos.y = hit.point.y + hit.normal.y;
       //       tilemap.SetTile(tilemap.WorldToCell(hitPos), null);
       //     }

            //tilemap.SetTile(transform.position, null);

            //}

    }





}
