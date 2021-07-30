using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.7.30
/// </summary>

public class GridManager : MonoBehaviour
{
    [SerializeField]
    private int _width, _height;

    [SerializeField]
    private Tile _tilePrefabe;

    [SerializeField]
    private Transform _cam;

    private Dictionary<Vector2, Tile> _tiles;

    private void Start()
    {
        GridGenerator();
    }

    void GridGenerator()
    {
        _tiles = new  Dictionary<Vector2,Tile>();
        for(int x = 0; x < _width; x++)
        {
            for(int y = 0; y < _height; y++)
            {
                var spawnedTile = Instantiate(_tilePrefabe, new Vector2(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                var isOffset = (x + y) % 2 == 1;  //also  x % 2 != y % 2  :: (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0)
                spawnedTile.Init(isOffset);

                //Dictionary
                _tiles[new Vector2(x, y)] = spawnedTile;
            }
        }

        _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);
    }

    //to get tile at current position
    public Tile GetTilesPositions(Vector2 pos)
    {
        if(_tiles.TryGetValue(pos,out var tile))
        {
            return tile;
        }
        return null;
    }
}
