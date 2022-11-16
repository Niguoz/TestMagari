using MagariProject.Input;
using UnityEngine;

namespace MagariProject.Character
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 4f;
        private Player _playerController;
        private Rigidbody _rb;
        private Vector2 _movementInput;
        private Vector3 _moveOnZ;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            if (_rb == null)
            {
                Debug.LogError("NO RIGIDBODY");
            }

            _playerController = new Player();
        }

        private void OnEnable()
        {
            _playerController.PlayerMovement.Enable();
        }

        private void OnDisable()
        {
            _playerController.PlayerMovement.Disable();
        }

        private void Update()
        {
            _movementInput = _playerController.PlayerMovement.Move.ReadValue<Vector2>();
            _moveOnZ = new Vector3(_movementInput.x, 0, _movementInput.y);
            _rb.velocity = _moveOnZ * _speed;
        }
    }
}