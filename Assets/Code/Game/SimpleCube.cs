using MagariProject.UI;
using UnityEngine;
using UnityEngine.Events;

namespace MagariProject.Game
{
    public class SimpleCube : MonoBehaviour
    {
        public UnityEvent _action;
        private bool _nearcomplexCube = false;
        private bool _hasOwner = false;

        [SerializeField]
        private LayerMask _layer;
        [SerializeField]
        private float _distance;
        [SerializeField]
        private Material _possibleChangeMat;

        private ComplexCube _complexCube;

        private void Awake()
        {
            _complexCube = GetComponent<ComplexCube>();
        }

        /// <summary>
        /// When clicked, set the place where the new tile has to spawn
        /// </summary>
        public void Changetile()
        {
            UIManager.Instance.SetDirectionSpawn(this.gameObject);
        }

        private void FixedUpdate()
        {
            CheckUp();
        }

        private void OnMouseDown()
        {
            if (_complexCube != null)
            {
                if (_complexCube.Owner != null)
                {
                    _hasOwner = true;
                }
            }

            if (_nearcomplexCube && !_hasOwner)
            {
                _action.Invoke();
            }
        }

        /// <summary>
        /// If it's near a dungeon cube change its boolean
        /// </summary>
        public void ChangeBool()
        {
            _nearcomplexCube = true;
            if (this.gameObject.name == "SimpleCube")
            {
                this.gameObject.GetComponent<MeshRenderer>().material = _possibleChangeMat;
            }
        }

        /// <summary>
        /// Check all the direction for a dungeon cube
        /// </summary>

        private void CheckLeft()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, _distance, _layer))
            {
                if (hit.collider.tag == "ComplexCube")
                {
                    ChangeBool();
                }
                else
                {
                    CheckDown();
                }
            }
            else
            {
                CheckDown();
            }
        }

        private void CheckUp()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, _distance, _layer))
            {
                if (hit.collider.tag == "ComplexCube")
                {
                    ChangeBool();
                }
                else
                {
                    CheckLeft();
                }

            }
            else
            {
                CheckLeft();
            }
        }

        private void CheckDown()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, _distance, _layer))
            {
                if (hit.collider.tag == "ComplexCube")
                {
                    ChangeBool();
                }
                else
                {
                    CheckRight();
                }
            }
            else
            {
                CheckRight();
            }
        }

        private void CheckRight()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, _distance, _layer))
            {
                if (hit.collider.tag == "ComplexCube")
                {
                    ChangeBool();
                }
            }
        }

    }
}