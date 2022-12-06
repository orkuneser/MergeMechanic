using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileColorController : MonoBehaviour
{
    private Renderer _renderer;
    private Renderer Renderer => _renderer == null ? _renderer = GetComponent<Renderer>() : _renderer;

    public List<Color> tileColors;
    public void ChangeTileColor(int colorIndex)
    {
        Renderer.material.color = tileColors[colorIndex];
    }
}
