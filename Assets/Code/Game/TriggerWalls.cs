using MagariProject.Character;
using System.Collections;
using System.Collections.Generic;
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