using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class ItemMovementController : LeanDragTranslateAlong
{
    private ItemPositionController _itemPositionController;
    private ItemPositionController ItemPositionController => _itemPositionController == null ? _itemPositionController = GetComponent<ItemPositionController>() : _itemPositionController;

    private void OnMouseUp()
    {
        ItemPositionController.SetPosition();
    }
}
