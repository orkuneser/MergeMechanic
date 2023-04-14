using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRayController : MonoBehaviour
{
    private Tile _tile;
    private Tile Tile => _tile == null ? _tile = GetComponent<Tile>() : _tile;

    private TileColorController _tileColorContoller;
    private TileColorController TileColorController => _tileColorContoller == null ? _tileColorContoller = GetComponent<TileColorController>() : _tileColorContoller;

    private void FixedUpdate()
    {
        float maxDistance = 10f;
        RaycastHit hit;

        bool isHit = Physics.SphereCast(transform.position, transform.lossyScale.x / 3, Vector3.up, out hit, maxDistance);

        if (isHit)
        {
            if (Tile.IsOccupied)
            {
                if (hit.collider.gameObject != Tile.tileItem)
                {
                    TileColorController.ChangeTileColor(1);
                }
            }
            else
            {
                TileColorController.ChangeTileColor(2);
            }
        }
        else
        {
            TileColorController.ChangeTileColor(0);
        }
    }

    #region RAY DRAW GIZMOS
    private void OnDrawGizmos()
    {
        float maxDistance = 10f;
        RaycastHit hit;

        bool isHit = Physics.SphereCast(transform.position, transform.lossyScale.x / 3, Vector3.up, out hit, maxDistance);

        if (isHit)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, Vector3.up * hit.distance);
            Gizmos.DrawWireSphere(transform.position + Vector3.up * hit.distance, transform.lossyScale.x / 3);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, Vector3.up * maxDistance);
        }
    }
    #endregion
}
