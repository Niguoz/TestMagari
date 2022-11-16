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
            if(other.gameObject.GetComponent<PlayerController>() != null)
            {
                Debug.Log("Personaggio Entrato");
            }
        }
    }
}