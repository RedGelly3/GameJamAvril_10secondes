using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps; 

public class ManageTiles : MonoBehaviour
{
    [SerializeField] private Tilemap tiles;

    [SerializeField] private List<TileData> tilesData; 

    private Dictionary<TileBase, TileData> tilesDicData;

    private void Awake()
    {
        tilesDicData = new Dictionary<TileBase, TileData>();

        foreach(var td in tilesData){
            foreach (var t in td.tiles){

                tilesDicData.Add(t, td);
            }
        }
    }
}
