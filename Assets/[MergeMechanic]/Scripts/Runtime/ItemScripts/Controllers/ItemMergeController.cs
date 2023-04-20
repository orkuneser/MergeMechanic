using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
public class ItemMergeController : MonoBehaviour
{
    private Item _item;
    private Item Item => _item == null ? _item = GetComponent<Item>() : _item;

    private ItemPositionController _itemPositionController;
    private ItemPositionController ItemPositionController => _itemPositionController == null ? _itemPositionController = GetComponent<ItemPositionController>() : _itemPositionController;

    public void MergeControl(Item otherItem)
    {
        if (otherItem.itemData.itemID == Item.itemData.itemID && !Item.itemData.lastItem)
        {
            if (otherItem.GetComponent<ItemPositionController>().currentTransform.GetComponent<Tile>() && otherItem.GetInstanceID() != Item.GetInstanceID())
            {
                ItemSpawnController.Instance.MergeSpawner(otherItem.gameObject, Item.gameObject, otherItem.GetComponent<ItemPositionController>().currentTransform.gameObject, Item.itemData.itemID);
            }
        }
    }
}
