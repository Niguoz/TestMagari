using MagariProject.Common;
using System.Collections.Generic;
using UnityEngine;

namespace MagariProject.CameraManagment
{
    public class MultiTargetCamera : Singleton<MultiTargetCamera>
    {
        private List<Transform> _targets = new();
        private float _size;
        private Camera _camera;
        [SerializeField]
        private Vector3 _offset;

        /// <summary>
        /// Set the objects that have to be on screen and get the board size
        /// </summary>
        /// <param name="targets">List of gameobjects that have to be on screen</param>
        /// <param name="boardSize">Size of the Board</param>
        public void AdjustCamera(List<GameObject> targets, float boardSize)
        {
            _size = boardSize;
            foreach (GameObject t in targets)
            {
                _targets.Add(t.transform);
            }
            SetCamera();
        }

        protected override void Awake()
        {
            base.Awake();

            _camera = gameObject.GetComponent<Camera>();
            if(_camera == null)
            {
                Debug.LogWarning("NO CAMERA COMPONENT");
            }
        }

        /// <summary>
        /// Set the bounds and the ortographic size for the camera
        /// </summary>
        private void SetCamera()
        {
            Vector3 position = GetCentrePosition();
            Vector3 newPosition = position + _offset;

            transform.position = newPosition;

            float camerasize = _size - 4;

            if(camerasize < 6)
            {
                camerasize = 6;
            }

            _camera.orthographicSize = camerasize;
        }

        private Vector3 GetCentrePosition()
        {
            if (_targets.Count == 0)
            {
                return Vector3.zero;
            }
            else
            {
                Bounds bound = new Bounds(_targets[0].position, Vector3.one);
                for (int i = 0; i < _targets.Count; i++)
                {
                    bound.Encapsulate(_targets[i].position);
                }

                return bound.center;
            }
        }
    }
}