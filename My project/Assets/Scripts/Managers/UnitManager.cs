using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;


public class UnitManager : MonoBehaviour
{

    public static UnitManager Instance;

    private List<ScriptableUnits> _units;
    public baseHero SelectedHero;

    void Awake()
    {
        Instance = this;

        _units = Resources.LoadAll<ScriptableUnits>("Units").ToList();  //listaa kaikki "unitit" :D

    }

    public void SpawnHeroes() //Kun gamemanagerissa tulee vastaan spawnheroes niin tämä kutsutaan
    {
        var heroCount = 1;

        for (int i = 0; i < heroCount; i++)
        {
            var randomPrefab = GetRandomUnit<baseHero>(Faction.Hero); //hakee pelaajan prefabin
            var spawnedHero = Instantiate(randomPrefab); //palauttaa prefabin
            var randomSpawnTile = AlekainGridScript.Instance.GetHeroSpawnTile(); //Hakee tilen mihin spawnata

            randomSpawnTile.SetUnit(spawnedHero); //pelaajan spawnaus
        }

        GameManager.Instance.ChangeState(GameState.SpawnEnemies); //siirtyy seuraavaan gamestateen (jota ei vielä ole koodattu loppuun)
    }

     private T GetRandomUnit<T>(Faction faction) where T : BaseUnit 
     {
         return (T)_units.Where(u => u.Faction == faction).OrderBy(o => Random.value).First().UnitPrefab;
     }
}