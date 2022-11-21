using MagariProject.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagariProject.Game
{
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

        private Vector3 _startPlayerOnePosition;
        private Vector3 _startPlayerTwoPosition;

        private void Start()
        {
            StartCoroutine(CreateGrid());
        }

        /// <summary>
        /// Create the dungeon grid
        /// </summary>
        /// <returns></returns>
        private IEnumerator CreateGrid()
        {
            int halfX = (int)(_size.x / 2);
            int halfY = (int)(_size.y / 2);

            int exitX = (int)Random.Range(0, _size.x);
            int exitY = (int)Random.Range(0, _size.x);

            if ((exitX == halfX && exitY == halfY) || (exitX == halfX - 1 && exitY == halfY - 1))
            {
                exitX = (int)Random.Range(0, _size.x);
                exitY = (int)Random.Range(0, _size.x);
            }

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
                        _startPlayerOnePosition = go.transform.position;
                    }
                    else if (i == (halfX - 1) && j == halfY - 1)
                    {
                        GameObject go = Instantiate(_startTile);
                        go.transform.SetParent(transform);
                        go.transform.position = new Vector3(i, 0, j);
                        go.transform.rotation = Quaternion.identity;
                        _startPlayerTwoPosition = go.transform.position;
                    }
                    else if (i == exitX && j == exitY)
                    {
                        GameObject exit = Instantiate(_endTile);
                        exit.transform.SetParent(transform);
                        exit.transform.position = new Vector3(exitX, 0, exitY);
                        if(exitY == _size.y)
                        {
                            exit.transform.localRotation = Quaternion.Euler(0, 180, 0);
                        }
                        if(exitX == 0)
                        {
                            exit.transform.localRotation = Quaternion.Euler(0, -90, 0);
                        }
                        else if (exitX == _size.x) 
                        {
                            exit.transform.localRotation = Quaternion.Euler(0, 90, 0);
                        }
                        
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

            Manager.Instance.SpawnPlayerOne(_startPlayerOnePosition);
            Manager.Instance.SpawnPlayerTwo(_startPlayerTwoPosition);

            yield return new WaitForSeconds(0.00001f);
        }

        /// <summary>
        /// Removes an element from the tiles list
        /// </summary>
        /// <param name="go"></param>
        public void RemoveFromList(GameObject go)
        {
            _tiles.Remove(go);
        }
    }
}