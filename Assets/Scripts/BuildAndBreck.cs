using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildAndBreck : MonoBehaviour
{
    [SerializeField] TileBase tileBase;
    [SerializeField] Tilemap tileMap;



    // Update is called once per frame
    private void Update()
    {
        Vector3 world = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKey(KeyCode.Mouse1))
        {
            
            tileMap.SetTile(tileMap.WorldToCell(world), null);
        }
        if (Input.GetKey(KeyCode.Mouse0) && tileMap.GetTile(tileMap.WorldToCell(world)) == null)
        {
            
            tileMap.SetTile(tileMap.WorldToCell(world), tileBase);
        }


    }
}
