using MagariProject.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagariProject.Game
{
    public class TriggerWalls : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.DecrementMoves();
                this.transform.parent.transform.parent.gameObject.GetComponent<ComplexCube>().SetOwner(player.gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {             
                this.transform.parent.transform.parent.gameObject.GetComponent<ComplexCube>().SetOwner(null);
            }
        }
    }
}