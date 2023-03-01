using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AlekainTileScript : MonoBehaviour
{

    [SerializeField] protected SpriteRenderer _renderer; //aika selke‰
    [SerializeField] private GameObject _highlight; //higlihgtaa tilen
    [SerializeField] private bool _isWalkable; //Onko tile k‰velt‰v‰ (grasstile on k‰velt‰v‰)

    public BaseUnit OccupiedUnit; 
    public bool Walkable => _isWalkable && OccupiedUnit == null;  //Metodi joka katsoo onko onko tile tyhj‰ ja onko se k‰velt‰viss‰ oleva tile (ei sein‰ tai jne)


    public virtual void Init(int x, int y)
    {

    }

    void OnMouseEnter() //jos hiiri on tilen p‰‰ll‰ niin tile on highlightattu ja on v‰h‰n vaaleampi
    {
        _highlight.SetActive(true);
    }

    void OnMouseExit() //highlight tila poistuu kun hiiri poistuu tilen p‰‰lt‰
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
