using MagariProject.Character;
using MagariProject.Common;
using UnityEngine;

namespace MagariProject.Game
{
    public class ComplexCube : MonoBehaviour
    {
        [SerializeField]
        protected GameObject _owner;

        /// <summary>
        /// Sets its owner
        /// </summary>
        /// <param name="owner"></param>
        public virtual void SetOwner(GameObject owner)
        {
            if (_owner != null)
            {
                GameObject prevOwner = _owner;
                GameObject prevTile = owner.GetComponent<PlayerController>().OwnedTile;
                Manager.Instance.ChangePosition(prevOwner, prevTile.transform.position);
            }
            _owner = owner;
        }

        /// <summary>
        /// Set the owner to null
        /// </summary>
        public void CancelOwner()
        {
            _owner = null;
        }
    }
}