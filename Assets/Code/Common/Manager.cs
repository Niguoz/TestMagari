using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : Singleton<Manager>
{
    public void ChangeTile(GameObject tileToChange, GameObject newTile, float rotation)
    {
        GameObject go = Instantiate(newTile);
        go.transform.parent = tileToChange.transform.parent;
        go.transform.position = tileToChange.transform.position;
        go.transform.localRotation = Quaternion.Euler(0, rotation, 0);
        Destroy(tileToChange.gameObject);
    }
}
