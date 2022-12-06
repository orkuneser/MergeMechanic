using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnButton : MonoBehaviour
{
   public void SpawnItem()
    {
        ItemSpawnController.Instance.SpawnItem(0);
    }
}
