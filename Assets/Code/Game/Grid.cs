using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField]
    private Vector2 _size;

    [SerializeField]
    private GameObject _emptyTile;

    [SerializeField]
    private GameObject _startTile;

    [SerializeField]
    private GameObject _endTile;

    private List<GameObject> _tiles = new();

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
            for(int j = 0; j < _size.y; j++)
            {
                if (i == (halfX) && j == halfY)
                {
                    GameObject go = Instantiate(_startTile);
                    _tiles.Add(go);
                    go.transform.SetParent(transform);
                    go.transform.position = new Vector3(i, j, 0);
                }
                else
                {
                    GameObject go = Instantiate(_emptyTile);
                    _tiles.Add(go);
                    go.transform.SetParent(transform);
                    go.transform.position = new Vector3(i, j, 0);
                }
            }
        }

        int exitX = (int)Random.Range(0, _size.x);
        int exitY = (int)Random.Range(0, _size.x);

        if( exitX == halfX && exitY == halfY)
        {
            exitX = (int)Random.Range(0, _size.x);
            exitY = (int)Random.Range(0, _size.x);
        }

        GameObject exit = Instantiate(_endTile);
        _tiles.Add(exit);
        exit.transform.SetParent(transform);
        exit.transform.position = new Vector3(exitX, exitY, 0);

        yield return new WaitForSeconds(0.00001f);
    }



}
