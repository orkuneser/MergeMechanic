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
    public bool isFully;

    private int tileFullyCount = 0;

    public Tile GetEmptyTile()
    {
        Tile emptyTile = null;

        foreach (var tile in tileList)
        {
            if (!tile.IsOccupied)
            {
                emptyTile = tile;
                break;
            }
        }
        CheckFully();
        return emptyTile;
    }

    public void CheckFully()
    {
        tileFullyCount = 0;

        for (int i = 0; i < tileList.Count; i++)
        {
            if (tileList[i].tileItem != null)
            {
                tileFullyCount++;
            }
            else
            {
                tileFullyCount--;
            }

            if (tileFullyCount >= tileList.Count)
            {
                isFully = true;
            }
            else
            {
                isFully = false;
            }
        }
    }
}
