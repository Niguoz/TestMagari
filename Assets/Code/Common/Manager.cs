using MagariProject.Character;
using MagariProject.Game;
using UnityEngine;

namespace MagariProject.Common
{
    public class Manager : Singleton<Manager>
    {
        [SerializeField]
        private GameObject _playerOne;
        [SerializeField]
        private GameObject _playerTwo;

        private PlayerController _playerOneController;
        private PlayerController _playerTwoController;


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
            _playerOneController = playerOne.GetComponent<PlayerController>();
            if (_playerOneController == null)
            {
                _playerOneController = playerOne.AddComponent<PlayerController>();
            }

            _playerOneController.enabled = false;
        }

        public void SpawnPlayerTwo(Vector3 position)
        {
            GameObject playerTwo = Instantiate(_playerTwo);
            playerTwo.transform.position = new Vector3(position.x, position.y + 1, position.z);
            _playerTwoController = playerTwo.GetComponent<PlayerController>();
            if (_playerTwoController == null)
            {
                _playerTwoController = playerTwo.AddComponent<PlayerController>();
            }

            _playerTwoController.enabled = false;
        }

    }
}