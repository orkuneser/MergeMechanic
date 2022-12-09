using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
public class Item : MonoBehaviour
{
    public ItemSO itemData;
    public bool isAvailable => GetComponent<LeanSelectable>().IsSelected;
}
