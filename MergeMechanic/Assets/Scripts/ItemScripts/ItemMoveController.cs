using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
public class ItemMoveController : MonoBehaviour
{
    public float horizontalClamp;
    public float verticalClamp;

    private Vector3 _mousePosition;
    public bool isControllable = true;

    //private void Update()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        _mousePosition = GetMousePosition();
    //        transform.position = new Vector3(_mousePosition.x, transform.position.y, _mousePosition.z);
    //    }
    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        //isControllable = false;
    //    }
    //}

    private void OnMouseDrag()
    {
        _mousePosition = GetMousePosition();
        transform.position = new Vector3(_mousePosition.x, transform.position.y, _mousePosition.z);
    }

    private Vector3 GetMousePosition()
    {
        float distance_to_screen = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 movePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));

        //movePosition.x = Mathf.Clamp(movePosition.x, -horizontalClamp, horizontalClamp);
        //movePosition.z = Mathf.Clamp(movePosition.z, -verticalClamp, verticalClamp);

        return movePosition;
    }
}
