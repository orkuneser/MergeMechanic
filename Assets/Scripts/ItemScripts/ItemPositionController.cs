using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ItemPositionController : MonoBehaviour
{
    public Transform oldTransform;
    public Transform currentTransform;

    public Transform navigateTransform;

    private Item _item;
    private Item Item => _item == null ? _item = GetComponent<Item>() : _item;
    public void SetPosition()
    {
        Vector3 movePosition = new Vector3(currentTransform.position.x, -0.3f, currentTransform.position.z);
        transform.DOMove(movePosition, 0.3f);

        oldTransform.GetComponent<Tile>().IsOccupied = false;
        oldTransform.GetComponent<Tile>().tileItem = null;

        currentTransform.GetComponent<Tile>().IsOccupied = true;
        currentTransform.GetComponent<Tile>().tileItem = GetComponent<Item>();

        oldTransform = currentTransform;
    }
}
