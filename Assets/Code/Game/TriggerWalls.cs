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
                Debug.Log("Personaggio Entrato");
                player.DecrementMoves();
            }
        }
    }
}