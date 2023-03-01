using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassTile : AlekainTileScript
{

    [SerializeField] private Color _baseColor, _offsetColor; 

    public override void Init(int x, int y)  //jokatoinen ruoho tile on v‰h‰n eriv‰rinen (se n‰ytt‰‰ paremmalta)
    {
        var isOffset = (x + y) % 2 == 1;
        _renderer.color = isOffset ? _offsetColor : _baseColor;
    }
}
