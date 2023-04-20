using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollider : MonoBehaviour
{
    private Item _item;
    private Item Item => _item == null ? _item = GetComponent<Item>() : _item;

    private ItemPositionController _itemPositionController;
    private ItemPositionController ItemPositionController => _itemPositionController == null ? _itemPositionController = GetComponent<ItemPositionController>() : _itemPositionController;

    private ItemMergeController _itemMergeController;
    private ItemMergeController ItemMergeController => _itemMergeController == null ? _itemMergeController = GetComponent<ItemMergeController>() : _itemMergeController;

    private Item _otherItem;

    private bool _isMergeAvailable;

    private void OnMouseUp()
    {
        if (!_isMergeAvailable)
            return;

        if (_otherItem.itemData.itemID != Item.itemData.itemID)
        {
            ItemPositionController otherItemPositionCont = _otherItem.GetComponent<ItemPositionController>();

            Transform currentTransform = ItemPositionController.currentTransform;
            Transform currentNavigateTransform = ItemPositionController.navigateTransform;
            Transform otherTransform = otherItemPositionCont.currentTransform;
            Transform otherNavigateTransform = otherItemPositionCont.navigateTransform;

            // Change Transform
            ItemPositionController.ChangeAllTransforms(otherTransform, otherNavigateTransform);
            otherItemPositionCont.ChangeAllTransforms(currentTransform, currentNavigateTransform);

            // Change Item
            ItemPositionController.currentTransform.GetComponent<Tile>().tileItem = Item;
            otherItemPositionCont.currentTransform.GetComponent<Tile>().tileItem = _otherItem;

            ItemPositionController.oldTransform = ItemPositionController.currentTransform;
            otherItemPositionCont.oldTransform = otherItemPositionCont.currentTransform;

            // Set Position
            ItemPositionController.SetPosition();
            otherItemPositionCont.SetPosition();
        }
        else
        {
            ItemMergeController.MergeControl(_otherItem);
        }

        TileController.Instance.CheckFully();
    }

    private void OnTriggerEnter(Collider other)
    {
        Item otherItem = other.GetComponent<Item>();
        if (otherItem != null)
        {
            _isMergeAvailable = true;
            _otherItem = otherItem;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Item otherItem = other.GetComponent<Item>();
        if (otherItem != null)
        {
            _isMergeAvailable = true;
            _otherItem = otherItem;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Item otherItem = other.GetComponent<Item>();
        if (otherItem != null)
        {
            _isMergeAvailable = false;
            _otherItem = null;
        }
    }
}
