using MagariProject.Character;
using MagariProject.Game;
using UnityEditor.Experimental.GraphView;
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
        private string _winnerName;

        public string WinnerName => _winnerName;

        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this);
        }

        /// <summary>
        /// Spawn the choose tile with the choose rotation at the choose place
        /// </summary>
        /// <param name="tileToChange"></param>
        /// <param name="newTile"></param>
        /// <param name="rotation"></param>
        public void ChangeTile(GameObject tileToChange, GameObject newTile, float rotation)
        {
            GameObject go = Instantiate(newTile);
            go.transform.parent = tileToChange.transform.parent;
            go.transform.position = tileToChange.transform.position;
            go.transform.localRotation = Quaternion.Euler(0, rotation, 0);
            go.GetComponent<SimpleCube>().ChangeBool();
            GridManager.Instance.RemoveFromList(tileToChange);
            Destroy(tileToChange.gameObject);
        }

        /// <summary>
        /// Spawn player One at his start position
        /// </summary>
        /// <param name="position"></param>
        public void SpawnPlayerOne(Vector3 position)
        {
            GameObject playerOne = Instantiate(_playerOne);
            playerOne.name = _playerOne.name;
            playerOne.transform.position = new Vector3(position.x, position.y + 1, position.z);
            _playerOneController = playerOne.GetComponent<PlayerController>();
            if (_playerOneController == null)
            {
                _playerOneController = playerOne.AddComponent<PlayerController>();
            }

            _playerOneController.enabled = false;
        }

        /// <summary>
        /// Spawn player Two at his start position
        /// </summary>
        /// <param name="position"></param>
        public void SpawnPlayerTwo(Vector3 position)
        {
            GameObject playerTwo = Instantiate(_playerTwo);
            playerTwo.name = _playerTwo.name;
            playerTwo.transform.position = new Vector3(position.x, position.y + 1, position.z);
            _playerTwoController = playerTwo.GetComponent<PlayerController>();
            if (_playerTwoController == null)
            {
                _playerTwoController = playerTwo.AddComponent<PlayerController>();
            }

            _playerTwoController.enabled = false;
        }

        /// <summary>
        /// If they cross another character while moving, they swap positions as
        /// part of the movement.
        /// </summary>
        /// <param name="go">Prev Owner of the tile</param>
        /// <param name="position">Position of the prev tile owned by the player</param>
        public void ChangePosition(GameObject go, Vector3 position)
        {
            go.transform.position = new Vector3(position.x, position.y + 1, position.z);
        }

        public void PlayerOneMovement()
        {
            _playerOneController.enabled = true;
        }

        public void PlayerTwoMovement()
        {
            _playerTwoController.enabled = true;
        }

        public void DisableMOvement()
        {
            _playerOneController.enabled = false;
            _playerTwoController.enabled = false;
        }

        /// <summary>
        /// Set the winner name
        /// </summary>
        /// <param name="name"></param>
        public void SetWinner(string name)
        {
            _winnerName = name;
        }
    }
}