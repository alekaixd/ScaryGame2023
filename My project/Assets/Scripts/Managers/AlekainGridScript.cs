using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class AlekainGridScript : MonoBehaviour
{
    public static AlekainGridScript Instance;

    [SerializeField] private int _width, _height;

    [SerializeField] private AlekainTileScript _GrassTile, _MountainTile;

    [SerializeField] private Transform _cam;

    private Dictionary<Vector2, AlekainTileScript> _tiles;

    void Start()
    {
        GenerateGrid();
    }

    public void GenerateGrid() //K‰ytt‰‰ kahta for looppia luodakseen gridin (kaksi koska x ja y)
    {
        _tiles = new Dictionary<Vector2, AlekainTileScript>();
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var randomTile = Random.Range(0, 6) == 3 ? _MountainTile : _GrassTile;

                var spawnedTile = Instantiate(randomTile, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";



                spawnedTile.Init(x, y);


                _tiles[new Vector2(x, y)] = spawnedTile;
            }
        }

        _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10); 

        GameManager.Instance.ChangeState(GameState.SpawnHeroes); 


    }

    public AlekainTileScript GetHeroSpawnTile () //Pelaajan spawni
    {
        return _tiles.Where(t => t.Key.x < _width / 2 && t.Value.Walkable).OrderBy(t => Random.value).First().Value; 

    }

    public AlekainTileScript GetEnemySpawnTile() //Vihollisen spawni
    {
        return _tiles.Where(t => t.Key.x > _width / 2 && t.Value.Walkable).OrderBy(t => Random.value).First().Value;
    }

    public AlekainTileScript GetTileAtPosition(Vector2 pos)
    {
        if (_tiles.TryGetValue(pos, out var tile)) return tile; // xd
        return null;
    }
}