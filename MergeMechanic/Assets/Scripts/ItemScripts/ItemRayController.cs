using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRayController : MonoBehaviour
{
    private ItemPositionController _itemPositionController;
    private ItemPositionController ItemPositionController => _itemPositionController == null ? _itemPositionController = GetComponent<ItemPositionController>() : _itemPositionController;

    private void OnMouseDrag()
    {
        RayTileControl();
    }

    public void RayTileControl()
    {
        float maxDistance = 10f;
        RaycastHit hit;

        bool isHit = Physics.SphereCast(transform.position, transform.lossyScale.x / 2, Vector3.down, out hit, maxDistance);

        if (isHit)
        {
            Tile tile = hit.collider.GetComponent<Tile>();
            if (tile != null)
            {
                if (!tile.IsOccupied)
                {
                    ItemPositionController.currentTransform = hit.collider.transform;
                }
                else
                {
                    ItemPositionController.navigateTransform = hit.collider.transform;
                }
            }
        }
        else
        {
            ItemPositionController.navigateTransform = null;
        }
    }

    #region RAY DRAW GIZMOS
    private void OnDrawGizmos()
    {
        float maxDistance = 10f;
        RaycastHit hit;

        bool isHit = Physics.SphereCast(transform.position, transform.lossyScale.x / 2, Vector3.down, out hit, maxDistance);

        if (isHit)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, Vector3.down * hit.distance);
            Gizmos.DrawWireSphere(transform.position + Vector3.down * hit.distance, transform.lossyScale.x / 2);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, Vector3.down * maxDistance);
        }
    }
    #endregion
}
