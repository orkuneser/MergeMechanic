using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRayController : MonoBehaviour
{
    private Tile _tile;
    private Tile Tile => _tile == null ? _tile = GetComponent<Tile>() : _tile;

    private TileColorController _tileColorContoller;
    private TileColorController TileColorController => _tileColorContoller == null ? _tileColorContoller = GetComponent<TileColorController>() : _tileColorContoller;

    private float _maxDistance = 10f;

    private void FixedUpdate()
    {
        RaycastHit hit;

        bool isHit = Physics.SphereCast(transform.position, transform.lossyScale.x / 4, Vector3.up, out hit, _maxDistance);
        if (isHit)
        {
            if (!Tile.IsOccupied)
            {
                TileColorController.ChangeTileColor(1);
            }
            else
            {
                TileColorController.ChangeTileColor(0);
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
        RaycastHit hit;

        bool isHit = Physics.SphereCast(transform.position, transform.lossyScale.x / 4, Vector3.up, out hit, _maxDistance);
        if (isHit)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, Vector3.up * hit.distance);
            Gizmos.DrawWireSphere(transform.position + Vector3.up * hit.distance, transform.lossyScale.x / 4);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, Vector3.up * _maxDistance);
        }
    }
    #endregion
}
