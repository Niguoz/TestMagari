using MagariProject.Character;
using UnityEngine;

namespace MagariProject.Game
{
    public class TriggerWalls : MonoBehaviour
    {
        private GameObject _parent;

        private void Awake()
        {
            _parent = this.transform.parent.transform.parent.gameObject;
        }

        /// <summary>
        /// Set the tile owner to player and decrement the player's moves
        /// </summary>
        private void OnTriggerEnter(Collider other)
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                _parent.GetComponent<ComplexCube>().SetOwner(player.gameObject);
                player.OwnedTile = _parent;
                player.DecrementMoves();
            }
        }

        /// <summary>
        /// Reset the tile owner to null
        /// </summary>
        private void OnTriggerExit(Collider other)
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                _parent.GetComponent<ComplexCube>().CancelOwner();
            }
        }
    }
}