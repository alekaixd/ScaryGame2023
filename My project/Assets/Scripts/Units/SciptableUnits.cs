using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Scriptable Unit")] //nyt pystyy luomaan uuden assetin, joka kulkee nimellä scriptable unit. Helpottaa Unitmanagerin kanssa
public class ScriptableUnits : ScriptableObject
{
    public Faction Faction; //factionit (pelaaja ja viholliset)
    public BaseUnit UnitPrefab; //aika selkeä
}

public enum Faction //faktioneiden enum arvot
{
    Hero = 0,
    Enemy = 1
}