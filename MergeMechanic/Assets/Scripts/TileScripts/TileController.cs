using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    #region SINGLETON
    public static TileController Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public List<Tile> tileList;
    public int tileCount = 0;
    public bool isFully;
    public Tile GetEmptyTile()
    {
        Tile emptyTile = null;

        foreach (var tile in tileList)
        {
            if (!tile.IsOccupied)
            {
                emptyTile = tile;
                tileCount++;
                break;
            }
        }
        CheckFully();
        return emptyTile;
    }

    private void CheckFully()
    {
        if (tileCount >= tileList.Count)
        {
            isFully = true;
        }
    }
}
