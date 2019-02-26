using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    public GameObject dotPrefab;
    public Tilemap GroundTileMap;
    public Grid Grid;

    void Start()
    {
        createDotsForMap();  
    }

    void createDotsForMap()
    {

        BoundsInt bounds = GroundTileMap.cellBounds;
        TileBase[] allTiles = GroundTileMap.GetTilesBlock(bounds);

        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile != null)
                {
                    if (tile != null)
                    {
                        GameObject dot = Instantiate(dotPrefab);
                        dot.transform.parent = Grid.transform;
                        dot.transform.position = GroundTileMap.WorldToCell(new Vector3Int(x-11, y-15, 0));
                    }
                }
              
            }
        }

    }
}

   

  

