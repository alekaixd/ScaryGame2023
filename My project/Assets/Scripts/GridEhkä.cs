using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridEhkä : MonoBehaviour
{


    public GameObject gridSquarePrefab; // Tämä on GameObject-prefab, jota käytetään ruudukon luomiseen

    public int gridWidth = 10; // Tämä on ruudukon leveys
    public int gridHeight = 10; // Tämä on ruudukon korkeus

    // Tämä funktio luo ruudukon peliruudulle
    void CreateGrid()
    {
        // Käy läpi jokainen rivi
        for (int y = 0; y < gridHeight; y++)
        {
            // Käy läpi jokainen sarake
            for (int x = 0; x < gridWidth; x++)
            {
                // Luo uusi GameObject
                GameObject newSquare = Instantiate(gridSquarePrefab, new Vector3(x, y, 0), Quaternion.identity);
                // Aseta GameObjectin nimi
                newSquare.name = "Grid Square (" + x + ", " + y + ")";
            }
        }
    }

    // Kutsu CreateGrid-funktiota pelin alussa
    void Start()
    {
        CreateGrid();
    }

}