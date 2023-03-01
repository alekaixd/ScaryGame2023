using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    public string UnitName; //aika selkeä
    public AlekainTileScript OccupiedTile; //onko tile jo käytössä
    public Faction Faction; //faktioni
}
