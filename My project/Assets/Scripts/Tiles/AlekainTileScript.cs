using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AlekainTileScript : MonoBehaviour
{

    [SerializeField] protected SpriteRenderer _renderer; 
    [SerializeField] private GameObject _highlight;
    [SerializeField] private bool _isWalkable;

    public BaseUnit OccupiedUnit; 
    public bool Walkable => _isWalkable && OccupiedUnit == null;  //Metodi joka katsoo onko onko tile tyhjä ja onko se käveltävissä oleva tile (ei seinä tai jne)


    public virtual void Init(int x, int y)
    {

    }

    void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }

    public void SetUnit(BaseUnit unit) //Laittaa pelaajan oikealle paikalle
    {
        if (unit.OccupiedTile != null) unit.OccupiedTile.OccupiedUnit = null;
        unit.transform.position = transform.position; 
        OccupiedUnit = unit;
        unit.OccupiedTile = this;
    }
}
