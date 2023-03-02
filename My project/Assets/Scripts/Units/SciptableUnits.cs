using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Scriptable Unit")] //nyt pystyy luomaan uuden assetin, joka kulkee nimell‰ scriptable unit. Helpottaa Unitmanagerin kanssa. Helpottaa uniitista tiedon ker‰‰mist‰ ja s‰ilytt‰mist‰
public class ScriptableUnits : ScriptableObject
{
    public Faction Faction; //factionit (pelaaja ja viholliset)
    public BaseUnit UnitPrefab; //Uniittien prefabit
}

public enum Faction //faktioneiden enum arvot
{
    Hero = 0,
    Enemy = 1
}