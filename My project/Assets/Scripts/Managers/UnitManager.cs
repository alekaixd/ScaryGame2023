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

    public void SpawnHeroes() //Kun gamemanagerissa tulee vastaan spawnheroes niin t‰m‰ kutsutaan
    {
        var heroCount = 1; //Jos pelattavia hahmoja tarvitaan lis‰‰ on t‰t‰ numeroa nostettava
        Debug.Log("Unitmanager alku");

        for (int i = 0; i < heroCount; i++)
        {
            Debug.Log("For looppu alkaa");
            var randomPrefab = GetRandomUnit<baseHero>(Faction.Hero); //hakee pelaajan prefabin
            Debug.Log("Ensimm‰inen rivi");
            var spawnedHero = Instantiate(randomPrefab); //palauttaa prefabin
            Debug.Log("Ollaan rivill' 35");
            var randomSpawnTile = AlekainGridScript.Instance.GetHeroSpawnTile(); //Hakee tilen mihin spawnata

            randomSpawnTile.SetUnit(spawnedHero); //pelaajan spawnaus
        }
        Debug.Log("Unitmanager loppu");
        GameManager.Instance.ChangeState(GameState.SpawnEnemies); //siirtyy seuraavaan gamestateen (jota ei viel‰ ole koodattu loppuun)
    }

     private T GetRandomUnit<T>(Faction faction) where T : BaseUnit //valitsee random prefabin
     {
        Debug.Log("T toimii");
        //1
        Debug.Log(_units);
        Debug.Log("(:");
        return (T)_units.Where(u => u.Faction == faction).OrderBy(o => Random.value).First().UnitPrefab;

        

     }
}