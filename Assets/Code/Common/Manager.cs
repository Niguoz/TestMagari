using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : Singleton<Manager>
{
    [SerializeField]
    private GameObject _playerOne;
    [SerializeField]
    private GameObject _playerTwo;

    public void ChangeTile(GameObject tileToChange, GameObject newTile, float rotation)
    {
        GameObject go = Instantiate(newTile);
        go.transform.parent = tileToChange.transform.parent;
        go.transform.position = tileToChange.transform.position;
        go.transform.localRotation = Quaternion.Euler(0, rotation, 0);
        go.GetComponent<SimpleCube>().ChangeBool();
        go.GetComponent<SimpleCube>().Start();
        GridManager.Instance.Check();
        GridManager.Instance.RemoveFromList(tileToChange);
        Destroy(tileToChange.gameObject);
    }

    public void SpawnPlayerOne(Vector3 position)
    {
        GameObject playerOne = Instantiate(_playerOne);
        playerOne.transform.position = new Vector3(position.x, position.y + 1, position.z);    
    }
}
