using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int tileID;
    public int itemID = -1;
    public Item tileItem;
    public bool IsOccupied;

    private void Start()
    {
        TileController.Instance.tileList.Add(this);
    }


    // Call Scene Loaded
    private void LoadItem()
    {
        if (itemID > -1)
            Debug.Log("LOAD ITEM");
    }
}
