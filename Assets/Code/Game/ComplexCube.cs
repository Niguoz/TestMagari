using MagariProject.Character;
using MagariProject.Common;
using UnityEngine;

namespace MagariProject.Game
{
    public class ComplexCube : MonoBehaviour
    {
        [SerializeField]
        protected GameObject _owner;

        public virtual void SetOwner(GameObject owner)
        {
            if (_owner != null)
            {
                GameObject prevOwner = _owner;
                GameObject prevTile = owner.GetComponent<PlayerController>().OwnedTile;
                Manager.Instance.ChangePosition(prevOwner, prevTile.transform.position);
            }
            Debug.Log("Cambiato owner");
            _owner = owner;
        }

        public void CancelOwner()
        {
            _owner= null;   
        }
    }
}