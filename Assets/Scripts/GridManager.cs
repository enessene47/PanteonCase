using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoSingleton<GridManager>
{
    [SerializeField] private int _width, _height;

    [SerializeField] private TileScript _tilePrefab;


    private void Start() => GenerateGrid();

    private void GenerateGrid()
    {
        float x = _width * .5f; 
        float y = _height * .5f; 

        for(int i = 0; i < _width; i++)
            for(int j = 0; j < _height; j++)
            {
                var tile = Instantiate(_tilePrefab, new Vector3(i - x, j - y), Quaternion.identity, transform);

                tile.name = $"Tile {i} {j}";

                var isOffset = (i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0);

                tile.Init(isOffset);
            }
    }
}
