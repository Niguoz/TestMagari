using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagariProject.Game
{
    public class ComplexCube : SimpleCube
    {
        [SerializeField]
        private GameObject _owner;

        public void SetOwner(GameObject owner)
        {
            Debug.Log("Cambiato owner");
            _owner = owner; 
        }
    }
}