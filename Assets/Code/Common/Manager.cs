using MagariProject.Character;
using MagariProject.Game;
using System;
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

        #region Spawns
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
        #endregion

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

        #region Movements
        public void PlayerOneMovement()
        {
            _playerOneController.enabled = true;
        }

        public void PlayerTwoMovement()
        {
            _playerTwoController.enabled = true;
        }

        public void EnableMovement(bool isPlayerOne)
        {
            if(isPlayerOne)
            {
                PlayerOneMovement();
            }
            else
            {
                PlayerTwoMovement();
            }
        }

        public void DisableMOvement()
        {
            _playerOneController.enabled = false;
            _playerTwoController.enabled = false;
        }

        #endregion

        #region GameState
        private GameState _gameState;
        public GameState CurrentGameState
        {
            get => _gameState;
            set
            {
                _gameState = value;

                if (OnGameStateChange != null)
                {
                    OnGameStateChange.Invoke(_gameState);
                }
            }
        }

        /// <summary>
        /// Event Triggered when the gameState is changed
        /// </summary>
        public event Action<GameState> OnGameStateChange;

        #endregion
    }
}