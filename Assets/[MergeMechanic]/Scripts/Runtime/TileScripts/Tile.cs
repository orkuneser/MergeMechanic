using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Item tileItem;
    public bool IsOccupied;

    private void Start()
    {
        TileController.Instance.tileList.Add(this);
    }
}
