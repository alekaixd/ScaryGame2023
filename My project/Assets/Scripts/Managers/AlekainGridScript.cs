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

    [SerializeField] private int _width, _height; //Kuvasuhde

    [SerializeField] private AlekainTileScript _GrassTile, _MountainTile; //Kaksi eri tile tyyppi‰. Nimet v‰h‰n harhaanjohtavia sein‰ ja lattia tile voisi ehk‰ olla parempi, mut en jaksa l‰htee muuttaa

    [SerializeField] private Transform _cam; //kameran paikka

    private Dictionary<Vector2, AlekainTileScript> _tiles;

    void Start()
    {
        GenerateGrid(); //aika selke‰
    }

    public void GenerateGrid() //K‰yGenerateGridt‰‰ kahta for looppia luodakseen gridin (kaksi koska x ja y)
    {
        Debug.Log("Generate Grid alkaa");
        _tiles = new Dictionary<Vector2, AlekainTileScript>();
        for (int x = 0; x < _width; x++) //Pituus yleisesti 16
        {
            for (int y = 0; y < _height; y++)  //leveys yleisesti 9
            {
                var randomTile = Random.Range(0, 6) == 3 ? _MountainTile : _GrassTile; //Arpoo mitk‰ tilet ovat seini‰ ja mitk‰ lattiaa

                var spawnedTile = Instantiate(randomTile, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";



                spawnedTile.Init(x, y);


                _tiles[new Vector2(x, y)] = spawnedTile;
            }
        }
        Debug.Log("Grid generoinnin j‰lkeen");

        _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10); //Kameran positio
        Debug.Log("Kamera toimii");

        GameManager.Instance.ChangeState(GameState.SpawnHeroes); //gamesteitti muuttuu seuraavaan

        Debug.Log("Grid generoinnin j‰lkee part 2");
    }

    public AlekainTileScript GetHeroSpawnTile () //Pelaajan spawni, k‰yt‰nnˆss‰ idea on se ett‰ vihollinen ja pelaaja spawnaavat random paikkoihin eripuolilla kentt‰‰
    {
        Debug.Log("Trying to get spawnpoint for the hero");
        return _tiles.Where(t => t.Key.x < _width / 2 && t.Value.Walkable).OrderBy(t => Random.value).First().Value; 

    }

    public AlekainTileScript GetEnemySpawnTile() //Vihollisen spawni (vihollista ei t‰ll‰ hetkell‰ viel‰ ole, joten t‰st‰ ei tarvitse v‰litt‰‰
    {
        return _tiles.Where(t => t.Key.x > _width / 2 && t.Value.Walkable).OrderBy(t => Random.value).First().Value;
    }

    /*public AlekainTileScript GetTileAtPosition(Vector2 pos)
    {
        if (_tiles.TryGetValue(pos, out var tile)) return tile; // xd
        return null;
    }*/
}