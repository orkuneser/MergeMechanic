using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnController : Singleton<ItemSpawnController>
{
    public List<GameObject> itemList;

    public void SpawnItem(int itemID)
    {
        if (TileController.Instance.isFully)
            return;

        Tile emptyTile = TileController.Instance.GetEmptyTile();

        if (emptyTile != null)
        {
            GameObject newItem = Instantiate(itemList[itemID], new Vector3(emptyTile.transform.position.x, -0.3f, emptyTile.transform.position.z), Quaternion.identity, transform);

            newItem.GetComponent<ItemPositionController>().oldTransform = emptyTile.transform;
            newItem.GetComponent<ItemPositionController>().currentTransform = emptyTile.transform;

            newItem.GetComponent<ItemScaleController>().ScaleTween(Vector3.zero, new Vector3(0.5f, 0.5f, 0.5f), 0.2f);

            emptyTile.tileItem = newItem.GetComponent<Item>();
            emptyTile.IsOccupied = true;
        }
        TileController.Instance.CheckFully();
    }

    public void MergeSpawner(GameObject item1, GameObject item2, Tile tile, int itemID)
    {
        item1.GetComponent<ItemPositionController>().currentTransform.GetComponent<Tile>().tileItem = null;
        item1.GetComponent<ItemPositionController>().currentTransform.GetComponent<Tile>().IsOccupied = false;

        item2.GetComponent<ItemPositionController>().currentTransform.GetComponent<Tile>().tileItem = null;
        item2.GetComponent<ItemPositionController>().currentTransform.GetComponent<Tile>().IsOccupied = false;


        GameObject newItem = Instantiate(itemList[itemID + 1], new Vector3(tile.transform.position.x, -0.3f, tile.transform.position.z), Quaternion.identity, transform);

        newItem.GetComponent<ItemPositionController>().oldTransform = tile.transform;
        newItem.GetComponent<ItemPositionController>().currentTransform = tile.transform;

        newItem.GetComponent<ItemScaleController>().ScaleTween(Vector3.zero, new Vector3(0.5f, 0.5f, 0.5f), 0.2f);

        tile.tileItem = newItem.GetComponent<Item>();
        tile.IsOccupied = true;

        Destroy(item1);
        Destroy(item2);
        TileController.Instance.CheckFully();
    }
}
