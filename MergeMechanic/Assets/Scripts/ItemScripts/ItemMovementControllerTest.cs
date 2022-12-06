using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
public class ItemMovementControllerTest : LeanDragTranslateAlong
{
    private ItemPositionController _itemPositionController;
    private ItemPositionController ItemPositionController => _itemPositionController == null ? _itemPositionController = GetComponent<ItemPositionController>() : _itemPositionController;

    private LeanSelectable _leanSelectable;
    private LeanSelectable LeanSelectable => _leanSelectable == null ? _leanSelectable = GetComponent<LeanSelectable>() : _leanSelectable;

    private void OnMouseUp()
    {
        LeanSelectable.Deselect();
        ItemPositionController.SetPosition();
    }
}
