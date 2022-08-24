using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoSingleton<GridManager>
{
    [SerializeField] private int _width, _height;

    [SerializeField] private TileScript _tilePrefab;

    private TileScript[,] _tileScripts;

    private void Start() => GenerateGrid();

    private void GenerateGrid()
    {
        _tileScripts = new TileScript[_width, _height];

        float x = _width * .5f; 
        float y = _height * .5f; 

        for(int i = 0; i < _width; i++)
            for(int j = 0; j < _height; j++)
            {
                var tile = Instantiate(_tilePrefab, new Vector3(i - x + .5f, j - y + .5f), Quaternion.identity, transform);

                tile.name = $"Tile {i} {j}";

                tile.x = i;
                tile.y = j;

                var isOffset = (i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0);

                tile.Init(isOffset);

                _tileScripts[i, j] = tile;
            }
    }

    public Transform CalculateDistance(IInformation builder)
    {
        float dist = 1f;

        Transform trs = null;

        for(int i = 0; i < _width; i++)
        {
            for(int j = 0; j < _height; j++)
            {
                float nowDist = (((Vector2)builder.transform.position) - _tileScripts[i, j].GetPos).magnitude;

                if (nowDist <= dist)
                {
                    if (builder.GetType == MenuItemScript.Type.Barrack)
                    {
                        if (i < 2)
                            i = 2;
                        if (j < 2)
                            j = 2;
                        if (i > _width - 3)
                            i = _width - 3;
                        if (j > _height - 3)
                            j = _height - 3;
                    }
                    else if (builder.GetType == MenuItemScript.Type.PowerPlate)
                    {
                        if (i < 1)
                            i = 1;
                        if (j < 1)
                            j = 1;
                        if (i > _width - 1)
                            i = _width - 1;
                        if (j > _height - 1)
                            j = _height - 1;
                    }

                    trs = _tileScripts[i, j].GetTransform;

                    return trs;
                }
            }
        }

        return trs;
    }
}
