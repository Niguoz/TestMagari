using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridManager : Singleton<GridManager>
{
    [SerializeField]
    private Vector2 _size;

    [SerializeField]
    private GameObject _emptyTile;

    [SerializeField]
    private GameObject _startTile;

    [SerializeField]
    private GameObject _endTile;

    [SerializeField]
    private Material _baseMaterial;

    private List<GameObject> _tiles = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(CreateGrid());
    }

    private IEnumerator CreateGrid()
    {
        int halfX = (int)(_size.x / 2);
        int halfY = (int)(_size.y / 2);

        for (int i = 0; i < _size.x; i++)
        {
            for (int j = 0; j < _size.y; j++)
            {
                if (i == (halfX) && j == halfY)
                {
                    GameObject go = Instantiate(_startTile);
                    go.transform.SetParent(transform);
                    go.transform.position = new Vector3(i, 0, j);
                    go.transform.rotation = Quaternion.identity;
                }
                else
                {
                    GameObject go = Instantiate(_emptyTile);
                    go.transform.SetParent(transform);
                    go.transform.position = new Vector3(i, 0, j);
                    go.name = _emptyTile.name;
                    _tiles.Add(go);
                    go.transform.localRotation = Quaternion.Euler(0, 180, 0); 
                }
            }
        }

        int exitX = (int)Random.Range(0, _size.x);
        int exitY = (int)Random.Range(0, _size.x);

        if (exitX == halfX && exitY == halfY)
        {
            exitX = (int)Random.Range(0, _size.x);
            exitY = (int)Random.Range(0, _size.x);
        }

        GameObject exit = Instantiate(_endTile);
        exit.transform.SetParent(transform);
        exit.transform.position = new Vector3(exitX, 0, exitY);
        Check();

        yield return new WaitForSeconds(0.00001f);
    }

    public void Check()
    {
        foreach (GameObject tile in _tiles)
        {
            tile.GetComponent<SimpleCube>().Check();
        }
    }
}