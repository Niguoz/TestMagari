using MagariProject.Input;
using MagariProject.UI;
using UnityEngine;

namespace MagariProject.Character
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 4f;
        [SerializeField]
        private int _possibleMoves = 3;

        private Player _playerController;
        private Rigidbody _rb;
        private Vector2 _movementInput;
        private Vector3 _moveOnZ;
        private int _moveStorage = 0;
        private GameObject _ownedTile;

        public GameObject OwnedTile { get { return _ownedTile; } set { _ownedTile = value; } }


        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            if (_rb == null)
            {
                Debug.LogError("NO RIGIDBODY");
            }

            _playerController = new Player();
        }

        /// <summary>
        /// Enables the movement and resets the possible moves
        /// </summary>
        private void OnEnable()
        {
            _playerController.PlayerMovement.Enable();
            _moveStorage = 0;
        }

        /// <summary>
        /// Disables the movement and set the velocity to 0
        /// </summary>
        private void OnDisable()
        {
            _playerController.PlayerMovement.Disable();
            _rb.velocity = Vector3.zero;
        }

        private void Update()
        {
            _movementInput = _playerController.PlayerMovement.Move.ReadValue<Vector2>();
            _moveOnZ = new Vector3(_movementInput.x, 0, _movementInput.y);
            _rb.velocity = _moveOnZ * _speed;
        }

        /// <summary>
        /// Decrement the player's moves and, if the player has no other moves, spawn it at the centre of its owned tile
        /// </summary>
        public void DecrementMoves()
        {
            _moveStorage++;
            if (_moveStorage == _possibleMoves)
            {
                gameObject.transform.position = new Vector3(_ownedTile.transform.position.x, _ownedTile.transform.position.y + 1, _ownedTile.transform.position.z);
                UIManager.Instance.ChangePlayer();
            }
        }
    }
}