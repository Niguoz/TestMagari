using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagariProject.Game
{
    public class ComplexCube : MonoBehaviour
    {
        [SerializeField]
        protected GameObject _owner;

        public virtual void SetOwner(GameObject owner)
        {
            Debug.Log("Cambiato owner");
            _owner = owner; 
        }
    }
}